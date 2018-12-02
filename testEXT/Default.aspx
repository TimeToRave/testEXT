<%@ Page Language="C#" %>

<%@ Import Namespace="testEXT.Classes" %>
<%@ Import Namespace="System.Collections.ObjectModel" %>
<%@ Import Namespace="System.Collections.Generic" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BindData();
        }
    }

    protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
    {
        this.BindData();
    }

    private void BindData()
    {

        object[] salesInObject = Controller.GetAllData();
        this.Store1.DataSource = salesInObject;
        Store1.DataBind();

        Agent[] allAgents = Controller.GetAllAgents();
        object[] tempAgents = new object[allAgents.Length];
        for (int i = 0; i < allAgents.Length; i++)
        {
            tempAgents[i] = allAgents[i].ToObject();
        }

        this.AgentSB.GetStore().DataSource = tempAgents;

        Contact[] allContacts = Controller.GetAllContacts();
        object[] tempContacts = new object[allContacts.Length];
        for (int i = 0; i < allContacts.Length; i++)
        {
            tempContacts[i] = allContacts[i].ToObject();
        }
        this.ContactClientSB.GetStore().DataSource = tempContacts;


    }

    [DirectMethod]
    public void DeleteButtonClick(int id)
    {

        Controller.DeleteSale(id);
        this.BindData();
    }

    [DirectMethod]
    public void EditButtonClick(int id, string name, string agent, string contactClient)
    {
        Sale tempSale = new Sale (id, name, agent, contactClient);
        Controller.UpdateSale(tempSale);
        this.BindData();
    }

    [DirectMethod]
    public void CreateButtonClick()
    {
        
        Controller.CreateSale(new Sale());
        this.BindData();
    }

    [DirectMethod]
    public void CopyButtonClick(int id, string name, string agent, string contactClient)
    {
        
        Controller.CreateSale(new Sale (id, name, agent, contactClient));
        this.BindData();
    }

</script>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Simple Array Grid - Ext.NET Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />
</head>
<body>
    <ext:ResourceManager runat="server" />

    <h1 align="center">Тестовое задание. Выполнил Кузьмин Николай</h1>

    <ext:GridPanel
        ID="MainGridPanel"
        runat="server"
        Title="Продажи"
        Frame="false"
        Layout="FitLayout">
        <Store>
            <ext:Store ID="Store1"  runat="server" OnReadData="MyData_Refresh">
                <Model>
                    <ext:Model runat="server" Name="Sale">
                        <Fields>
                            <ext:ModelField Name="Id" />
                            <ext:ModelField Name="SaleName" />
                            <ext:ModelField Name="Agent" />
                            <ext:ModelField Name="AgentCity"  />
                            <ext:ModelField Name="ContactClient"  />
                            <ext:ModelField Name="ContactSalesman"  />
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>

        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                     <ext:Button runat="server" Text="Добавить новую продажу">
                         <Listeners>
                            <Click Handler="App.direct.CreateButtonClick()" />
                            </Listeners>
                         </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>

        <ColumnModel runat="server">
            <Columns>
                 
                <ext:Column runat="server" Text="№" DataIndex="Id" Flex="1"></ext:Column>
                <ext:Column runat="server" Text="Название продажи" DataIndex="SaleName" Flex="1">
                    <Editor>
                            <ext:TextField AllowBlank="false" runat="server" />
                    </Editor>
                    <Commands>
                            <ext:ImageCommand CommandName="Edit" Icon="NoteEdit" >
                                <ToolTip Text="Кликните на ячейку дважды для редактирования" />
                            </ext:ImageCommand>
                    </Commands>
                </ext:Column>
                <ext:Column runat="server" Text="Клиент-организация" DataIndex="Agent" Flex="1" >
                    <Editor>
                        <ext:SelectBox
                            ID="AgentSB"
                            runat="server"
                            DisplayField="client"
                            ValueField="client"
                            EmptyText="Выберите клиента-организацию"
                            AllowBlank ="true">                            
                            <Store>
                                <ext:Store runat="server">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="id" />
                                                <ext:ModelField Name="client" />
                                                <ext:ModelField Name="cityId" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                    </Editor>
                    <Commands>
                            <ext:ImageCommand CommandName="Edit" Icon="NoteEdit">
                                <ToolTip Text="Кликните на ячейку дважды для редактирования" />
                            </ext:ImageCommand>
                    </Commands>
                </ext:Column>
                <ext:Column runat="server" Text="Город клиента" DataIndex="AgentCity" Flex="1"></ext:Column>
                <ext:Column runat="server" Text="Контактное лицо" DataIndex="ContactClient" Flex="1">
                    <Editor>
                        <ext:SelectBox
                            ID="ContactClientSB"
                            runat="server"
                            DisplayField="client"
                            ValueField="client"
                            EmptyText="Выберите контактное лицо"
                            AllowBlank ="true">
                            <Store>
                                <ext:Store runat="server">
                                    <Model>
                                        <ext:Model runat="server">
                                            <Fields>
                                                <ext:ModelField Name="id" />
                                                <ext:ModelField Name="client" />
                                                <ext:ModelField Name="salesman" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:SelectBox>
                    </Editor>
                    <Commands>
                            <ext:ImageCommand CommandName="Edit" Icon="NoteEdit">
                                <ToolTip Text="Кликните на ячейку дважды для редактирования" />
                            </ext:ImageCommand>
                    </Commands>
                </ext:Column>
                <ext:Column runat="server" Text="Ответственный за продажу" DataIndex="ContactSalesman" Flex="1"></ext:Column>
                
                
                <ext:WidgetColumn runat="server" Width="60" DataIndex="Delete">
                    <Widget>
                        <ext:Button runat="server" Width="50" Text="Сохранить" Icon="TableSave" TextAlign="Center" ToolTip="Сохранить изменения" ToolTipType="Title">
                            <Listeners>
                                <Click Handler="App.direct.EditButtonClick(
                                                                        this.getWidgetRecord().get('Id'),
                                                                        this.getWidgetRecord().get('SaleName'),
                                                                        this.getWidgetRecord().get('Agent'),
                                                                        this.getWidgetRecord().get('ContactClient')
                                                                       )" />
                            </Listeners>
                    </ext:Button>
                    </Widget>
                </ext:WidgetColumn>

                <ext:WidgetColumn runat="server" Width="60" DataIndex="Delete" >
                    <Widget>
                        <ext:Button runat="server" Width="50" Icon="Delete" >
                            <Listeners>
                            <Click Handler="App.direct.DeleteButtonClick(this.getWidgetRecord().get('Id'))" />
                            </Listeners>
                    </ext:Button>
                    </Widget>
                </ext:WidgetColumn>

                <ext:WidgetColumn runat="server" Width="60" DataIndex="Copy" >
                    <Widget>
                        <ext:Button runat="server" Width="50" Icon="DatabaseCopy" >
                            <Listeners>
                            <Click Handler="App.direct.CopyButtonClick(
                                                                        this.getWidgetRecord().get('Id'),
                                                                        this.getWidgetRecord().get('SaleName'),
                                                                        this.getWidgetRecord().get('Agent'),
                                                                        this.getWidgetRecord().get('ContactClient')
                                                                    )" />
                            </Listeners>
                    </ext:Button>
                    </Widget>
                </ext:WidgetColumn>
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel runat="server" />
        </SelectionModel>
        <Plugins>
            <ext:CellEditing runat="server" ClicksToEdit="1" />
        </Plugins>
    </ext:GridPanel>
</body>
</html>