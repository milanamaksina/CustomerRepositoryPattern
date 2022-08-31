<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressList.aspx.cs" Inherits="CustomerRepositoryPattern.WebForms.AddressList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 class="text-center"><%=Title %></h1>

    <table ID="addressesTable" class="table text-center">
        <thead>
            <tr>
                <th class="text-center">Address Id</th>
                <th class="text-center">Customer Id</th>
                <th class="text-center">Address Line</th>
                <th class="text-center">Address Line 2</th>
                <th class="text-center">Address Type</th>
                <th class="text-center">City</th>
                <th class="text-center">Postal Code</th>
                <th class="text-center">State</th>
                <th class="text-center">Country</th>
                <th class="text-center"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></th>
            </tr>
        </thead>
        <tbody>
            <%foreach (var address in Addresses)
                {%>
                    <tr>
                        <td><%=address.AddressId %></td>
                        <td><%=address.CustomerId %></td>
                        <td><%=address.AddressLine %></td>
                        <td><%=address.AddressLine2 %></td>
                        <td><%=address.AddressType %></td>
                        <td><%=address.City %></td>
                        <td><%=address.PostalCode %></td>
                        <td><%=address.State %></td>
                        <td><%=address.Country %></td>
                        <td><a class="btn btn-default" href="AddressEdit.aspx?addressId=<%=address.AddressId %>">Edit</a></td>
                        <td><a class="btn btn-danger" href="AddressDelete.aspx?addressId=<%=address.AddressId %>">Delete</a></td>
                    </tr>
            <%} %>
        </tbody>
    </table>
     <div class="text-center">
        <a runat="server" class="btn btn-success" href="AddressEdit.aspx">Add new address</a>
        <a class="btn btn-danger" href="AddressDeleteAll.aspx">Delete All</a>
    </div>

</asp:Content>
