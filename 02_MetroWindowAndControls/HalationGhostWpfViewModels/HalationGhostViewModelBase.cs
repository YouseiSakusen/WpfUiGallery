using System;
using System.Reactive.Disposables;
using Prism.Mvvm;
using Prism.Regions;

namespace HalationGhost.WinApps
{
	public class HalationGhostViewModelBase : BindableBase, IDisposable
	{
		#region プロパティ

		protected CompositeDisposable disposable { get; } = new CompositeDisposable();

		public IRegionManager regionManager { get; } = null;

		#endregion

		#region IDisposable Support

		private void disposeRegions()
		{
			if (this.regionManager == null)
				return;

			foreach (var region in this.regionManager.Regions)
			{
				region.RemoveAll();
			}
		}

		private bool disposedValue = false; // 重複する呼び出しを検出するには

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					this.disposable.Dispose();

					// Region上のViewを破棄
					this.disposeRegions();
				}

				// TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
				// TODO: 大きなフィールドを null に設定します。

				disposedValue = true;
			}
		}

		// TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
		// ~HalationGhostViewModelBase()
		// {
		//   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
		//   Dispose(false);
		// }

		// このコードは、破棄可能なパターンを正しく実装できるように追加されました。
		public void Dispose()
		{
			// このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
			Dispose(true);
			// TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
			// GC.SuppressFinalize(this);
		}

		#endregion

		#region コンストラクタ

		public HalationGhostViewModelBase()
		{

		}

		public HalationGhostViewModelBase(IRegionManager regionMan) : this()
		{
			this.regionManager = regionMan;
		}

		#endregion
	}
}
