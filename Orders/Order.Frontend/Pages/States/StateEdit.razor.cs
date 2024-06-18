using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Order.Frontend.Repositories;
using Order.Frontend.Shared;
using Orders.Shared.Entities;

namespace Order.Frontend.Pages.States
{
    [Authorize(Roles = "Admin")]
    public partial class StateEdit
    {
        private State? state;
        private FormWithName<State>? stateForm;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;

        [Parameter] public int StateId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<State>($"/api/states/{StateId}");
            if ( responseHttp.Error )
            {
                if ( responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound )
                {
                    Return();
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            state = responseHttp.Response;
        }

        private async Task SaveAsync()
        {
            var responseHttp = await Repository.PutAsync($"/api/states", state);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con éxito.");
        }

        private void Return()
        {
            stateForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo($"/countries/details/{state!.CountryId}");
        }
    }
}
