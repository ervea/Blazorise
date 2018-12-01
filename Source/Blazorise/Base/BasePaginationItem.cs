﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BasePaginationItem : BaseComponent
    {
        #region Members

        private bool isActive;

        private bool isDisabled;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.PaginationItem() )
                .If( () => ClassProvider.Active(), () => IsActive )
                .If( () => ClassProvider.Disabled(), () => IsDisabled );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        [Parameter]
        protected bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected bool IsDisabled
        {
            get => isDisabled;
            set
            {
                isDisabled = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        #endregion
    }
}
