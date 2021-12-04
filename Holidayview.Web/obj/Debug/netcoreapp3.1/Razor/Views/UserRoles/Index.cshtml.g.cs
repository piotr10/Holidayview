#pragma checksum "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d243b0a2d0dbdae7a7e4510edd472480c2d800e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserRoles_Index), @"mvc.1.0.view", @"/Views/UserRoles/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\_ViewImports.cshtml"
using Holidayview.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\_ViewImports.cshtml"
using Holidayview.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d243b0a2d0dbdae7a7e4510edd472480c2d800e", @"/Views/UserRoles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15e79014fe455738a6ad223ff81d0d6d9f238ba", @"/Views/_ViewImports.cshtml")]
    public class Views_UserRoles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Holidayview.Application.ViewModels.UserVm.ListUsersForListVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
   ViewData["Title"] = "Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Użytkownicy</h1>
<div class=""divRadius table-responsive"">
    <table class=""table table-bordered table-striped"" id=""table"" width=""100%"">
        <thead class="" thead-dark"">
            <tr>
                <th style=""text-align :center"">
                    Nazwa użytkownika
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
             foreach (var item in Model.Users)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td style=\"text-align:center\">\n        ");
#nullable restore
#line 21 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td style=\"text-align:center\">\n        <a class=\"btn btn-danger btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 722, "\"", 779, 5);
            WriteAttributeValue("", 729, "javascript:DeleteUser(\'", 729, 23, true);
#nullable restore
#line 24 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
WriteAttributeValue("", 752, item.Id, 752, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 760, "\',\'", 760, 3, true);
#nullable restore
#line 24 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
WriteAttributeValue("", 763, item.UserName, 763, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 777, "\')", 777, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Usuń użytkownika</a>\n        <a class=\"btn btn-info btn-sm\"");
            BeginWriteAttribute("href", " href=\"", 840, "\"", 878, 3);
            WriteAttributeValue("", 847, "javascript:SetRoles(\'", 847, 21, true);
#nullable restore
#line 25 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
WriteAttributeValue("", 868, item.Id, 868, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 876, "\')", 876, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Edytuj prawa</a>\n    </td>\n</tr>\n");
#nullable restore
#line 28 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
       }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n    <button id=\"DeleteRoles\" style=\"display:none\" type=\"button\" class=\"btn btn-danger\" onclick=\"ClearRoles()\">Zamknij formularz</button>\n\n    <div id=\"Roles\">\n\n    </div>\n</div>\n\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.22/css/jquery.dataTables.css"">

    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.js""></script>

    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#table').DataTable({
                ""scrollX"": true,
                responsive: true,
                ""pagingType"": ""full_numbers"",
                ""language"": {
                    ""lengthMenu"": ""Pokaż _MENU_ użytkowników na stronie"",
                    ""zeroRecords"": ""Brak pasujących użytkowników"",
                    ""info"": ""Strona _PAGE_ z _PAGES_"",
                    ""infoEmpty"": ""Brak użytkowników w bazie"",
                    ""infoFiltered"": ""(przeszukano z _MAX_ liczby rekordów)"",
                    ""search"": ""Wyszukaj: "",
                    ""paginate"": {
                        ""first"": ""Pierwsza"",
                        ""last"": ""Ostatnia"",
                        ""n");
                WriteLiteral(@"ext"": ""Następna"",
                        ""previous"": ""Poprzednia""
                    },

                },
                ""columns"": [
                    null,
                    { ""orderable"": false }
                ]
            });
        });

        function ClearRoles() {
            $('#Roles').empty();
            $('#DeleteRoles').hide();
        }

        function DeleteUser(id, name) {
            if (confirm('Czy na pewno chcesz usunąć użytkownika ' + name + '?')) {
                $.ajax({
                url: '");
#nullable restore
#line 81 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
                 Write(Url.Action("DeleteUser", "UserRoles"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                type: 'POST',
                data: { id: id },
                success: function(result) {
                    location.reload();
                }
                });
            }
        }

        function SetRoles(id) {
            var $divRoles = $('#Roles');
             $divRoles.empty();
             var url = '");
#nullable restore
#line 94 "C:\Users\olasa\Source\Repos\Holidayview\Holidayview.Web\Views\UserRoles\Index.cshtml"
                   Write(Url.Action("AddRolesToUser","UserRoles"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?id=\' + id;\n            $divRoles.load(url);\n            $(\'#DeleteRoles\').show();\n        }\n    </script>\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Holidayview.Application.ViewModels.UserVm.ListUsersForListVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
