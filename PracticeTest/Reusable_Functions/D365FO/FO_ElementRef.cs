using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework.Reusable_Functions.D365FO
{
    public class FO_ElementRef
    {
        public class FO_CommonRef
        {
            public static string CloseButtonsOnAllScreens = "//button[@name='SystemDefinedCloseButton']";
            public static string RefreshButton = "//button[@aria-label='Refresh']";
            public static string PleaseWaitBlockingMessage = "//*[@id='blockingMessage']";
            public static string ProcessingOperation = "//span[contains(text(), 'Processing operation')]";

            // Column sort
            public static string SortNewestToOldest = "//*[text() ='Sort newest to oldest']";
            public static string SortOldestToNewest = "//*[text() ='Sort oldest to newest']";
            public static string SortZToA = "//*[text() ='Sort Z to A']";
            public static string SortAToZ = "//*[text() ='Sort A to Z']";
            public static string FilterFieldTextBox = "//input[starts-with(@name,'FilterField')]";
            public static string ApplyFilterButton = "(//*[contains(@id,'ApplyFilters')])[1]";
            public static string ApplyFilterButton_2 = "//*[contains(@id,'ApplyFilters') and text() ='Apply']";
            public static string ClearFilterbutton = "(//*[contains(@id,'_ResetFilters')])[1]";

            // InsertColumns in grid
            public static string GridOptions_More = "//button[@aria-label='Grid options']";
            public static string InsertColumn_More = "//button[@id='AddNewColumnId']";
            public static string ColumnField_InsertColumnsPopup = "//div[@data-dyn-columnname='FormControlFieldSelector_Grid_Field']";
            public static string ColumnTable_InsertColumnsPopup = "//div[@data-dyn-columnname='FormControlFieldSelector_Grid_Table']";
            public static string CheckBox_InsertColumnsPopup = "//div[@aria-label='Select']//span";
            public static string OKButton_OK = "//button[@name='OK']";
            public static string OKButton_OK1 = "//button[@name='Ok']";
            public static string OKButton_OKButton = "//button[@name='OKButton']";
            public static string OKButton_Ok_OkButton = "//button[@name='OkButton']";
            public static string LineView_header = "//li[@data-dyn-controlname='LineView_header']";
            public static string HeaderView_header = "//li[@data-dyn-controlname='HeaderView_header']";
            public static string NoButton_No = "//button[@name='No']";
            public static string CloseButton = "//button[@name='CloseButton']";
            public static string NewButton = "//span[text() ='New']";
            public static string YesButton_Yes = "//button[@name='Yes']";
            public static string HorizotalScrollBar = "//div[@class='ScrollbarLayout_face ScrollbarLayout_faceHorizontal public_Scrollbar_face']";
            public static string HorizotalScrollBar_2 = "//div[@class='public_fixedDataTable_horizontalScrollbar']";
            public static string buttonLabelViewDetails = "//span[@class='button-label' and text()='View details']";
            public static string EditButton = "//button[@name='SystemDefinedViewEditButton']";
            public static string NotificationBellButton = "//*[@data-dyn-controlname='navBarMessageCenter']";

            //public static string HorizotalScrollBar = "(//div[@class='ScrollbarLayout_face ScrollbarLayout_faceHorizontal public_Scrollbar_face'])[2]";
            //public static string HorizotalScrollBar_2 = "//div[@data-dyn-controlname='SalesLineGrid']//div[@class='ScrollbarLayout_face ScrollbarLayout_faceHorizontal public_Scrollbar_face']";
            public static string HorizotalScrollBar_3 = "//div[@class='ScrollbarLayout_face ScrollbarLayout_faceHorizontal public_Scrollbar_faceActive public_Scrollbar_face']";

            //public static string buttonLabelViewDetails = "//span[@class='button-label' and text()='View details']"; //*[@aria-label='View details']
            // public static string EditButton = "//Button[contains(@id,'SystemDefinedViewEditButton')]";
            public static string CheckBox = "//span[contains(@class,'dyn-checkbox-span')]";
            public static string CheckBox2 = "//div[contains(@id,'TMVAutoAddonSelectionLine_UseMainAddonQty') and contains(@id,'container')]/div";
            public static string CheckBoxEnabled = "//*[contains(@class,'dyn-enabled')]";
            public static string CheckBoxDisabled = "//span[contains(@class,'dyn-checkbox-span')]";
            public static string QuickFilter = "//*[contains(@name,'QuickFilterControl_Input')]";
            public static string ActiveCheckBox = "//div[contains(@id,'SalesLineGrid') and contains(@id,'row-1')]//div[@title='Select or unselect row']";

            public static string CancelButton = "//*[@data-dyn-controlname='CancelButton']";
        }

        public static class FO_LoginPageRef
        {
            public static string Email = "loginfmt";
            public static string Password = "//input[@type='password']";
            public static string ClickNext = "//input[@type='submit']";
            /// <summary>
            ///  Element property for EmailTextBox in login page
            /// </summary>
            public static string EmailTextBox_id = "i0116";

            /// <summary>
            ///  Element property for EmailTextBox in login page
            /// </summary>
            public static string NextButton_id = "idSIButton9";

            /// <summary>
            ///  Element property for UsernameTextBox in login page
            /// </summary>
            public static string UsernameTextBox_id = "okta-signin-username";

            /// <summary>
            ///  Element property for PasswordTextBox in login page
            /// </summary>
            public static string PasswordTextBox_xpath = "//*[@name='passwd']";

            /// <summary>
            ///  Element property for SubmitButton in login page
            /// </summary>
            public static string SubmitButton_xpath = "//input[@type='submit']";
            public static string SubmitButton = "//*[@name='SubmitButton']";
            public static string NavDashboardLabel_id = "NavBarDashboard_label";
            public static string Save_Name = "SystemDefinedSaveButton";
        }
    }
}
