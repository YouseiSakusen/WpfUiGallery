using System.ComponentModel.DataAnnotations;
using HalationGhost.WinApps;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace MaterialDesignControls.MetroTextBoxes
{
	public class MetroTextBoxPanelViewModel : HalationGhostViewModelBase
	{
		/// <summary>MetroTextBoxスタイルの入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> NormalText { get; }

		/// <summary>SearchMetroTextBoxスタイルの入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> SearchText { get; }

		/// <summary>ButtonCommandMetroTextBoxスタイルの入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> ButtonText { get; }

		/// <summary>MaterialDesignFloatingHintTextBoxスタイルの入力文字列を取得・設定します。</summary>
		[Required(ErrorMessage = "必須入力です")]
		public ReactiveProperty<string> MaterialText { get; }

		public MetroTextBoxPanelViewModel()
		{
			var mode = ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError;

			this.NormalText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.NormalText)
				.AddTo(this.disposable);
			this.SearchText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.SearchText)
				.AddTo(this.disposable);
			this.ButtonText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.ButtonText)
				.AddTo(this.disposable);
			this.MaterialText = new ReactiveProperty<string>(string.Empty, mode: mode)
				.SetValidateAttribute(() => this.MaterialText)
				.AddTo(this.disposable);
		}
	}
}
