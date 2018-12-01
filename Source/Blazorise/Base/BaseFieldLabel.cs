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
    /// <summary>
    /// Sets the field label.
    /// </summary>
    public abstract class BaseFieldLabel : BaseSizableComponent
    {
        #region Members

        private bool isCheck;

        private bool isFile;

        private IFluentColumn columnSize;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.FieldLabel() )
                .If( () => ClassProvider.FieldLabelHorizontal(), () => ParentIsHorizontal )
                .If( () => ColumnSize.Class( ClassProvider ), () => ColumnSize != null );

            base.RegisterClasses();
        }

        #endregion

        #region Properties

        protected override bool NeedSizableBlock => ParentIsHorizontal && ParentAddons == null;

        [Parameter] protected string For { get; set; }

        [Parameter]
        protected bool IsCheck
        {
            get => isCheck;
            set
            {
                isCheck = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter]
        protected bool IsFile
        {
            get => isFile;
            set
            {
                isFile = value;

                ClassMapper.Dirty();
            }
        }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        [CascadingParameter] protected BaseAddons ParentAddons { get; set; }

        #endregion
    }
}
