using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECS.WebAPI.DB.Tests
{
    [TestClass()]
    public class SqlServerUnitTests : SqlDatabaseTestClass
    {

        public SqlServerUnitTests()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Remove_Account_Permission_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerUnitTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Create_New_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Points_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Article_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Article_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Article_TagName_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_InterestTag_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_InterestTag_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition17;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Account_SecurityAnswer_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Account_SecurityAnswer_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition18;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Account_SecurityAnswer_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_SecurityQuestion_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_SecurityQuestion_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_SecurityQuestion_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_User_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_User_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_FirstName_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_User_ZipLocation_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_User_ZipLocation_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Create_Exist_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Suspend_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Change_Password_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Change_Username_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Article_Description_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Article_Title_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_LastName_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_Address_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_City_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_State_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_LinkedIn_Token_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_LinkedIn_Token_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Create_Account_Existing_Email_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition19;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_JWT_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition21;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_JWT_Token_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Salt_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition20;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Password_Salt_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Permission_From_List_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Permission_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Role_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Role_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition22;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition23;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition24;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition5;
            this.Remove_Account_PermissionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_AccountData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Create_New_AccountData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_Points_AccountData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_ArticleData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_ArticleData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_Article_TagNameData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_InterestTagData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_InterestTagData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_Account_SecurityAnswerData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_Account_SecurityAnswerData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_Account_SecurityAnswerData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_SecurityQuestionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_SecurityQuestionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_SecurityQuestionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_UserData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_UserData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_User_FirstNameData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_User_ZipLocationData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_User_ZipLocationData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Create_Exist_AccountData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Suspend_AccountData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Change_PasswordData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Change_UsernameData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_Article_DescriptionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_Article_TitleData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_User_LastNameData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_User_AddressData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_User_CityData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Update_User_StateData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_LinkedIn_TokenData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_LinkedIn_TokenData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Create_Account_Existing_EmailData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_JWTData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_JWT_TokenData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_SaltData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_Password_SaltData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_Permission_From_ListData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_PermissionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Delete_RoleData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Add_RoleData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            Remove_Account_Permission_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Delete_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Create_New_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_Points_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Delete_Article_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_Article_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Update_Article_TagName_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Delete_InterestTag_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_InterestTag_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition17 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Delete_Account_SecurityAnswer_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_Account_SecurityAnswer_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition18 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Update_Account_SecurityAnswer_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Delete_SecurityQuestion_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_SecurityQuestion_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            Update_SecurityQuestion_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Delete_User_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_User_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Update_User_FirstName_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Delete_User_ZipLocation_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_User_ZipLocation_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Create_Exist_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Suspend_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Change_Password_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Change_Username_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Update_Article_Description_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Update_Article_Title_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Update_User_LastName_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Update_User_Address_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Update_User_City_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Update_User_State_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Delete_LinkedIn_Token_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_LinkedIn_Token_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Create_Account_Existing_Email_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition19 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Delete_JWT_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition21 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_JWT_Token_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            Delete_Salt_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition20 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Add_Password_Salt_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            Delete_Permission_From_List_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_Permission_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_Role_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_Role_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            scalarValueCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition22 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition23 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition24 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // Remove_Account_Permission_TestAction
            // 
            Remove_Account_Permission_TestAction.Conditions.Add(rowCountCondition6);
            resources.ApplyResources(Remove_Account_Permission_TestAction, "Remove_Account_Permission_TestAction");
            // 
            // rowCountCondition6
            // 
            rowCountCondition6.Enabled = true;
            rowCountCondition6.Name = "rowCountCondition6";
            rowCountCondition6.ResultSet = 1;
            rowCountCondition6.RowCount = 147;
            // 
            // Delete_Account_TestAction
            // 
            Delete_Account_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(Delete_Account_TestAction, "Delete_Account_TestAction");
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 50;
            // 
            // Create_New_Account_TestAction
            // 
            Create_New_Account_TestAction.Conditions.Add(rowCountCondition3);
            resources.ApplyResources(Create_New_Account_TestAction, "Create_New_Account_TestAction");
            // 
            // rowCountCondition3
            // 
            rowCountCondition3.Enabled = true;
            rowCountCondition3.Name = "rowCountCondition3";
            rowCountCondition3.ResultSet = 1;
            rowCountCondition3.RowCount = 1;
            // 
            // Add_Points_Account_TestAction
            // 
            Add_Points_Account_TestAction.Conditions.Add(rowCountCondition4);
            resources.ApplyResources(Add_Points_Account_TestAction, "Add_Points_Account_TestAction");
            // 
            // rowCountCondition4
            // 
            rowCountCondition4.Enabled = true;
            rowCountCondition4.Name = "rowCountCondition4";
            rowCountCondition4.ResultSet = 1;
            rowCountCondition4.RowCount = 1;
            // 
            // Delete_Article_TestAction
            // 
            Delete_Article_TestAction.Conditions.Add(rowCountCondition7);
            resources.ApplyResources(Delete_Article_TestAction, "Delete_Article_TestAction");
            // 
            // rowCountCondition7
            // 
            rowCountCondition7.Enabled = true;
            rowCountCondition7.Name = "rowCountCondition7";
            rowCountCondition7.ResultSet = 1;
            rowCountCondition7.RowCount = 49;
            // 
            // Add_Article_TestAction
            // 
            Add_Article_TestAction.Conditions.Add(rowCountCondition2);
            resources.ApplyResources(Add_Article_TestAction, "Add_Article_TestAction");
            // 
            // rowCountCondition2
            // 
            rowCountCondition2.Enabled = true;
            rowCountCondition2.Name = "rowCountCondition2";
            rowCountCondition2.ResultSet = 1;
            rowCountCondition2.RowCount = 50;
            // 
            // Update_Article_TagName_TestAction
            // 
            Update_Article_TagName_TestAction.Conditions.Add(notEmptyResultSetCondition5);
            resources.ApplyResources(Update_Article_TagName_TestAction, "Update_Article_TagName_TestAction");
            // 
            // notEmptyResultSetCondition5
            // 
            notEmptyResultSetCondition5.Enabled = true;
            notEmptyResultSetCondition5.Name = "notEmptyResultSetCondition5";
            notEmptyResultSetCondition5.ResultSet = 1;
            // 
            // Delete_InterestTag_TestAction
            // 
            Delete_InterestTag_TestAction.Conditions.Add(rowCountCondition8);
            resources.ApplyResources(Delete_InterestTag_TestAction, "Delete_InterestTag_TestAction");
            // 
            // rowCountCondition8
            // 
            rowCountCondition8.Enabled = true;
            rowCountCondition8.Name = "rowCountCondition8";
            rowCountCondition8.ResultSet = 1;
            rowCountCondition8.RowCount = 10;
            // 
            // Add_InterestTag_TestAction
            // 
            Add_InterestTag_TestAction.Conditions.Add(rowCountCondition17);
            resources.ApplyResources(Add_InterestTag_TestAction, "Add_InterestTag_TestAction");
            // 
            // rowCountCondition17
            // 
            rowCountCondition17.Enabled = true;
            rowCountCondition17.Name = "rowCountCondition17";
            rowCountCondition17.ResultSet = 1;
            rowCountCondition17.RowCount = 11;
            // 
            // Delete_Account_SecurityAnswer_TestAction
            // 
            Delete_Account_SecurityAnswer_TestAction.Conditions.Add(rowCountCondition10);
            resources.ApplyResources(Delete_Account_SecurityAnswer_TestAction, "Delete_Account_SecurityAnswer_TestAction");
            // 
            // rowCountCondition10
            // 
            rowCountCondition10.Enabled = true;
            rowCountCondition10.Name = "rowCountCondition10";
            rowCountCondition10.ResultSet = 1;
            rowCountCondition10.RowCount = 147;
            // 
            // Add_Account_SecurityAnswer_TestAction
            // 
            Add_Account_SecurityAnswer_TestAction.Conditions.Add(rowCountCondition18);
            resources.ApplyResources(Add_Account_SecurityAnswer_TestAction, "Add_Account_SecurityAnswer_TestAction");
            // 
            // rowCountCondition18
            // 
            rowCountCondition18.Enabled = true;
            rowCountCondition18.Name = "rowCountCondition18";
            rowCountCondition18.ResultSet = 1;
            rowCountCondition18.RowCount = 1;
            // 
            // Update_Account_SecurityAnswer_TestAction
            // 
            Update_Account_SecurityAnswer_TestAction.Conditions.Add(notEmptyResultSetCondition10);
            resources.ApplyResources(Update_Account_SecurityAnswer_TestAction, "Update_Account_SecurityAnswer_TestAction");
            // 
            // notEmptyResultSetCondition10
            // 
            notEmptyResultSetCondition10.Enabled = true;
            notEmptyResultSetCondition10.Name = "notEmptyResultSetCondition10";
            notEmptyResultSetCondition10.ResultSet = 1;
            // 
            // Delete_SecurityQuestion_TestAction
            // 
            Delete_SecurityQuestion_TestAction.Conditions.Add(rowCountCondition9);
            resources.ApplyResources(Delete_SecurityQuestion_TestAction, "Delete_SecurityQuestion_TestAction");
            // 
            // rowCountCondition9
            // 
            rowCountCondition9.Enabled = true;
            rowCountCondition9.Name = "rowCountCondition9";
            rowCountCondition9.ResultSet = 1;
            rowCountCondition9.RowCount = 3;
            // 
            // Add_SecurityQuestion_TestAction
            // 
            Add_SecurityQuestion_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(Add_SecurityQuestion_TestAction, "Add_SecurityQuestion_TestAction");
            // 
            // scalarValueCondition1
            // 
            scalarValueCondition1.ColumnNumber = 1;
            scalarValueCondition1.Enabled = true;
            scalarValueCondition1.ExpectedValue = "4";
            scalarValueCondition1.Name = "scalarValueCondition1";
            scalarValueCondition1.NullExpected = false;
            scalarValueCondition1.ResultSet = 1;
            scalarValueCondition1.RowNumber = 1;
            // 
            // Update_SecurityQuestion_TestAction
            // 
            Update_SecurityQuestion_TestAction.Conditions.Add(notEmptyResultSetCondition8);
            resources.ApplyResources(Update_SecurityQuestion_TestAction, "Update_SecurityQuestion_TestAction");
            // 
            // notEmptyResultSetCondition8
            // 
            notEmptyResultSetCondition8.Enabled = true;
            notEmptyResultSetCondition8.Name = "notEmptyResultSetCondition8";
            notEmptyResultSetCondition8.ResultSet = 1;
            // 
            // Delete_User_TestAction
            // 
            Delete_User_TestAction.Conditions.Add(rowCountCondition12);
            resources.ApplyResources(Delete_User_TestAction, "Delete_User_TestAction");
            // 
            // rowCountCondition12
            // 
            rowCountCondition12.Enabled = true;
            rowCountCondition12.Name = "rowCountCondition12";
            rowCountCondition12.ResultSet = 1;
            rowCountCondition12.RowCount = 50;
            // 
            // Add_User_TestAction
            // 
            Add_User_TestAction.Conditions.Add(rowCountCondition11);
            resources.ApplyResources(Add_User_TestAction, "Add_User_TestAction");
            // 
            // rowCountCondition11
            // 
            rowCountCondition11.Enabled = true;
            rowCountCondition11.Name = "rowCountCondition11";
            rowCountCondition11.ResultSet = 1;
            rowCountCondition11.RowCount = 51;
            // 
            // Update_User_FirstName_TestAction
            // 
            Update_User_FirstName_TestAction.Conditions.Add(notEmptyResultSetCondition12);
            resources.ApplyResources(Update_User_FirstName_TestAction, "Update_User_FirstName_TestAction");
            // 
            // notEmptyResultSetCondition12
            // 
            notEmptyResultSetCondition12.Enabled = true;
            notEmptyResultSetCondition12.Name = "notEmptyResultSetCondition12";
            notEmptyResultSetCondition12.ResultSet = 1;
            // 
            // Delete_User_ZipLocation_TestAction
            // 
            Delete_User_ZipLocation_TestAction.Conditions.Add(rowCountCondition14);
            resources.ApplyResources(Delete_User_ZipLocation_TestAction, "Delete_User_ZipLocation_TestAction");
            // 
            // rowCountCondition14
            // 
            rowCountCondition14.Enabled = true;
            rowCountCondition14.Name = "rowCountCondition14";
            rowCountCondition14.ResultSet = 1;
            rowCountCondition14.RowCount = 4;
            // 
            // Add_User_ZipLocation_TestAction
            // 
            Add_User_ZipLocation_TestAction.Conditions.Add(scalarValueCondition5);
            resources.ApplyResources(Add_User_ZipLocation_TestAction, "Add_User_ZipLocation_TestAction");
            // 
            // Create_Exist_Account_TestAction
            // 
            Create_Exist_Account_TestAction.Conditions.Add(rowCountCondition5);
            resources.ApplyResources(Create_Exist_Account_TestAction, "Create_Exist_Account_TestAction");
            // 
            // rowCountCondition5
            // 
            rowCountCondition5.Enabled = true;
            rowCountCondition5.Name = "rowCountCondition5";
            rowCountCondition5.ResultSet = 1;
            rowCountCondition5.RowCount = 1;
            // 
            // Suspend_Account_TestAction
            // 
            Suspend_Account_TestAction.Conditions.Add(notEmptyResultSetCondition2);
            resources.ApplyResources(Suspend_Account_TestAction, "Suspend_Account_TestAction");
            // 
            // notEmptyResultSetCondition2
            // 
            notEmptyResultSetCondition2.Enabled = true;
            notEmptyResultSetCondition2.Name = "notEmptyResultSetCondition2";
            notEmptyResultSetCondition2.ResultSet = 1;
            // 
            // Change_Password_TestAction
            // 
            Change_Password_TestAction.Conditions.Add(notEmptyResultSetCondition1);
            resources.ApplyResources(Change_Password_TestAction, "Change_Password_TestAction");
            // 
            // notEmptyResultSetCondition1
            // 
            notEmptyResultSetCondition1.Enabled = true;
            notEmptyResultSetCondition1.Name = "notEmptyResultSetCondition1";
            notEmptyResultSetCondition1.ResultSet = 1;
            // 
            // Change_Username_TestAction
            // 
            Change_Username_TestAction.Conditions.Add(notEmptyResultSetCondition3);
            resources.ApplyResources(Change_Username_TestAction, "Change_Username_TestAction");
            // 
            // notEmptyResultSetCondition3
            // 
            notEmptyResultSetCondition3.Enabled = true;
            notEmptyResultSetCondition3.Name = "notEmptyResultSetCondition3";
            notEmptyResultSetCondition3.ResultSet = 1;
            // 
            // Update_Article_Description_TestAction
            // 
            Update_Article_Description_TestAction.Conditions.Add(notEmptyResultSetCondition6);
            resources.ApplyResources(Update_Article_Description_TestAction, "Update_Article_Description_TestAction");
            // 
            // notEmptyResultSetCondition6
            // 
            notEmptyResultSetCondition6.Enabled = true;
            notEmptyResultSetCondition6.Name = "notEmptyResultSetCondition6";
            notEmptyResultSetCondition6.ResultSet = 1;
            // 
            // Update_Article_Title_TestAction
            // 
            Update_Article_Title_TestAction.Conditions.Add(notEmptyResultSetCondition7);
            resources.ApplyResources(Update_Article_Title_TestAction, "Update_Article_Title_TestAction");
            // 
            // notEmptyResultSetCondition7
            // 
            notEmptyResultSetCondition7.Enabled = true;
            notEmptyResultSetCondition7.Name = "notEmptyResultSetCondition7";
            notEmptyResultSetCondition7.ResultSet = 1;
            // 
            // Update_User_LastName_TestAction
            // 
            Update_User_LastName_TestAction.Conditions.Add(notEmptyResultSetCondition11);
            resources.ApplyResources(Update_User_LastName_TestAction, "Update_User_LastName_TestAction");
            // 
            // notEmptyResultSetCondition11
            // 
            notEmptyResultSetCondition11.Enabled = true;
            notEmptyResultSetCondition11.Name = "notEmptyResultSetCondition11";
            notEmptyResultSetCondition11.ResultSet = 1;
            // 
            // Update_User_Address_TestAction
            // 
            Update_User_Address_TestAction.Conditions.Add(notEmptyResultSetCondition13);
            resources.ApplyResources(Update_User_Address_TestAction, "Update_User_Address_TestAction");
            // 
            // notEmptyResultSetCondition13
            // 
            notEmptyResultSetCondition13.Enabled = true;
            notEmptyResultSetCondition13.Name = "notEmptyResultSetCondition13";
            notEmptyResultSetCondition13.ResultSet = 1;
            // 
            // Update_User_City_TestAction
            // 
            Update_User_City_TestAction.Conditions.Add(notEmptyResultSetCondition14);
            resources.ApplyResources(Update_User_City_TestAction, "Update_User_City_TestAction");
            // 
            // notEmptyResultSetCondition14
            // 
            notEmptyResultSetCondition14.Enabled = true;
            notEmptyResultSetCondition14.Name = "notEmptyResultSetCondition14";
            notEmptyResultSetCondition14.ResultSet = 1;
            // 
            // Update_User_State_TestAction
            // 
            Update_User_State_TestAction.Conditions.Add(notEmptyResultSetCondition15);
            resources.ApplyResources(Update_User_State_TestAction, "Update_User_State_TestAction");
            // 
            // notEmptyResultSetCondition15
            // 
            notEmptyResultSetCondition15.Enabled = true;
            notEmptyResultSetCondition15.Name = "notEmptyResultSetCondition15";
            notEmptyResultSetCondition15.ResultSet = 1;
            // 
            // Delete_LinkedIn_Token_TestAction
            // 
            Delete_LinkedIn_Token_TestAction.Conditions.Add(rowCountCondition16);
            resources.ApplyResources(Delete_LinkedIn_Token_TestAction, "Delete_LinkedIn_Token_TestAction");
            // 
            // rowCountCondition16
            // 
            rowCountCondition16.Enabled = true;
            rowCountCondition16.Name = "rowCountCondition16";
            rowCountCondition16.ResultSet = 1;
            rowCountCondition16.RowCount = 50;
            // 
            // Add_LinkedIn_Token_TestAction
            // 
            Add_LinkedIn_Token_TestAction.Conditions.Add(rowCountCondition15);
            resources.ApplyResources(Add_LinkedIn_Token_TestAction, "Add_LinkedIn_Token_TestAction");
            // 
            // rowCountCondition15
            // 
            rowCountCondition15.Enabled = true;
            rowCountCondition15.Name = "rowCountCondition15";
            rowCountCondition15.ResultSet = 1;
            rowCountCondition15.RowCount = 51;
            // 
            // Create_Account_Existing_Email_TestAction
            // 
            Create_Account_Existing_Email_TestAction.Conditions.Add(rowCountCondition19);
            resources.ApplyResources(Create_Account_Existing_Email_TestAction, "Create_Account_Existing_Email_TestAction");
            // 
            // rowCountCondition19
            // 
            rowCountCondition19.Enabled = true;
            rowCountCondition19.Name = "rowCountCondition19";
            rowCountCondition19.ResultSet = 1;
            rowCountCondition19.RowCount = 1;
            // 
            // Delete_JWT_TestAction
            // 
            Delete_JWT_TestAction.Conditions.Add(rowCountCondition21);
            resources.ApplyResources(Delete_JWT_TestAction, "Delete_JWT_TestAction");
            // 
            // rowCountCondition21
            // 
            rowCountCondition21.Enabled = true;
            rowCountCondition21.Name = "rowCountCondition21";
            rowCountCondition21.ResultSet = 1;
            rowCountCondition21.RowCount = 5;
            // 
            // Add_JWT_Token_TestAction
            // 
            Add_JWT_Token_TestAction.Conditions.Add(scalarValueCondition2);
            resources.ApplyResources(Add_JWT_Token_TestAction, "Add_JWT_Token_TestAction");
            // 
            // scalarValueCondition2
            // 
            scalarValueCondition2.ColumnNumber = 1;
            scalarValueCondition2.Enabled = true;
            scalarValueCondition2.ExpectedValue = "6";
            scalarValueCondition2.Name = "scalarValueCondition2";
            scalarValueCondition2.NullExpected = false;
            scalarValueCondition2.ResultSet = 1;
            scalarValueCondition2.RowNumber = 1;
            // 
            // Delete_Salt_TestAction
            // 
            Delete_Salt_TestAction.Conditions.Add(rowCountCondition20);
            resources.ApplyResources(Delete_Salt_TestAction, "Delete_Salt_TestAction");
            // 
            // rowCountCondition20
            // 
            rowCountCondition20.Enabled = true;
            rowCountCondition20.Name = "rowCountCondition20";
            rowCountCondition20.ResultSet = 1;
            rowCountCondition20.RowCount = 5;
            // 
            // Add_Password_Salt_TestAction
            // 
            Add_Password_Salt_TestAction.Conditions.Add(scalarValueCondition4);
            resources.ApplyResources(Add_Password_Salt_TestAction, "Add_Password_Salt_TestAction");
            // 
            // scalarValueCondition4
            // 
            scalarValueCondition4.ColumnNumber = 1;
            scalarValueCondition4.Enabled = true;
            scalarValueCondition4.ExpectedValue = "6";
            scalarValueCondition4.Name = "scalarValueCondition4";
            scalarValueCondition4.NullExpected = false;
            scalarValueCondition4.ResultSet = 1;
            scalarValueCondition4.RowNumber = 1;
            // 
            // Remove_Account_PermissionData
            // 
            this.Remove_Account_PermissionData.PosttestAction = null;
            this.Remove_Account_PermissionData.PretestAction = null;
            this.Remove_Account_PermissionData.TestAction = Remove_Account_Permission_TestAction;
            // 
            // Delete_AccountData
            // 
            this.Delete_AccountData.PosttestAction = null;
            this.Delete_AccountData.PretestAction = null;
            this.Delete_AccountData.TestAction = Delete_Account_TestAction;
            // 
            // Create_New_AccountData
            // 
            this.Create_New_AccountData.PosttestAction = null;
            this.Create_New_AccountData.PretestAction = null;
            this.Create_New_AccountData.TestAction = Create_New_Account_TestAction;
            // 
            // Add_Points_AccountData
            // 
            this.Add_Points_AccountData.PosttestAction = null;
            this.Add_Points_AccountData.PretestAction = null;
            this.Add_Points_AccountData.TestAction = Add_Points_Account_TestAction;
            // 
            // Delete_ArticleData
            // 
            this.Delete_ArticleData.PosttestAction = null;
            this.Delete_ArticleData.PretestAction = null;
            this.Delete_ArticleData.TestAction = Delete_Article_TestAction;
            // 
            // Add_ArticleData
            // 
            this.Add_ArticleData.PosttestAction = null;
            this.Add_ArticleData.PretestAction = null;
            this.Add_ArticleData.TestAction = Add_Article_TestAction;
            // 
            // Update_Article_TagNameData
            // 
            this.Update_Article_TagNameData.PosttestAction = null;
            this.Update_Article_TagNameData.PretestAction = null;
            this.Update_Article_TagNameData.TestAction = Update_Article_TagName_TestAction;
            // 
            // Delete_InterestTagData
            // 
            this.Delete_InterestTagData.PosttestAction = null;
            this.Delete_InterestTagData.PretestAction = null;
            this.Delete_InterestTagData.TestAction = Delete_InterestTag_TestAction;
            // 
            // Add_InterestTagData
            // 
            this.Add_InterestTagData.PosttestAction = null;
            this.Add_InterestTagData.PretestAction = null;
            this.Add_InterestTagData.TestAction = Add_InterestTag_TestAction;
            // 
            // Delete_Account_SecurityAnswerData
            // 
            this.Delete_Account_SecurityAnswerData.PosttestAction = null;
            this.Delete_Account_SecurityAnswerData.PretestAction = null;
            this.Delete_Account_SecurityAnswerData.TestAction = Delete_Account_SecurityAnswer_TestAction;
            // 
            // Add_Account_SecurityAnswerData
            // 
            this.Add_Account_SecurityAnswerData.PosttestAction = null;
            this.Add_Account_SecurityAnswerData.PretestAction = null;
            this.Add_Account_SecurityAnswerData.TestAction = Add_Account_SecurityAnswer_TestAction;
            // 
            // Update_Account_SecurityAnswerData
            // 
            this.Update_Account_SecurityAnswerData.PosttestAction = null;
            this.Update_Account_SecurityAnswerData.PretestAction = null;
            this.Update_Account_SecurityAnswerData.TestAction = Update_Account_SecurityAnswer_TestAction;
            // 
            // Delete_SecurityQuestionData
            // 
            this.Delete_SecurityQuestionData.PosttestAction = null;
            this.Delete_SecurityQuestionData.PretestAction = null;
            this.Delete_SecurityQuestionData.TestAction = Delete_SecurityQuestion_TestAction;
            // 
            // Add_SecurityQuestionData
            // 
            this.Add_SecurityQuestionData.PosttestAction = null;
            this.Add_SecurityQuestionData.PretestAction = null;
            this.Add_SecurityQuestionData.TestAction = Add_SecurityQuestion_TestAction;
            // 
            // Update_SecurityQuestionData
            // 
            this.Update_SecurityQuestionData.PosttestAction = null;
            this.Update_SecurityQuestionData.PretestAction = null;
            this.Update_SecurityQuestionData.TestAction = Update_SecurityQuestion_TestAction;
            // 
            // Delete_UserData
            // 
            this.Delete_UserData.PosttestAction = null;
            this.Delete_UserData.PretestAction = null;
            this.Delete_UserData.TestAction = Delete_User_TestAction;
            // 
            // Add_UserData
            // 
            this.Add_UserData.PosttestAction = null;
            this.Add_UserData.PretestAction = null;
            this.Add_UserData.TestAction = Add_User_TestAction;
            // 
            // Update_User_FirstNameData
            // 
            this.Update_User_FirstNameData.PosttestAction = null;
            this.Update_User_FirstNameData.PretestAction = null;
            this.Update_User_FirstNameData.TestAction = Update_User_FirstName_TestAction;
            // 
            // Delete_User_ZipLocationData
            // 
            this.Delete_User_ZipLocationData.PosttestAction = null;
            this.Delete_User_ZipLocationData.PretestAction = null;
            this.Delete_User_ZipLocationData.TestAction = Delete_User_ZipLocation_TestAction;
            // 
            // Add_User_ZipLocationData
            // 
            this.Add_User_ZipLocationData.PosttestAction = null;
            this.Add_User_ZipLocationData.PretestAction = null;
            this.Add_User_ZipLocationData.TestAction = Add_User_ZipLocation_TestAction;
            // 
            // Create_Exist_AccountData
            // 
            this.Create_Exist_AccountData.PosttestAction = null;
            this.Create_Exist_AccountData.PretestAction = null;
            this.Create_Exist_AccountData.TestAction = Create_Exist_Account_TestAction;
            // 
            // Suspend_AccountData
            // 
            this.Suspend_AccountData.PosttestAction = null;
            this.Suspend_AccountData.PretestAction = null;
            this.Suspend_AccountData.TestAction = Suspend_Account_TestAction;
            // 
            // Change_PasswordData
            // 
            this.Change_PasswordData.PosttestAction = null;
            this.Change_PasswordData.PretestAction = null;
            this.Change_PasswordData.TestAction = Change_Password_TestAction;
            // 
            // Change_UsernameData
            // 
            this.Change_UsernameData.PosttestAction = null;
            this.Change_UsernameData.PretestAction = null;
            this.Change_UsernameData.TestAction = Change_Username_TestAction;
            // 
            // Update_Article_DescriptionData
            // 
            this.Update_Article_DescriptionData.PosttestAction = null;
            this.Update_Article_DescriptionData.PretestAction = null;
            this.Update_Article_DescriptionData.TestAction = Update_Article_Description_TestAction;
            // 
            // Update_Article_TitleData
            // 
            this.Update_Article_TitleData.PosttestAction = null;
            this.Update_Article_TitleData.PretestAction = null;
            this.Update_Article_TitleData.TestAction = Update_Article_Title_TestAction;
            // 
            // Update_User_LastNameData
            // 
            this.Update_User_LastNameData.PosttestAction = null;
            this.Update_User_LastNameData.PretestAction = null;
            this.Update_User_LastNameData.TestAction = Update_User_LastName_TestAction;
            // 
            // Update_User_AddressData
            // 
            this.Update_User_AddressData.PosttestAction = null;
            this.Update_User_AddressData.PretestAction = null;
            this.Update_User_AddressData.TestAction = Update_User_Address_TestAction;
            // 
            // Update_User_CityData
            // 
            this.Update_User_CityData.PosttestAction = null;
            this.Update_User_CityData.PretestAction = null;
            this.Update_User_CityData.TestAction = Update_User_City_TestAction;
            // 
            // Update_User_StateData
            // 
            this.Update_User_StateData.PosttestAction = null;
            this.Update_User_StateData.PretestAction = null;
            this.Update_User_StateData.TestAction = Update_User_State_TestAction;
            // 
            // Delete_LinkedIn_TokenData
            // 
            this.Delete_LinkedIn_TokenData.PosttestAction = null;
            this.Delete_LinkedIn_TokenData.PretestAction = null;
            this.Delete_LinkedIn_TokenData.TestAction = Delete_LinkedIn_Token_TestAction;
            // 
            // Add_LinkedIn_TokenData
            // 
            this.Add_LinkedIn_TokenData.PosttestAction = null;
            this.Add_LinkedIn_TokenData.PretestAction = null;
            this.Add_LinkedIn_TokenData.TestAction = Add_LinkedIn_Token_TestAction;
            // 
            // Create_Account_Existing_EmailData
            // 
            this.Create_Account_Existing_EmailData.PosttestAction = null;
            this.Create_Account_Existing_EmailData.PretestAction = null;
            this.Create_Account_Existing_EmailData.TestAction = Create_Account_Existing_Email_TestAction;
            // 
            // Delete_JWTData
            // 
            this.Delete_JWTData.PosttestAction = null;
            this.Delete_JWTData.PretestAction = null;
            this.Delete_JWTData.TestAction = Delete_JWT_TestAction;
            // 
            // Add_JWT_TokenData
            // 
            this.Add_JWT_TokenData.PosttestAction = null;
            this.Add_JWT_TokenData.PretestAction = null;
            this.Add_JWT_TokenData.TestAction = Add_JWT_Token_TestAction;
            // 
            // Delete_SaltData
            // 
            this.Delete_SaltData.PosttestAction = null;
            this.Delete_SaltData.PretestAction = null;
            this.Delete_SaltData.TestAction = Delete_Salt_TestAction;
            // 
            // Add_Password_SaltData
            // 
            this.Add_Password_SaltData.PosttestAction = null;
            this.Add_Password_SaltData.PretestAction = null;
            this.Add_Password_SaltData.TestAction = Add_Password_Salt_TestAction;
            // 
            // Delete_Permission_From_ListData
            // 
            this.Delete_Permission_From_ListData.PosttestAction = null;
            this.Delete_Permission_From_ListData.PretestAction = null;
            this.Delete_Permission_From_ListData.TestAction = Delete_Permission_From_List_TestAction;
            // 
            // Delete_Permission_From_List_TestAction
            // 
            Delete_Permission_From_List_TestAction.Conditions.Add(rowCountCondition24);
            resources.ApplyResources(Delete_Permission_From_List_TestAction, "Delete_Permission_From_List_TestAction");
            // 
            // Add_PermissionData
            // 
            this.Add_PermissionData.PosttestAction = null;
            this.Add_PermissionData.PretestAction = null;
            this.Add_PermissionData.TestAction = Add_Permission_TestAction;
            // 
            // Add_Permission_TestAction
            // 
            Add_Permission_TestAction.Conditions.Add(rowCountCondition23);
            resources.ApplyResources(Add_Permission_TestAction, "Add_Permission_TestAction");
            // 
            // Delete_RoleData
            // 
            this.Delete_RoleData.PosttestAction = null;
            this.Delete_RoleData.PretestAction = null;
            this.Delete_RoleData.TestAction = Delete_Role_TestAction;
            // 
            // Delete_Role_TestAction
            // 
            Delete_Role_TestAction.Conditions.Add(rowCountCondition22);
            resources.ApplyResources(Delete_Role_TestAction, "Delete_Role_TestAction");
            // 
            // Add_RoleData
            // 
            this.Add_RoleData.PosttestAction = null;
            this.Add_RoleData.PretestAction = null;
            this.Add_RoleData.TestAction = Add_Role_TestAction;
            // 
            // Add_Role_TestAction
            // 
            Add_Role_TestAction.Conditions.Add(scalarValueCondition3);
            resources.ApplyResources(Add_Role_TestAction, "Add_Role_TestAction");
            // 
            // scalarValueCondition3
            // 
            scalarValueCondition3.ColumnNumber = 1;
            scalarValueCondition3.Enabled = true;
            scalarValueCondition3.ExpectedValue = "3";
            scalarValueCondition3.Name = "scalarValueCondition3";
            scalarValueCondition3.NullExpected = false;
            scalarValueCondition3.ResultSet = 1;
            scalarValueCondition3.RowNumber = 1;
            // 
            // rowCountCondition22
            // 
            rowCountCondition22.Enabled = true;
            rowCountCondition22.Name = "rowCountCondition22";
            rowCountCondition22.ResultSet = 1;
            rowCountCondition22.RowCount = 2;
            // 
            // rowCountCondition23
            // 
            rowCountCondition23.Enabled = true;
            rowCountCondition23.Name = "rowCountCondition23";
            rowCountCondition23.ResultSet = 1;
            rowCountCondition23.RowCount = 9;
            // 
            // rowCountCondition24
            // 
            rowCountCondition24.Enabled = true;
            rowCountCondition24.Name = "rowCountCondition24";
            rowCountCondition24.ResultSet = 1;
            rowCountCondition24.RowCount = 8;
            // 
            // scalarValueCondition5
            // 
            scalarValueCondition5.ColumnNumber = 1;
            scalarValueCondition5.Enabled = true;
            scalarValueCondition5.ExpectedValue = "5";
            scalarValueCondition5.Name = "scalarValueCondition5";
            scalarValueCondition5.NullExpected = false;
            scalarValueCondition5.ResultSet = 1;
            scalarValueCondition5.RowNumber = 1;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void Remove_Account_Permission()
        {
            SqlDatabaseTestActions testActions = this.Remove_Account_PermissionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_Account()
        {
            SqlDatabaseTestActions testActions = this.Delete_AccountData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Create_New_Account()
        {
            SqlDatabaseTestActions testActions = this.Create_New_AccountData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_Points_Account()
        {
            SqlDatabaseTestActions testActions = this.Add_Points_AccountData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_Article()
        {
            SqlDatabaseTestActions testActions = this.Delete_ArticleData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_Article()
        {
            SqlDatabaseTestActions testActions = this.Add_ArticleData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Update_Article_TagName()
        {
            SqlDatabaseTestActions testActions = this.Update_Article_TagNameData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_InterestTag()
        {
            SqlDatabaseTestActions testActions = this.Delete_InterestTagData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_InterestTag()
        {
            SqlDatabaseTestActions testActions = this.Add_InterestTagData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_Account_SecurityAnswer()
        {
            SqlDatabaseTestActions testActions = this.Delete_Account_SecurityAnswerData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_Account_SecurityAnswer()
        {
            SqlDatabaseTestActions testActions = this.Add_Account_SecurityAnswerData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Update_Account_SecurityAnswer()
        {
            SqlDatabaseTestActions testActions = this.Update_Account_SecurityAnswerData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_SecurityQuestion()
        {
            SqlDatabaseTestActions testActions = this.Delete_SecurityQuestionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_SecurityQuestion()
        {
            SqlDatabaseTestActions testActions = this.Add_SecurityQuestionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Update_SecurityQuestion()
        {
            SqlDatabaseTestActions testActions = this.Update_SecurityQuestionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_User()
        {
            SqlDatabaseTestActions testActions = this.Delete_UserData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_User()
        {
            SqlDatabaseTestActions testActions = this.Add_UserData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Update_User_FirstName()
        {
            SqlDatabaseTestActions testActions = this.Update_User_FirstNameData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_User_ZipLocation()
        {
            SqlDatabaseTestActions testActions = this.Delete_User_ZipLocationData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_User_ZipLocation()
        {
            SqlDatabaseTestActions testActions = this.Add_User_ZipLocationData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod(), ExpectedSqlException(MatchFirstError = false, Severity = 16, State = 0)]
        public void Create_Exist_Account()
        {
            SqlDatabaseTestActions testActions = this.Create_Exist_AccountData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Suspend_Account()
        {
            SqlDatabaseTestActions testActions = this.Suspend_AccountData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Change_Password()
        {
            SqlDatabaseTestActions testActions = this.Change_PasswordData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Change_Username()
        {
            SqlDatabaseTestActions testActions = this.Change_UsernameData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Update_Article_Description()
        {
            SqlDatabaseTestActions testActions = this.Update_Article_DescriptionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Update_Article_Title()
        {
            SqlDatabaseTestActions testActions = this.Update_Article_TitleData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Update_User_LastName()
        {
            SqlDatabaseTestActions testActions = this.Update_User_LastNameData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Update_User_Address()
        {
            SqlDatabaseTestActions testActions = this.Update_User_AddressData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Update_User_City()
        {
            SqlDatabaseTestActions testActions = this.Update_User_CityData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Update_User_State()
        {
            SqlDatabaseTestActions testActions = this.Update_User_StateData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Delete_LinkedIn_Token()
        {
            SqlDatabaseTestActions testActions = this.Delete_LinkedIn_TokenData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_LinkedIn_Token()
        {
            SqlDatabaseTestActions testActions = this.Add_LinkedIn_TokenData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod(), ExpectedSqlException(MatchFirstError = false, Severity = 16, State = 0)]
        public void Create_Account_Existing_Email()
        {
            SqlDatabaseTestActions testActions = this.Create_Account_Existing_EmailData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Delete_JWT()
        {
            SqlDatabaseTestActions testActions = this.Delete_JWTData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_JWT_Token()
        {
            SqlDatabaseTestActions testActions = this.Add_JWT_TokenData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Delete_Salt()
        {
            SqlDatabaseTestActions testActions = this.Delete_SaltData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_Password_Salt()
        {
            SqlDatabaseTestActions testActions = this.Add_Password_SaltData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        [TestMethod()]
        public void Delete_Permission_From_List()
        {
            SqlDatabaseTestActions testActions = this.Delete_Permission_From_ListData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_Permission()
        {
            SqlDatabaseTestActions testActions = this.Add_PermissionData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Delete_Role()
        {
            SqlDatabaseTestActions testActions = this.Delete_RoleData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void Add_Role()
        {
            SqlDatabaseTestActions testActions = this.Add_RoleData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
















        private SqlDatabaseTestActions Remove_Account_PermissionData;
        private SqlDatabaseTestActions Delete_AccountData;
        private SqlDatabaseTestActions Create_New_AccountData;
        private SqlDatabaseTestActions Add_Points_AccountData;
        private SqlDatabaseTestActions Delete_ArticleData;
        private SqlDatabaseTestActions Add_ArticleData;
        private SqlDatabaseTestActions Update_Article_TagNameData;
        private SqlDatabaseTestActions Delete_InterestTagData;
        private SqlDatabaseTestActions Add_InterestTagData;
        private SqlDatabaseTestActions Delete_Account_SecurityAnswerData;
        private SqlDatabaseTestActions Add_Account_SecurityAnswerData;
        private SqlDatabaseTestActions Update_Account_SecurityAnswerData;
        private SqlDatabaseTestActions Delete_SecurityQuestionData;
        private SqlDatabaseTestActions Add_SecurityQuestionData;
        private SqlDatabaseTestActions Update_SecurityQuestionData;
        private SqlDatabaseTestActions Delete_UserData;
        private SqlDatabaseTestActions Add_UserData;
        private SqlDatabaseTestActions Update_User_FirstNameData;
        private SqlDatabaseTestActions Delete_User_ZipLocationData;
        private SqlDatabaseTestActions Add_User_ZipLocationData;
        private SqlDatabaseTestActions Create_Exist_AccountData;
        private SqlDatabaseTestActions Suspend_AccountData;
        private SqlDatabaseTestActions Change_PasswordData;
        private SqlDatabaseTestActions Change_UsernameData;
        private SqlDatabaseTestActions Update_Article_DescriptionData;
        private SqlDatabaseTestActions Update_Article_TitleData;
        private SqlDatabaseTestActions Update_User_LastNameData;
        private SqlDatabaseTestActions Update_User_AddressData;
        private SqlDatabaseTestActions Update_User_CityData;
        private SqlDatabaseTestActions Update_User_StateData;
        private SqlDatabaseTestActions Delete_LinkedIn_TokenData;
        private SqlDatabaseTestActions Add_LinkedIn_TokenData;
        private SqlDatabaseTestActions Create_Account_Existing_EmailData;
        private SqlDatabaseTestActions Delete_JWTData;
        private SqlDatabaseTestActions Add_JWT_TokenData;
        private SqlDatabaseTestActions Delete_SaltData;
        private SqlDatabaseTestActions Add_Password_SaltData;
        private SqlDatabaseTestActions Delete_Permission_From_ListData;
        private SqlDatabaseTestActions Add_PermissionData;
        private SqlDatabaseTestActions Delete_RoleData;
        private SqlDatabaseTestActions Add_RoleData;
    }
}
