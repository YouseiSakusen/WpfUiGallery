using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;

namespace HalationGhost.WinApps.Services.MessageBoxes
{
	public class NotifyMessageBoxViewModel : HalationGhostViewModelBase, IDialogAware
	{
		public ReactivePropertySlim<string> Message { get; }

		public ReactiveCommand Ok { get; }

		#region IDialogAware

		public string Title => this.dialogTitle;

		public event Action<IDialogResult> RequestClose;

		public bool CanCloseDialog()
			=> true;

		public void OnDialogClosed()
			=> this.Dispose();

		private string dialogTitle = "情報";

		public void OnDialogOpened(IDialogParameters parameters)
		{
			this.dialogTitle = parameters.GetValue<string>("Title");
			this.Message.Value = parameters.GetValue<string>("Message");
		}

		#endregion

		public NotifyMessageBoxViewModel()
		{
			this.Message = new ReactivePropertySlim<string>(string.Empty)
				.AddTo(this.disposable);

			this.Ok = new ReactiveCommand()
				.WithSubscribe(() => this.RequestClose?.Invoke(new DialogResult(ButtonResult.OK)))
				.AddTo(this.disposable);
		}
	}
}
