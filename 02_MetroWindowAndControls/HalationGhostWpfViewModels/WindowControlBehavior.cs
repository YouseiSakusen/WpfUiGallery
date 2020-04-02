using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using HalationGhost.Win32Api;
using MahApps.Metro.Controls;
using Microsoft.Xaml.Behaviors;

namespace HalationGhost.WinApps
{
	/// <summary>Windowを制御するBehaviorを表します。</summary>
	public class WindowControlBehavior : Behavior<Window>
	{
		/// <summary>WindowがCloseできるかを取得・設定します。</summary>
		public bool CanClose
		{
			get { return (bool)GetValue(CanCloseProperty); }
			set { SetValue(CanCloseProperty, value); }
		}

		/// <summary>WindowがCloseできるかを取得・設定する依存プロパティ。</summary>
		public static readonly DependencyProperty CanCloseProperty =
			DependencyProperty.Register(nameof(CanClose),
							   typeof(bool),
							   typeof(WindowControlBehavior),
							   new PropertyMetadata(true, WindowControlBehavior.onPropertiesChanged));

		/// <summary>Windowが最大化できるかを取得・設定します。</summary>
		public bool CanMaxmize
		{
			get { return (bool)GetValue(CanMaxmizeProperty); }
			set { SetValue(CanMaxmizeProperty, value); }
		}

		/// <summary>Windowが最大化できるかを取得・設定する依存プロパティ。</summary>
		public static readonly DependencyProperty CanMaxmizeProperty =
			DependencyProperty.Register(nameof(CanMaxmize),
				typeof(bool),
				typeof(WindowControlBehavior),
				new PropertyMetadata(true, WindowControlBehavior.onPropertiesChanged));

		/// <summary>Windowが最小化できるかを取得・設定します。</summary>
		public bool CanMinimize
		{
			get { return (bool)GetValue(CanMinimizeProperty); }
			set { SetValue(CanMinimizeProperty, value); }
		}

		/// <summary>Windowが最小化できるかを取得・設定する依存プロパティ。</summary>
		public static readonly DependencyProperty CanMinimizeProperty =
			DependencyProperty.Register(nameof(CanMinimize),
				typeof(bool),
				typeof(WindowControlBehavior),
				new PropertyMetadata(true, WindowControlBehavior.onPropertiesChanged));

		/// <summary>Windowの移動可能かを取得・設定します。</summary>
		public bool CanMove
		{
			get { return (bool)GetValue(CanMoveProperty); }
			set { SetValue(CanMoveProperty, value); }
		}

		/// <summary>Windowの移動可能かを取得・設定する依存プロパティ。</summary>
		public static readonly DependencyProperty CanMoveProperty =
			DependencyProperty.Register(nameof(CanMove),
							   typeof(bool),
							   typeof(WindowControlBehavior),
							   new PropertyMetadata(true, WindowControlBehavior.onPropertiesChanged));

		/// <summary>システムメニューの表示/非表示を取得・設定します。</summary>
		public bool SystemMenuVisible
		{
			get { return (bool)GetValue(SystemMenuVisibleProperty); }
			set { SetValue(SystemMenuVisibleProperty, value); }
		}

		/// <summary>システムメニューの表示/非表示を取得・設定する依存プロパティ。</summary>
		public static readonly DependencyProperty SystemMenuVisibleProperty =
			DependencyProperty.Register(nameof(SystemMenuVisible),
							   typeof(bool),
							   typeof(WindowControlBehavior),
							   new PropertyMetadata(true, WindowControlBehavior.onPropertiesChanged));

		/// <summary>WindowをCloseします。</summary>
		public bool RequestClose
		{
			get { return (bool)GetValue(RequestCloseProperty); }
			set { SetValue(RequestCloseProperty, value); }
		}

		/// <summary>WindowをCloseする依存プロパティ。</summary>
		public static readonly DependencyProperty RequestCloseProperty =
			DependencyProperty.Register(nameof(RequestClose),
							   typeof(bool),
							   typeof(WindowControlBehavior),
							   new PropertyMetadata(false, WindowControlBehavior.onRequestClose));

		/// <summary>Window.Closingイベント時に呼び出されるCommandを表します。</summary>
		public ICommand CloseCanceledCallback
		{
			get { return (ICommand)GetValue(CloseCanceledCommandProperty); }
			set { SetValue(CloseCanceledCommandProperty, value); }
		}

		/// <summary>Window.Closingイベント時に呼び出されるCommandを表します。</summary>
		public static readonly DependencyProperty CloseCanceledCommandProperty =
			DependencyProperty.Register(nameof(CloseCanceledCallback),
				typeof(ICommand),
				typeof(WindowControlBehavior),
				new PropertyMetadata(null));

		/// <summary>Behaviorが依存コントロールに接続された場合に呼び出されます。</summary>
		protected override void OnAttached()
		{
			if (this.AssociatedObject == null)
				throw new InvalidOperationException();

			// Window Handleが必要な初期化処理
			this.AssociatedObject.SourceInitialized += this.onSourceInitialized;
			base.OnAttached();

			// Closingイベント
			this.AssociatedObject.Closing += (sender, e) =>
			{
				if ((this.CloseCanceledCallback != null) && (this.CloseCanceledCallback.CanExecute(null)))
					this.CloseCanceledCallback.Execute(null);

				e.Cancel = !this.CanClose;
			};
			// Closedイベント
			this.AssociatedObject.Closed += (sender, e) =>
			{
				(this.AssociatedObject.DataContext as IDisposable)?.Dispose();
			};
			// PreviewMouseDoubleClickイベント
			this.AssociatedObject.PreviewMouseDoubleClick += (sender, e) =>
			{
				if (!this.CanMaxmize)
				{
					if (e.ChangedButton == MouseButton.Left)
					{
						var mousePos = Mouse.GetPosition(this.AssociatedObject);
						var win = this.AssociatedObject as MetroWindow;
						if ((win != null) && (mousePos.Y <= win.TitlebarHeight) && (0 < win.TitlebarHeight))
							e.Handled = true;
					}
				}
			};
		}

		/// <summary>Behaviorが依存コントロールから取り外された場合に呼び出されます。</summary>
		protected override void OnDetaching()
		{
			var source = (HwndSource)HwndSource.FromVisual(this.AssociatedObject);
			source.RemoveHook(this.WndProc);
			this.AssociatedObject.SourceInitialized -= this.onSourceInitialized;

			base.OnDetaching();
		}

		/// <summary>WindowのSourceInitializedイベントハンドラ。</summary>
		/// <param name="sender">イベントのソース。</param>
		/// <param name="e">イベントデータを格納しているEventArgs。</param>
		private void onSourceInitialized(object sender, EventArgs e)
		{
			var source = (HwndSource)HwndSource.FromVisual(this.AssociatedObject);
			source.AddHook(this.WndProc);
			this.applyProperties();
		}

		/// <summary>RequestClose依存プロパティの変更イベントハンドラ。</summary>
		/// <param name="d">このBehaviorを表すDependencyObject。</param>
		/// <param name="e">変更されたプロパティを表すDependencyPropertyChangedEventArgs。</param>
		private static void onRequestClose(DependencyObject d, DependencyPropertyChangedEventArgs e)
			=> (d as WindowControlBehavior)?.closeWindow(e);

		/// <summary>WindowをCloseします。</summary>
		/// <param name="e"></param>
		private void closeWindow(DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
				this.AssociatedObject?.Close();
		}

		/// <summary>閉じる・最小化ボタン等の共通値変更イベントハンドラ。</summary>
		/// <param name="d">このBehaviorを表すDependencyObject。</param>
		/// <param name="e">変更されたプロパティを表すDependencyPropertyChangedEventArgs。</param>
		private static void onPropertiesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			=> (d as WindowControlBehavior)?.applyProperties();

		/// <summary>プロパティを適用します。</summary>
		private void applyProperties()
		{
			if (this.AssociatedObject == null)
				return;

			var hWnd = new WindowInteropHelper(this.AssociatedObject).Handle;
			MetroWindowStyle styleFlag = 0;

			if (this.SystemMenuVisible)
				styleFlag |= MetroWindowStyle.ShowSystemMenu;
			if (this.CanMaxmize)
				styleFlag |= MetroWindowStyle.CanMaxmize;
			if (this.CanMinimize)
				styleFlag |= MetroWindowStyle.CanMinimize;

			WindowApis.ChangeWindowStyle(hWnd, styleFlag);
		}

		/// <summary>Windowメッセージフックプロシージャを表します。</summary>
		/// <param name="hWnd">ウィンドウハンドルを表すIntPtr。</param>
		/// <param name="msg">ウィンドウメッセージを表すint。</param>
		/// <param name="wParam">パラメータを表すIntPtr。</param>
		/// <param name="lParam">パラメータを表すIntPtr。</param>
		/// <param name="handled">Windowメッセージ処理結果を返すbool。</param>
		/// <returns>Windowメッセージの処理結果を表すIntPtr。</returns>
		private IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == WindowsApiConstants.WM_INITMENU)
			{
				// 閉じるメニュー
				WindowApis.ChangeSystemMenuItemEnabled(hWnd, SystemMenuItem.CloseItem, this.CanClose);
				// 最大化メニュー
				WindowApis.ChangeSystemMenuItemEnabled(hWnd, SystemMenuItem.MaxmizeItem, this.CanMaxmize);
				// 最小化メニュー
				WindowApis.ChangeSystemMenuItemEnabled(hWnd, SystemMenuItem.MinimizeItem, this.CanMinimize);
				// 移動メニュー
				WindowApis.ChangeSystemMenuItemEnabled(hWnd, SystemMenuItem.MoveItem, this.CanMove);
			}

			return IntPtr.Zero;
		}
	}
}
