using TechCareerShoppingList.Back.Application.Enums;

namespace TechCareerShoppingList.Back.Tools
{
    public class QeryControl
    {
        public async void QueryControl(eQueryControl control)
        {
            switch (control)
            {
                case eQueryControl.error:
                    //return 
                    break;
                case eQueryControl.haveARecord:
                    //await ModelDialogService.ShowAlertAsync("Böyle bir kayıt zaten var.", "(-)", "OK");
                    break;
                case eQueryControl.noRecord:
                    break;
                case eQueryControl.nullValue:
                    //await ModelDialogService.ShowAlertAsync("Lütfen tüm bilgileri doldurup tekrar deneyiniz.", "(-)", "OK");
                    break;
                case eQueryControl.success:
                    //await ModelDialogService.ShowAlertAsync("İşlem başarılı.", ":)", "OK");
                    break;
                case eQueryControl.unsuccess:
                    //await ModelDialogService.ShowAlertAsync("İşlem  başarısız. Lütfen tekrar deneyin", "(:", "OK");
                    break;
                default:
                    break;
            }
        }
    }
}