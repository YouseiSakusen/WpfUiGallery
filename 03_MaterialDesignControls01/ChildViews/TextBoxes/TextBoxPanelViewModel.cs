using System.ComponentModel.DataAnnotations;
using HalationGhost.WinApps;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MaterialDesignControls.TextBoxes
{
	/// <summary>TextBoxパネルのViewModelを表します。</summary>
	public class TextBoxPanelViewModel : HalationGhostViewModelBase
	{
		/// <summary>MaterialDesignTextBoxスタイル（TextBoxデフォルトスタイル）の入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> NormalText { get; }

		/// <summary>MaterialDesignOutlinedTextFieldTextBoxスタイルの入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> OutlinedText { get; }

		/// <summary>MaterialDesignFloatingHintTextBoxスタイルの入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> FlotingText { get; }

		/// <summary>MaterialDesignFilledTextFieldTextBoxスタイルの入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> FilledText { get; }

		/// <summary>コンストラクタ。</summary>
		public TextBoxPanelViewModel()
		{
			var mode = ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError;

			this.NormalText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.NormalText)
				.AddTo(this.disposable);
			this.OutlinedText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.OutlinedText)
				.AddTo(this.disposable);
			this.FlotingText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.FlotingText)
				.AddTo(this.disposable);
			this.FilledText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.FilledText)
				.AddTo(this.disposable);
		}
	}
}
