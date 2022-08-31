<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerRepositoryPattern.WebForms.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h1 class="text-center"><%=Title %></h1>
    <table class="table text-center">
        <thead>
            <tr>
                <th class="text-center">Customer Id</th>
                <th class="text-center">First name</th>
                <th class="text-center">Last name</th>
                <th class="text-center">Phone number</th>
                <th class="text-center">Email</th>
                <th class="text-center">Notes</th>
                <th class="text-center">Total Purchases Amount</th>
                <th class="text-center"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></th>
            </tr>
        </thead>
        <tbody>
            <%foreach(var customer in Customers) 
                {%>
                    <tr>
                        <td><%=customer.CustomerId%></td>
                        <td><%=customer.FirstName%></td>
                        <td><%=customer.LastName%></td>
                        <td><%=customer.PhoneNumber%></td>
                        <td><%=customer.Email%></td>
                        <td><%=customer.Notes%></td>
                        <td><%=customer.TotalPurchasesAmount%></td>
                        <td><a class="btn btn-default" href="CustomerEdit.aspx?customerId=<%=customer.CustomerId %>">Edit</a></td>
                        <td><a class="btn btn-default" href="CustomerDelete.aspx?customerId=<%=customer.CustomerId %>">Delete</a></td>
                    </tr>
                <%} %>
        </tbody>
    </table>
    <div class="text-center">
        <a runat="server" class="btn btn-warning" href="~/CustomerEdit">Add customer</a>
        <a class="btn btn-warning" href="CustomerDeleteAll.aspx">Delete All</a>
    </div>

</asp:Content>
