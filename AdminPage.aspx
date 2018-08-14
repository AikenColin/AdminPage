<%@ Page Title="Kristal Bell Method" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/K-Bell.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebApplication1.AdminPage" %>

<%--<%@ Page Title="" Language="C#" MasterPageFile="~/KBell.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebApplication1.AdminPage" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="scanlines"></div>
    <div id="AdminLogin" runat="server" style="display:block" class="pricing-wrapper">
        <div id="WrongUser" runat="server" style="display: none"><p>Incorrect Username</p></div>
        <div id="WrongPassword" runat="server" style="display: none"><p>Incorrect Password</p></div>
        <div id="WrongLogin" runat="server" style="display: none"><p><br />Please check your information and try again.<br /></p></div>
        <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Username</asp:Label>
            <asp:Textbox runat="server" id="txtUser" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Password</asp:Label>
            <asp:Textbox runat="server" id="txtPassword" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-indent:3px"></asp:Textbox>         
            <asp:Button BackColor="#2d444e" runat="server" ID="LogIn" Text="Login" OnClick="LogIn_Click" CssClass="contact-button" />
        </div>


    <div id="Admin" runat="server" style="display:none" class="pricing-wrapper">

        <asp:Button runat="server" ID="UpdateLogin" Text="Update Username / Password" Visible="true" OnClick="UpdateLogin_Click" CssClass="contact-button2" /><br />
        <div id="DisplayLogin" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">            
          <p style="color:#2B3856; line-height:110%; padding-left:10px; padding-right:10px; font-style:italic; font-weight:500">This is the login Username and Password used to access Admin Page.</p>
            <div runat="server" style="display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">     
            <div id="NoInfo" runat="server" class="comment-box" style="display: none"><p>No Info Entered</p></div>
            <asp:Repeater ID="RepeatLogin" runat="server">
                <ItemTemplate>
                    <div id="displayCurrentLogin" runat="server" class="comment-box" style="margin-bottom:7px">
                        <asp:Label runat="server" ID="lb1" ForeColor="#2d444e" Font-Bold="true">Current Username</asp:Label>
                        <p id="UpUser" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("Username")%></p>
                        <asp:Label runat="server" ID="lb2" ForeColor="#2d444e" Font-Bold="true">Current Password</asp:Label>
                        <p id="UpPass" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("Password")%></p>
                         </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSourceLogin" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblLogin]"></asp:SqlDataSource>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New Username</asp:Label>
            <asp:Textbox runat="server" id="tbUpUser" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New Password</asp:Label>
            <asp:Textbox runat="server" id="tbUpPass" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-indent:3px"></asp:Textbox>
            <asp:Button BackColor="#2d444e" runat="server" ID="UpdateLoginInfo" Text="Submit New Login Credentials" OnClick="UpdateLoginInfo_Click" CssClass="contact-button" />
        </div>
            </div>

        <asp:Button runat="server" ID="btnSalesMsg" Text="Sales / Holiday Banner" Visible="true" OnClick="btnSalesMsg_Click" CssClass="contact-button2" /><br />
        <div id="SalesDisplay" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
         <p style="color:#2B3856; line-height:120%; padding-left:10px; padding-right:10px; font-style:italic; font-weight:500">This message will be displayed toward the top of every page. Useful for displaying Sales, Promotions, Happy Holidays message, etc. Text will update when this button is closed.</p>
            <div runat="server" style="display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Current Sales Message</asp:Label>
            <div id="emptyMessage" runat="server" class="comment-box" style="display: none"><p>No Message</p></div>
            <asp:Repeater ID="Repeat" runat="server">
                <ItemTemplate>
                    <div id="displayCurrentSales" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p id="showStuff" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("CurrentSales")%></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Button BackColor="#2d444e" runat="server" ID="clearMessage" Text="Clear Current Message" OnClick="clearMessage_Click" CssClass="contact-button" />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblSales]"></asp:SqlDataSource>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New Sales Message</asp:Label>
            <textarea runat="server" id="txtSales1" class="contact-tb1" style="margin-bottom:0px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></textarea>
            <asp:Button BackColor="#2d444e" runat="server" ID="submitSales" Text="Submit New Message" OnClick="submitSales_Click" CssClass="contact-button" />
        </div>
            </div>

        <asp:Button runat="server" ID="btnContactMsg" Text="Contact Us Message" Visible="true" OnClick="btnContactMsg_Click" CssClass="contact-button2" /><br />
        <div id="ContactDisplay" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
        <p style="color:#2B3856; line-height:110%; padding-left:10px; padding-right:10px; font-style:italic; font-weight:500">This message will be displayed toward the top of "Contact Us" boxes. Useful to display information on holiday hours, phone problems, etc.</p>
            <div runat="server" style="display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">    
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Current Contact Message</asp:Label>
            <div id="emptyMessage2" runat="server" class="comment-box" style="display: none"><p>No Message</p></div>
            <asp:Repeater ID="Repeat1" runat="server">
                <ItemTemplate>
                    <div id="displayCurrentContact" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p id="showStuff2" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("CurrentContact")%></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Button BackColor="#2d444e" runat="server" ID="clearMessage2" Text="Clear Current Message" OnClick="clearMessage2_Click" CssClass="contact-button" />
            <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblContactMessage]"></asp:SqlDataSource>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New Contact Message</asp:Label>
            <textarea runat="server" id="txtContact1" class="contact-tb1" style="margin-bottom:0px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></textarea>
            <asp:Button BackColor="#2d444e" runat="server" ID="submitContact" Text="Submit New Message" OnClick="submitContact_Click" CssClass="contact-button" />
        </div>
            </div>

        <asp:Button runat="server" ID="BellPricing" Text="Product Pricing" Visible="true" OnClick="BellPricing_Click" CssClass="contact-button2" /><br />
        <div id="DisplayPricing" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">            
          <p style="color:#2B3856; line-height:110%; padding-left:10px; padding-right:10px; font-style:italic; font-weight:500">These are the prices located on the Pricing page. Changing prices here will update on the Pricing page. Only enter digits, "$" will generate automatically. </p>
            <div runat="server" style="display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">     
            <div id="NoPrice" runat="server" class="comment-box" style="display: none"><p>No Price Entered</p></div>
            <asp:Repeater ID="RepeatPrice" runat="server">
                <ItemTemplate>
                    <div id="displayCurrentPrice" runat="server" class="comment-box" style="margin-bottom:7px">
                        <asp:Label runat="server" ID="lb1" ForeColor="#2d444e" Font-Bold="true">Set of Handbells</asp:Label>
                        <p id="MainEmail" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;">$<%#Eval("bells")%></p>
                        <asp:Label runat="server" ID="lb2" ForeColor="#2d444e" Font-Bold="true">Starter Kit</asp:Label>
                        <p id="Password" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;">$<%#Eval("kits")%></p>
                        <asp:Label runat="server" ID="lb3" ForeColor="#2d444e" Font-Bold="true">CD with Cards</asp:Label>
                        <p id="CopyToEmail" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;">$<%#Eval("music")%></p>
                        <asp:Label runat="server" ID="lb4" ForeColor="#2d444e" Font-Bold="true">Additional CD's</asp:Label>
                        <p id="CopyToEmail2" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;">$<%#Eval("cds")%></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSourcePrice" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblPricing]"></asp:SqlDataSource>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Set of Handbells</asp:Label>
            <asp:Textbox runat="server" id="tbBells" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Starter Kit</asp:Label>
            <asp:Textbox runat="server" id="tbKits" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">CD with Cards</asp:Label>
            <asp:Textbox runat="server" id="tbMusic" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Additional CD's</asp:Label>
            <asp:Textbox runat="server" id="tbCDs" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>         
            <asp:Button BackColor="#2d444e" runat="server" ID="PriceUpdate" Text="Submit New Pricing" OnClick="PriceUpdate_Click" CssClass="contact-button" />
        </div>
            </div>

        <asp:Button runat="server" ID="CommentsEdit" Text="Comments Editing" Visible="true" OnClick="btnCommentsEdit_Click" CssClass="contact-button2" /><br />
        <div id="CommentDisplay" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
        <p style="color:#2B3856; line-height:110%; padding-left:10px; padding-right:10px; font-style:italic; font-weight:500; margin-bottom:4px">Delete unwanted comments, or restore deleted comments.</p>    
            <%--<asp:Button runat="server" ID="DeletedComments" Text="View Deleted Comments" Visible="true" OnClick="DeletedComments_Click" CssClass="contact-button" /><br />
        --%><div id="DeletedCommentDisplay" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Deleted Comments</asp:Label>
            <div id="deleteMessage" runat="server" class="comment-box" style="display: none"><p>No Deleted Comments</p></div>
            <asp:Repeater ID="RepeatDelete" runat="server" OnItemCommand="RepeatDelete_ItemCommand">
                <ItemTemplate>                   
                    <div id="displayDeletedComment" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p style="font-style:italic; font-size:15.5px; font-weight:300; text-shadow:1.2px 0 #2d444e;"> <%#Eval("comment")%></p>
                           <br />
                         <p style="font-style:italic; font-size:16.5px; font-weight:500; text-shadow:1.2px 0 #2d444e;"> <%#Eval("name")%><br />
                                <%#Eval("location")%></p>
                        <p style="display:none"> <%#Eval("id")%></p>                         
                        <asp:LinkButton BackColor="#2d444e" ID="deleteComment" Text="Restore Comment" OnClientClick="" CssClass="contact-button" CommandName="RestoreCom" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblComments] WHERE (deleted = 'true') ORDER BY ID DESC;"></asp:SqlDataSource>
            </div>
            <asp:Button runat="server" ID="DeletedComments" Text="View Deleted Comments" Visible="true" OnClick="DeletedComments_Click" CssClass="contact-button" /><br />
        
            <%--<br />--%>
            <div runat="server" style="display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
     
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Active Comments</asp:Label>
            <asp:Repeater ID="Repeat2" runat="server" OnItemCommand="Repeat2_ItemCommand">
                <ItemTemplate>
                    <div id="displayCurrentComment" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p style="font-style:italic; font-size:15.5px; font-weight:300; text-shadow:1.2px 0 #2d444e;"> <%#Eval("comment")%></p>
                           <br />
                         <p style="font-style:italic; font-size:16.5px; font-weight:500; text-shadow:1.2px 0 #2d444e;"> <%#Eval("name")%><br />
                                <%#Eval("location")%></p>
                        <p style="display:none"> <%#Eval("id")%></p>                         
                        <asp:LinkButton BackColor="#2d444e" ID="deleteComment" Text="Delete Comment" OnClientClick="deleteComment_Click" CssClass="contact-button" CommandName="deleteCom" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%--<br />--%>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblComments] WHERE (deleted = 'false') ORDER BY ID DESC;"></asp:SqlDataSource>
            </div>
            </div>

        <asp:Button runat="server" ID="SongEdit" Text="Songs List Editing" Visible="true" OnClick="btnSongEdit_Click" CssClass="contact-button2" />
        <div id="SongDisplay" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
        <p style="color:#2B3856; line-height:110%; padding-left:10px; padding-right:10px; font-style:italic; font-weight:500">Add new songs or remove old ones. Christmas Songs are listed on complete list as well as the Christmas list.</p>
            <div runat="server" style="display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">        
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New Song Title</asp:Label>
            <asp:Textbox runat="server" id="txtSong" class="contact-tb1" style="margin-bottom:0px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>
            <asp:Button BackColor="#2d444e" runat="server" ID="btnNewSong" Text="Submit New Song" OnClick="btnNewSong_Click" CssClass="contact-button" />
            <br />
            <br />
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New Christmas Song Title</asp:Label>
            <asp:Textbox runat="server" id="txtChristmas" class="contact-tb1" style="margin-bottom:0px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>
            <asp:Button BackColor="#2d444e" runat="server" ID="btnChristmasSong" Text="Submit New Christmas Song" OnClick="btnChristmasSong_Click" CssClass="contact-button" />
            <br />
            <br />
            <asp:Button BackColor="#2d444e" runat="server" ID="btnAllSongs" Text="View All Songs" OnClick="btnAllSongs_Click" CssClass="contact-button" />
            <div id="DisplayAllSongs" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;">
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">All Songs</asp:Label>
            <asp:Repeater ID="Repeat4" runat="server" OnItemCommand="Repeat4_ItemCommand">
                <ItemTemplate>
                    <div id="displayAllSongs" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p style="font-style:italic; font-size:15.5px; font-weight:300; text-shadow:1.2px 0 #2d444e;"> <%#Eval("song")%></p>
                        <p style="display:none"> <%#Eval("id")%></p>                         
                        <asp:LinkButton BackColor="#2d444e" ID="deleteSong" Text="Delete Song" OnClientClick="" CssClass="contact-button" CommandName="deleteSon" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblSongs] WHERE (deleted = 'false') ORDER BY SONG ASC;"></asp:SqlDataSource>
            </div>

            <%--<asp:Button runat="server" ID="DeletedSongs" Text="View Deleted Songs" Visible="true" OnClick="DeletedSongs_Click" CssClass="contact-button" /><br />
        --%><div id="DeletedSongDisplay" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Deleted Songs</asp:Label>
            <div id="deleteMessage1" runat="server" class="comment-box" style="display: none"><p>No Deleted Songs</p></div>
            <asp:Repeater ID="RepeatDelete2" runat="server" OnItemCommand="RepeatDelete2_ItemCommand">
                <ItemTemplate>                   
                    <div id="displayDeletedSong" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p style="font-style:italic; font-size:15.5px; font-weight:300; text-shadow:1.2px 0 #2d444e;"> <%#Eval("song")%></p>
                        <p style="display:none"> <%#Eval("id")%></p>                         
                        <asp:LinkButton BackColor="#2d444e" ID="restoreSong" Text="Restore Song" OnClientClick="" CssClass="contact-button" CommandName="RestoreSon" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblSongs] WHERE (deleted = 'true') ORDER BY ID DESC;"></asp:SqlDataSource>
            </div>
                <asp:Button runat="server" ID="DeletedSongs" Text="View Deleted Songs" Visible="true" OnClick="DeletedSongs_Click" CssClass="contact-button" /><br />
        
            <br />

            <asp:Button BackColor="#2d444e" runat="server" ID="btnChristmasSongs" Text="View Christmas Songs" OnClick="btnChristmasSongs_Click" CssClass="contact-button" />
            <div id="DisplayChristmasSongs" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;">
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Christmas Songs</asp:Label>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div id="displayChristmasSongs" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p style="font-style:italic; font-size:15.5px; font-weight:300; text-shadow:1.2px 0 #2d444e;"> <%#Eval("Csong")%></p>
                        <p style="display:none"> <%#Eval("id")%></p>                         
                        <asp:LinkButton BackColor="#2d444e" ID="deleteChristmas" Text="Delete Song" OnClientClick="" CssClass="contact-button" CommandName="deleteCrs" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblChristmas] WHERE (deleted = 'false') ORDER BY CSONG ASC;"></asp:SqlDataSource>
            </div>

            <%--<asp:Button runat="server" ID="DeletedChristmas" Text="View Deleted Christmas Songs" Visible="true" OnClick="DeletedChristmas_Click" CssClass="contact-button" /><br />
        --%><div id="DeletedChristmasDisplay" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Deleted Christmas Songs</asp:Label>
            <div id="deleteMessage2" runat="server" class="comment-box" style="display: none"><p>No Deleted Songs</p></div>
            <asp:Repeater ID="RepeatDelete3" runat="server" OnItemCommand="RepeatDelete3_ItemCommand">
                <ItemTemplate>                   
                    <div id="displayDeletedChristmas" runat="server" class="comment-box" style="margin-bottom:7px">
                        <p style="font-style:italic; font-size:15.5px; font-weight:300; text-shadow:1.2px 0 #2d444e;"> <%#Eval("Csong")%></p>
                        <p style="display:none"> <%#Eval("id")%></p>                         
                        <asp:LinkButton BackColor="#2d444e" ID="restoreChristmas" Text="Restore Song" OnClientClick="" CssClass="contact-button" CommandName="RestoreCrs" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblChristmas] WHERE (deleted = 'true') ORDER BY ID DESC;"></asp:SqlDataSource>
            </div>
                <asp:Button runat="server" ID="DeletedChristmas" Text="View Deleted Christmas Songs" Visible="true" OnClick="DeletedChristmas_Click" CssClass="contact-button" /><br />
        
            <%--<br />--%>

            </div>
        </div>

        <asp:Button runat="server" ID="ContactEmail" Text="Web Message Emails" Visible="true" OnClick="btnContactEmail_Click" CssClass="contact-button2" /><br />
        <div id="DisplayEmail" runat="server" style="display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">            
          <p style="color:#2B3856; line-height:110%; padding-left:10px; padding-right:10px; font-style:italic; font-weight:500">These are the email addresses associated with the "Web Message" located on the Contact page. The "Sender" email will send the customer's message to the two added addresses. To reply to the customer by email, you will need to click their email address since the initial message will be from the "Sender" account. After the customer clicks send they will recieve an automated message from "Sender" account thanking them for contacting you.</p>
            <div runat="server" style="display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;" class="comment-box">     
            <div id="NoEmail" runat="server" class="comment-box" style="display: none"><p>No Email Info Entered</p></div>
            <asp:Repeater ID="Repeat3" runat="server">
                <ItemTemplate>
                    <div id="displayCurrentEmail" runat="server" class="comment-box" style="margin-bottom:7px">
                        <asp:Label runat="server" ID="lb1" ForeColor="#2d444e" Font-Bold="true">Current "Sender" Gmail Address</asp:Label>
                        <p id="MainEmail" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("PrimaryEmail")%></p>
                        <asp:Label runat="server" ID="lb2" ForeColor="#2d444e" Font-Bold="true">Current "Sender" Gmail Password</asp:Label>
                        <p id="Password" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("Password")%></p>
                        <asp:Label runat="server" ID="lb3" ForeColor="#2d444e" Font-Bold="true">Send Message to this Email Address</asp:Label>
                        <p id="CopyToEmail" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("CopyToEmail")%></p>
                        <asp:Label runat="server" ID="lb4" ForeColor="#2d444e" Font-Bold="true">Send Message to this Email Address</asp:Label>
                        <p id="CopyToEmail2" runat="server" style="font-style: italic; font-size: 15.5px; font-weight: 300; text-shadow: 1.2px 0 #2d444e;"><%#Eval("CopyToEmail2")%></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:KBellString%>" SelectCommand="SELECT * FROM [tblEmailLogin]"></asp:SqlDataSource>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New "Sender" Gmail Address</asp:Label>
            <asp:Textbox runat="server" id="tbGmail" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter New "Sender" Gmail Password</asp:Label>
            <asp:Textbox runat="server" id="tbPassword" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter Email Address to Receive Message</asp:Label>
            <asp:Textbox runat="server" id="tbSend" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>
            <asp:Label runat="server" ForeColor="#2d444e" Font-Bold="true">Enter Email Address to Receive Message</asp:Label>
            <asp:Textbox runat="server" id="tbCopy" class="contact-tb1" style="margin-bottom:10px; background-color:aquamarine; text-transform:capitalize; text-indent:3px"></asp:Textbox>         
            <asp:Button BackColor="#2d444e" runat="server" ID="EmailInfo" Text="Submit New Emails and Password" OnClick="EmailInfo_Click" CssClass="contact-button" />
        </div>
            </div>

    </div>
</asp:Content>
