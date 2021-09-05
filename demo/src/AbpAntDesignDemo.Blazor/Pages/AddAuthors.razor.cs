using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpAntDesignDemo.Authors;
using AbpAntDesignDemo.Localization;
using AntDesign;
using AntDesign.TableModels;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;

namespace AbpAntDesignDemo.Blazor.Pages
{
    public partial class AddAuthors
    {
        [Inject] IStringLocalizer<AbpAntDesignDemoResource> L { get; set; }
        private CreateAuthorDto _model;
        bool _visible = false;
        [Inject] private MessageService _message { get; set; }
        [Inject] private IAuthorAppService authorInfoAppService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _model = base.Options ?? new CreateAuthorDto();
            base.OnInitialized();
        }

        private void OnFinish(EditContext editContext)
        {
            if (string.IsNullOrWhiteSpace(_model.Name))
            {
                _message.Error("请输入名称！");
                return;
            }

            var ret = authorInfoAppService.CreateAsync(_model);
            if (ret.Result != null)
            {
                _message.Success("保存成功");
                base.StateHasChanged();
                _ = base.CloseFeedbackAsync();
            }
            else
            {
                _message.Success("保存失败");
            }
        }

        private void OnFinishFailed(EditContext editContext)
        {
            
        }
       
    }
}
