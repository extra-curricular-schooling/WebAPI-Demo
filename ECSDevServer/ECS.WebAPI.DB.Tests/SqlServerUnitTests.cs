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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Give_Account_Permission_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Create_New_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Points_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Article_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Article_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Article_TagName_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_InterestTag_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_InterestTag_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_Account_SecurityAnswer_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_Account_SecurityAnswer_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Account_SecurityAnswer_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_SecurityQuestion_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_SecurityQuestion_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_SecurityQuestion_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_User_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_User_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_FirstName_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Delete_User_ZipLocation_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Add_User_ZipLocation_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_ZipCode_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Create_Exist_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Suspend_Account_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Change_Password_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Change_Username_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Article_Description_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_Article_Title_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition scalarValueCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_LastName_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition rowCountCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_Address_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_City_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Update_User_State_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition13;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition14;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition12;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition11;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition15;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition16;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition checksumCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition checksumCondition2;
            this.Remove_Account_PermissionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.Give_Account_PermissionData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
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
            this.Update_User_ZipCodeData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
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
            Remove_Account_Permission_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Give_Account_Permission_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Create_New_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_Points_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_Article_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_Article_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_Article_TagName_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_InterestTag_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_InterestTag_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_Account_SecurityAnswer_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_Account_SecurityAnswer_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_Account_SecurityAnswer_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_SecurityQuestion_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_SecurityQuestion_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_SecurityQuestion_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_User_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_User_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_User_FirstName_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Delete_User_ZipLocation_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Add_User_ZipLocation_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_User_ZipCode_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Create_Exist_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Suspend_Account_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Change_Password_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Change_Username_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            rowCountCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            notEmptyResultSetCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            Update_Article_Description_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_Article_Title_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            notEmptyResultSetCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            rowCountCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            scalarValueCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            rowCountCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            notEmptyResultSetCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            rowCountCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            notEmptyResultSetCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            rowCountCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Update_User_LastName_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            rowCountCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            rowCountCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            Update_User_Address_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_User_City_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            Update_User_State_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            notEmptyResultSetCondition13 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition14 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition12 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition11 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition15 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            notEmptyResultSetCondition16 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            checksumCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            checksumCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            // 
            // Remove_Account_Permission_TestAction
            // 
            Remove_Account_Permission_TestAction.Conditions.Add(rowCountCondition6);
            resources.ApplyResources(Remove_Account_Permission_TestAction, "Remove_Account_Permission_TestAction");
            // 
            // Give_Account_Permission_TestAction
            // 
            Give_Account_Permission_TestAction.Conditions.Add(notEmptyResultSetCondition4);
            resources.ApplyResources(Give_Account_Permission_TestAction, "Give_Account_Permission_TestAction");
            // 
            // Delete_Account_TestAction
            // 
            Delete_Account_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(Delete_Account_TestAction, "Delete_Account_TestAction");
            // 
            // Create_New_Account_TestAction
            // 
            Create_New_Account_TestAction.Conditions.Add(rowCountCondition3);
            resources.ApplyResources(Create_New_Account_TestAction, "Create_New_Account_TestAction");
            // 
            // Add_Points_Account_TestAction
            // 
            Add_Points_Account_TestAction.Conditions.Add(rowCountCondition4);
            resources.ApplyResources(Add_Points_Account_TestAction, "Add_Points_Account_TestAction");
            // 
            // Delete_Article_TestAction
            // 
            Delete_Article_TestAction.Conditions.Add(rowCountCondition7);
            resources.ApplyResources(Delete_Article_TestAction, "Delete_Article_TestAction");
            // 
            // Add_Article_TestAction
            // 
            Add_Article_TestAction.Conditions.Add(rowCountCondition2);
            resources.ApplyResources(Add_Article_TestAction, "Add_Article_TestAction");
            // 
            // Update_Article_TagName_TestAction
            // 
            Update_Article_TagName_TestAction.Conditions.Add(notEmptyResultSetCondition5);
            resources.ApplyResources(Update_Article_TagName_TestAction, "Update_Article_TagName_TestAction");
            // 
            // Delete_InterestTag_TestAction
            // 
            Delete_InterestTag_TestAction.Conditions.Add(rowCountCondition8);
            resources.ApplyResources(Delete_InterestTag_TestAction, "Delete_InterestTag_TestAction");
            // 
            // Add_InterestTag_TestAction
            // 
            Add_InterestTag_TestAction.Conditions.Add(notEmptyResultSetCondition7);
            resources.ApplyResources(Add_InterestTag_TestAction, "Add_InterestTag_TestAction");
            // 
            // Delete_Account_SecurityAnswer_TestAction
            // 
            Delete_Account_SecurityAnswer_TestAction.Conditions.Add(rowCountCondition10);
            resources.ApplyResources(Delete_Account_SecurityAnswer_TestAction, "Delete_Account_SecurityAnswer_TestAction");
            // 
            // Add_Account_SecurityAnswer_TestAction
            // 
            Add_Account_SecurityAnswer_TestAction.Conditions.Add(notEmptyResultSetCondition9);
            resources.ApplyResources(Add_Account_SecurityAnswer_TestAction, "Add_Account_SecurityAnswer_TestAction");
            // 
            // Update_Account_SecurityAnswer_TestAction
            // 
            Update_Account_SecurityAnswer_TestAction.Conditions.Add(notEmptyResultSetCondition10);
            resources.ApplyResources(Update_Account_SecurityAnswer_TestAction, "Update_Account_SecurityAnswer_TestAction");
            // 
            // Delete_SecurityQuestion_TestAction
            // 
            Delete_SecurityQuestion_TestAction.Conditions.Add(rowCountCondition9);
            resources.ApplyResources(Delete_SecurityQuestion_TestAction, "Delete_SecurityQuestion_TestAction");
            // 
            // Add_SecurityQuestion_TestAction
            // 
            Add_SecurityQuestion_TestAction.Conditions.Add(scalarValueCondition1);
            resources.ApplyResources(Add_SecurityQuestion_TestAction, "Add_SecurityQuestion_TestAction");
            // 
            // Update_SecurityQuestion_TestAction
            // 
            Update_SecurityQuestion_TestAction.Conditions.Add(notEmptyResultSetCondition8);
            resources.ApplyResources(Update_SecurityQuestion_TestAction, "Update_SecurityQuestion_TestAction");
            // 
            // Delete_User_TestAction
            // 
            Delete_User_TestAction.Conditions.Add(rowCountCondition12);
            resources.ApplyResources(Delete_User_TestAction, "Delete_User_TestAction");
            // 
            // Add_User_TestAction
            // 
            Add_User_TestAction.Conditions.Add(rowCountCondition11);
            resources.ApplyResources(Add_User_TestAction, "Add_User_TestAction");
            // 
            // Update_User_FirstName_TestAction
            // 
            Update_User_FirstName_TestAction.Conditions.Add(notEmptyResultSetCondition12);
            resources.ApplyResources(Update_User_FirstName_TestAction, "Update_User_FirstName_TestAction");
            // 
            // Delete_User_ZipLocation_TestAction
            // 
            Delete_User_ZipLocation_TestAction.Conditions.Add(rowCountCondition14);
            resources.ApplyResources(Delete_User_ZipLocation_TestAction, "Delete_User_ZipLocation_TestAction");
            // 
            // Add_User_ZipLocation_TestAction
            // 
            Add_User_ZipLocation_TestAction.Conditions.Add(rowCountCondition13);
            resources.ApplyResources(Add_User_ZipLocation_TestAction, "Add_User_ZipLocation_TestAction");
            // 
            // Update_User_ZipCode_TestAction
            // 
            Update_User_ZipCode_TestAction.Conditions.Add(notEmptyResultSetCondition16);
            Update_User_ZipCode_TestAction.Conditions.Add(checksumCondition1);
            resources.ApplyResources(Update_User_ZipCode_TestAction, "Update_User_ZipCode_TestAction");
            // 
            // Remove_Account_PermissionData
            // 
            this.Remove_Account_PermissionData.PosttestAction = null;
            this.Remove_Account_PermissionData.PretestAction = null;
            this.Remove_Account_PermissionData.TestAction = Remove_Account_Permission_TestAction;
            // 
            // Give_Account_PermissionData
            // 
            this.Give_Account_PermissionData.PosttestAction = null;
            this.Give_Account_PermissionData.PretestAction = null;
            this.Give_Account_PermissionData.TestAction = Give_Account_Permission_TestAction;
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
            // Update_User_ZipCodeData
            // 
            this.Update_User_ZipCodeData.PosttestAction = null;
            this.Update_User_ZipCodeData.PretestAction = null;
            this.Update_User_ZipCodeData.TestAction = Update_User_ZipCode_TestAction;
            // 
            // rowCountCondition2
            // 
            rowCountCondition2.Enabled = true;
            rowCountCondition2.Name = "rowCountCondition2";
            rowCountCondition2.ResultSet = 1;
            rowCountCondition2.RowCount = 1;
            // 
            // rowCountCondition3
            // 
            rowCountCondition3.Enabled = true;
            rowCountCondition3.Name = "rowCountCondition3";
            rowCountCondition3.ResultSet = 1;
            rowCountCondition3.RowCount = 1;
            // 
            // rowCountCondition4
            // 
            rowCountCondition4.Enabled = true;
            rowCountCondition4.Name = "rowCountCondition4";
            rowCountCondition4.ResultSet = 1;
            rowCountCondition4.RowCount = 1;
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 43;
            // 
            // Create_Exist_AccountData
            // 
            this.Create_Exist_AccountData.PosttestAction = null;
            this.Create_Exist_AccountData.PretestAction = null;
            this.Create_Exist_AccountData.TestAction = Create_Exist_Account_TestAction;
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
            // Suspend_AccountData
            // 
            this.Suspend_AccountData.PosttestAction = null;
            this.Suspend_AccountData.PretestAction = null;
            this.Suspend_AccountData.TestAction = Suspend_Account_TestAction;
            // 
            // Suspend_Account_TestAction
            // 
            Suspend_Account_TestAction.Conditions.Add(notEmptyResultSetCondition2);
            resources.ApplyResources(Suspend_Account_TestAction, "Suspend_Account_TestAction");
            // 
            // Change_PasswordData
            // 
            this.Change_PasswordData.PosttestAction = null;
            this.Change_PasswordData.PretestAction = null;
            this.Change_PasswordData.TestAction = Change_Password_TestAction;
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
            // notEmptyResultSetCondition2
            // 
            notEmptyResultSetCondition2.Enabled = true;
            notEmptyResultSetCondition2.Name = "notEmptyResultSetCondition2";
            notEmptyResultSetCondition2.ResultSet = 1;
            // 
            // Change_UsernameData
            // 
            this.Change_UsernameData.PosttestAction = null;
            this.Change_UsernameData.PretestAction = null;
            this.Change_UsernameData.TestAction = Change_Username_TestAction;
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
            // notEmptyResultSetCondition4
            // 
            notEmptyResultSetCondition4.Enabled = true;
            notEmptyResultSetCondition4.Name = "notEmptyResultSetCondition4";
            notEmptyResultSetCondition4.ResultSet = 1;
            // 
            // rowCountCondition6
            // 
            rowCountCondition6.Enabled = true;
            rowCountCondition6.Name = "rowCountCondition6";
            rowCountCondition6.ResultSet = 1;
            rowCountCondition6.RowCount = 147;
            // 
            // rowCountCondition7
            // 
            rowCountCondition7.Enabled = true;
            rowCountCondition7.Name = "rowCountCondition7";
            rowCountCondition7.ResultSet = 1;
            rowCountCondition7.RowCount = 49;
            // 
            // notEmptyResultSetCondition5
            // 
            notEmptyResultSetCondition5.Enabled = true;
            notEmptyResultSetCondition5.Name = "notEmptyResultSetCondition5";
            notEmptyResultSetCondition5.ResultSet = 1;
            // 
            // Update_Article_DescriptionData
            // 
            this.Update_Article_DescriptionData.PosttestAction = null;
            this.Update_Article_DescriptionData.PretestAction = null;
            this.Update_Article_DescriptionData.TestAction = Update_Article_Description_TestAction;
            // 
            // Update_Article_Description_TestAction
            // 
            Update_Article_Description_TestAction.Conditions.Add(notEmptyResultSetCondition6);
            resources.ApplyResources(Update_Article_Description_TestAction, "Update_Article_Description_TestAction");
            // 
            // Update_Article_TitleData
            // 
            this.Update_Article_TitleData.PosttestAction = null;
            this.Update_Article_TitleData.PretestAction = null;
            this.Update_Article_TitleData.TestAction = Update_Article_Title_TestAction;
            // 
            // Update_Article_Title_TestAction
            // 
            Update_Article_Title_TestAction.Conditions.Add(inconclusiveCondition2);
            resources.ApplyResources(Update_Article_Title_TestAction, "Update_Article_Title_TestAction");
            // 
            // inconclusiveCondition2
            // 
            inconclusiveCondition2.Enabled = true;
            inconclusiveCondition2.Name = "inconclusiveCondition2";
            // 
            // notEmptyResultSetCondition6
            // 
            notEmptyResultSetCondition6.Enabled = true;
            notEmptyResultSetCondition6.Name = "notEmptyResultSetCondition6";
            notEmptyResultSetCondition6.ResultSet = 1;
            // 
            // notEmptyResultSetCondition7
            // 
            notEmptyResultSetCondition7.Enabled = true;
            notEmptyResultSetCondition7.Name = "notEmptyResultSetCondition7";
            notEmptyResultSetCondition7.ResultSet = 1;
            // 
            // rowCountCondition8
            // 
            rowCountCondition8.Enabled = true;
            rowCountCondition8.Name = "rowCountCondition8";
            rowCountCondition8.ResultSet = 1;
            rowCountCondition8.RowCount = 10;
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
            // rowCountCondition9
            // 
            rowCountCondition9.Enabled = true;
            rowCountCondition9.Name = "rowCountCondition9";
            rowCountCondition9.ResultSet = 1;
            rowCountCondition9.RowCount = 3;
            // 
            // notEmptyResultSetCondition8
            // 
            notEmptyResultSetCondition8.Enabled = true;
            notEmptyResultSetCondition8.Name = "notEmptyResultSetCondition8";
            notEmptyResultSetCondition8.ResultSet = 1;
            // 
            // notEmptyResultSetCondition9
            // 
            notEmptyResultSetCondition9.Enabled = true;
            notEmptyResultSetCondition9.Name = "notEmptyResultSetCondition9";
            notEmptyResultSetCondition9.ResultSet = 1;
            // 
            // rowCountCondition10
            // 
            rowCountCondition10.Enabled = true;
            rowCountCondition10.Name = "rowCountCondition10";
            rowCountCondition10.ResultSet = 1;
            rowCountCondition10.RowCount = 146;
            // 
            // notEmptyResultSetCondition10
            // 
            notEmptyResultSetCondition10.Enabled = true;
            notEmptyResultSetCondition10.Name = "notEmptyResultSetCondition10";
            notEmptyResultSetCondition10.ResultSet = 1;
            // 
            // rowCountCondition11
            // 
            rowCountCondition11.Enabled = true;
            rowCountCondition11.Name = "rowCountCondition11";
            rowCountCondition11.ResultSet = 1;
            rowCountCondition11.RowCount = 51;
            // 
            // rowCountCondition12
            // 
            rowCountCondition12.Enabled = true;
            rowCountCondition12.Name = "rowCountCondition12";
            rowCountCondition12.ResultSet = 1;
            rowCountCondition12.RowCount = 50;
            // 
            // Update_User_LastNameData
            // 
            this.Update_User_LastNameData.PosttestAction = null;
            this.Update_User_LastNameData.PretestAction = null;
            this.Update_User_LastNameData.TestAction = Update_User_LastName_TestAction;
            // 
            // Update_User_LastName_TestAction
            // 
            Update_User_LastName_TestAction.Conditions.Add(notEmptyResultSetCondition11);
            resources.ApplyResources(Update_User_LastName_TestAction, "Update_User_LastName_TestAction");
            // 
            // rowCountCondition13
            // 
            rowCountCondition13.Enabled = true;
            rowCountCondition13.Name = "rowCountCondition13";
            rowCountCondition13.ResultSet = 1;
            rowCountCondition13.RowCount = 5;
            // 
            // rowCountCondition14
            // 
            rowCountCondition14.Enabled = true;
            rowCountCondition14.Name = "rowCountCondition14";
            rowCountCondition14.ResultSet = 1;
            rowCountCondition14.RowCount = 4;
            // 
            // Update_User_AddressData
            // 
            this.Update_User_AddressData.PosttestAction = null;
            this.Update_User_AddressData.PretestAction = null;
            this.Update_User_AddressData.TestAction = Update_User_Address_TestAction;
            // 
            // Update_User_Address_TestAction
            // 
            Update_User_Address_TestAction.Conditions.Add(notEmptyResultSetCondition13);
            resources.ApplyResources(Update_User_Address_TestAction, "Update_User_Address_TestAction");
            // 
            // Update_User_CityData
            // 
            this.Update_User_CityData.PosttestAction = null;
            this.Update_User_CityData.PretestAction = null;
            this.Update_User_CityData.TestAction = Update_User_City_TestAction;
            // 
            // Update_User_City_TestAction
            // 
            Update_User_City_TestAction.Conditions.Add(notEmptyResultSetCondition14);
            resources.ApplyResources(Update_User_City_TestAction, "Update_User_City_TestAction");
            // 
            // Update_User_StateData
            // 
            this.Update_User_StateData.PosttestAction = null;
            this.Update_User_StateData.PretestAction = null;
            this.Update_User_StateData.TestAction = Update_User_State_TestAction;
            // 
            // Update_User_State_TestAction
            // 
            Update_User_State_TestAction.Conditions.Add(notEmptyResultSetCondition15);
            Update_User_State_TestAction.Conditions.Add(checksumCondition2);
            resources.ApplyResources(Update_User_State_TestAction, "Update_User_State_TestAction");
            // 
            // notEmptyResultSetCondition13
            // 
            notEmptyResultSetCondition13.Enabled = true;
            notEmptyResultSetCondition13.Name = "notEmptyResultSetCondition13";
            notEmptyResultSetCondition13.ResultSet = 1;
            // 
            // notEmptyResultSetCondition14
            // 
            notEmptyResultSetCondition14.Enabled = true;
            notEmptyResultSetCondition14.Name = "notEmptyResultSetCondition14";
            notEmptyResultSetCondition14.ResultSet = 1;
            // 
            // notEmptyResultSetCondition12
            // 
            notEmptyResultSetCondition12.Enabled = true;
            notEmptyResultSetCondition12.Name = "notEmptyResultSetCondition12";
            notEmptyResultSetCondition12.ResultSet = 1;
            // 
            // notEmptyResultSetCondition11
            // 
            notEmptyResultSetCondition11.Enabled = true;
            notEmptyResultSetCondition11.Name = "notEmptyResultSetCondition11";
            notEmptyResultSetCondition11.ResultSet = 1;
            // 
            // notEmptyResultSetCondition15
            // 
            notEmptyResultSetCondition15.Enabled = true;
            notEmptyResultSetCondition15.Name = "notEmptyResultSetCondition15";
            notEmptyResultSetCondition15.ResultSet = 1;
            // 
            // notEmptyResultSetCondition16
            // 
            notEmptyResultSetCondition16.Enabled = true;
            notEmptyResultSetCondition16.Name = "notEmptyResultSetCondition16";
            notEmptyResultSetCondition16.ResultSet = 1;
            // 
            // checksumCondition1
            // 
            checksumCondition1.Checksum = null;
            checksumCondition1.Enabled = true;
            checksumCondition1.Name = "checksumCondition1";
            // 
            // checksumCondition2
            // 
            checksumCondition2.Checksum = "1115220217";
            checksumCondition2.Enabled = true;
            checksumCondition2.Name = "checksumCondition2";
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
        public void Give_Account_Permission()
        {
            SqlDatabaseTestActions testActions = this.Give_Account_PermissionData;
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

        [TestMethod()]
        public void Update_User_ZipCode()
        {
            SqlDatabaseTestActions testActions = this.Update_User_ZipCodeData;
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











        private SqlDatabaseTestActions Remove_Account_PermissionData;
        private SqlDatabaseTestActions Give_Account_PermissionData;
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
        private SqlDatabaseTestActions Update_User_ZipCodeData;
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
    }
}
