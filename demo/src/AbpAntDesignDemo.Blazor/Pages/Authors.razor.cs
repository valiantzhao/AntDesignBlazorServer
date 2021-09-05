using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpAntDesignDemo.Authors;
using AbpAntDesignDemo.Permissions;
using AntDesign;
using AntDesign.TableModels;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Text;

namespace AbpAntDesignDemo.Blazor.Pages
{
    /// <summary>
    /// 设备型号枚举
    /// </summary>
    public enum BookType
    {
        /// <summary>
        /// 类型一
        /// </summary>
        Type = 1,
        /// <summary>
        /// 类型二
        /// </summary>
        Type2 = 2
    }
    public partial class Authors
    {
        //[Inject] IStringLocalizer<CarsResource> L { get; set; }
        [Inject] protected NavigationManager navigationManager { get; set; }
        #region 对话框
        [Inject] public ModalService ModalService { get; set; }
        [Inject] private MessageService _message { get; set; }
        [Inject] private IAuthorAppService authorInfoAppService { get; set; }
        private ModalRef _modalRef;
        BookType? enumBookType;
        #endregion
        #region 表格
        private AuthorDto[] datas;
        private IEnumerable<AuthorDto> selectedRows;
        private ITable table;
        private int _pageIndex = 1;
        private int _pageSize = 20;
        private int _total = 0;
        #endregion
        #region 输入框
        [Parameter] public string txtValue { get; set; }
        #endregion
        protected override async Task OnInitializedAsync()
        {
            await GetDataAsync(_pageIndex, _pageSize, "");
        }
        public async Task OnChange(QueryModel<AuthorDto> queryModel)
        {
            var sortModel = queryModel.SortModel.Where(x => x.Sort != null).FirstOrDefault();
            await GetDataAsync(queryModel.PageIndex, queryModel.PageSize, sortModel == null ? "" : sortModel.FieldName);
        }
        public async void OnDataSearch()
        {
            await GetDataAsync(_pageIndex, _pageSize, "");
        }
        public async Task GetDataAsync(int pageIndex, int pageSize, string sort)
        {
            var result = await authorInfoAppService.GetListAsync(
                     new GetAuthorListDto()
                     {
                         SkipCount = (pageIndex - 1) * pageSize,
                         MaxResultCount = pageSize,
                         Sorting = sort,
                         Filter = txtValue
                     }
            );
            _total = (int)result.TotalCount;
            datas = result.Items.ToArray();
            StateHasChanged();
        }

        #region 按钮点击事件
        
        /// <summary>
        /// 新增
        /// </summary>
        private async Task OnAddAuthor()
        {
            var tempObj = new CreateAuthorDto();
            var modalConfig = new ModalOptions();
            modalConfig.Title = "作者新增";
            modalConfig.DestroyOnClose = true;
            modalConfig.MaskClosable = false;
            modalConfig.Footer = null;
            modalConfig.Width = "600px";
            modalConfig.AfterClose = () =>
            {
                OnDataSearch();
                return Task.CompletedTask;
            };
            _modalRef = await ModalService.CreateModalAsync<AddAuthors, CreateAuthorDto>(modalConfig, tempObj);
        }
        #endregion
    }
}
