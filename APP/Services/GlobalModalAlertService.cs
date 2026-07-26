using AntDesign;
using Microsoft.AspNetCore.Components;

public class GlobalModalAlertService
{
    private readonly ModalService _modalService;

    public GlobalModalAlertService(ModalService modalService)
    {
        _modalService = modalService;
    }

    public void ShowInfo(string title, string content)
    {
        _modalService.Info(new ConfirmOptions
        {
            Title = title,
            Content = content
        });
    }

    public void ShowSuccess(string message)
    {
        _modalService.Success(new ConfirmOptions
        {
            Content = message
        });
    }

    public void ShowError(string title, string message)
    {
        _modalService.Error(new ConfirmOptions
        {
            Title = title,
            Content = message
        });
    }

    public void ShowWarning(string title, string message)
    {
        _modalService.Warning(new ConfirmOptions
        {
            Title = title,
            Content = message
        });
    }
    public async Task<bool> ConfirmAsync(string title, string message)
    {
        var tcs = new TaskCompletionSource<bool>();

        _modalService.Confirm(new ConfirmOptions
        {
            Title = title,
            Content = message,
            OnOk = (ModalClosingEventArgs e) =>
            {
                tcs.SetResult(true);
                return Task.CompletedTask;
            },
            OnCancel = (ModalClosingEventArgs e) =>
            {
                tcs.SetResult(false);
                return Task.CompletedTask;
            }

        });

        return await tcs.Task;
    }
}
