﻿#region License
// 
// Copyright (c) 2013, Kooboo team
// 
// Licensed under the BSD License
// See the file LICENSE.txt for details.
// 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Kooboo.CMS.Form.Html.Controls
{
    public class DatetTime : Date
    {
        public override string Name
        {
            get { return "DateTime"; }
        }

        protected override string RenderInput(IColumn column)
        {
            string input =
                string.Format(
                    @"<input class=""long"" id=""{0}"" name=""{0}"" type=""{1}"" value=""@(Model.{0} ==null ? """" : ((Model.{0} is string)? Model.{0} : Model.{0}.ToLocalTime().ToString({3})))"" {2}/>",
                    column.Name, Type,
                    ValidationExtensions.GetUnobtrusiveValidationAttributeString(column),
                    "\"MM/dd/yyyy HH:mm:ss\"");
            return input + string.Format(@"<script language=""javascript"" type=""text/javascript"">$(function(){{$(""#{0}"").datetimepicker({1});}});</script>", 
                column.Name,
                "{controlType: 'select',timeFormat: 'HH:mm:ss',dateFormat:'mm/dd/yy'}");
        }
    }
}
