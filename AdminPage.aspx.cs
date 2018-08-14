using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseHelper;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OpenPop;
using OpenPop.Pop3;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Common;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class AdminPage : System.Web.UI.Page
    {
        string CurrentSales = string.Empty;
        string Sales = string.Empty;
        string Contact = string.Empty;
        string Comment = string.Empty;
        string Name = string.Empty;
        string Location = string.Empty;
        int ID = 0;
        string Deleted = string.Empty;
        string MainEmail = string.Empty;
        string Password = string.Empty;
        string CopyEmail = string.Empty;
        string CopyEmail2 = string.Empty;
        string Song = string.Empty;
        string Csong = string.Empty;
        string Bells = string.Empty;
        string Kits = string.Empty;
        string Music = string.Empty;
        string CDs = string.Empty;
        string UserLogin = string.Empty;
        string LoginPassword = string.Empty;
        string UpUserLogin = string.Empty;
        string UpLoginPassword = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
           
            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblLoginGETALL";

            DataTable dt = db.ExecuteQuery();
            if (dt.Rows.Count >= 0)
            {
                DataRow dr = dt.Rows[0];
                UserLogin = dr["Username"].ToString();
                LoginPassword = dr["Password"].ToString();
            }

            if (txtUser.Text == UserLogin)
            {
                if (txtPassword.Text == LoginPassword)
                {
                    AdminLogin.Style.Add("display", "none");
                    Admin.Style.Add("display", "block");
                }
            }

            if (txtUser.Text != UserLogin || txtPassword.Text != LoginPassword)
            {
                if (txtUser.Text != UserLogin)
                {
                    WrongUser.Style.Add("display", "block");
                    if (txtPassword.Text == LoginPassword)
                    { WrongPassword.Style.Add("display", "none"); }
                }
                if (txtPassword.Text != LoginPassword)
                {
                    WrongPassword.Style.Add("display", "block");
                    if (txtUser.Text == UserLogin)
                    { WrongUser.Style.Add("display", "none"); }
                }

                WrongLogin.Style.Add("display", "block");
            }
        }

        protected void btnSalesMsg_Click(object sender, EventArgs e)
        {
            if (SalesDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { SalesDisplay.Style.Add("display","block"); }
            else if (SalesDisplay.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { SalesDisplay.Style.Add("display","none"); }
            else if (SalesDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { SalesDisplay.Style.Add("display", "block"); }
            else if (SalesDisplay.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { SalesDisplay.Style.Add("display", "none"); }

            Repeat.DataSource = SqlDataSource1;            
            Repeat.DataBind();

            if (Repeat.Items.Count <= 0)
            {
                SalesDisplay.ID.Contains("emptyMessage");
                emptyMessage.Style.Add("display", "block");
            }
            else if (Repeat.Items.Count > 0)
            {
                SalesDisplay.ID.Contains("emptyMessage");
                emptyMessage.Style.Add("display", "none");
            }
        }

        protected void btnContactMsg_Click(object sender, EventArgs e)
        {
            if (ContactDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { ContactDisplay.Style.Add("display", "block"); }
            else if (ContactDisplay.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { ContactDisplay.Style.Add("display", "none"); }
            else if (ContactDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { ContactDisplay.Style.Add("display", "block"); }
            else if (ContactDisplay.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { ContactDisplay.Style.Add("display", "none"); }

            Repeat1.DataSource = SqlDataSource2;
            Repeat1.DataBind();

            if (Repeat1.Items.Count <= 0)
            {
                ContactDisplay.ID.Contains("emptyMessage2");
                emptyMessage2.Style.Add("display", "block");
            }
            else if (Repeat1.Items.Count > 0)
            {
                ContactDisplay.ID.Contains("emptyMessage2");
                emptyMessage2.Style.Add("display", "none");
            }
        }

        protected void btnCommentsEdit_Click(object sender, EventArgs e)
        {
            if (CommentDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { CommentDisplay.Style.Add("display", "block"); }
            else if (CommentDisplay.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { CommentDisplay.Style.Add("display", "none"); }
            else if (CommentDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { CommentDisplay.Style.Add("display", "block"); }
            else if (CommentDisplay.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { CommentDisplay.Style.Add("display", "none"); }

            Repeat2.DataSource = SqlDataSource3;
            Repeat2.DataBind();

            DeletedCommentDisplay.Style.Add("display", "none");
            DeletedComments.Text = "View Deleted Comments";
        }

        protected void DeletedComments_Click(object sender, EventArgs e)
        {
            if (DeletedCommentDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DeletedCommentDisplay.Style.Add("display", "block"); }
            else if (DeletedCommentDisplay.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DeletedCommentDisplay.Style.Add("display", "none"); }
            else if (DeletedCommentDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DeletedCommentDisplay.Style.Add("display", "block"); }
            else if (DeletedCommentDisplay.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DeletedCommentDisplay.Style.Add("display", "none"); }

            RepeatDelete.DataSource = SqlDataSource6;
            RepeatDelete.DataBind();

            if (RepeatDelete.Items.Count == 0)
            {
                DeletedCommentDisplay.ID.Contains("deleteMessage");
                deleteMessage.Style.Add("display", "block");
            }
            if (RepeatDelete.Items.Count > 0)
            {
                DeletedCommentDisplay.ID.Contains("deleteMessage");
                deleteMessage.Style.Add("display", "none");
            }

            if (DeletedComments.Text == "View Deleted Comments")
            {
                DeletedComments.Text = "Close Deleted Comments";
            }
            else if (DeletedComments.Text == "Close Deleted Comments")
            {
                DeletedComments.Text = "View Deleted Comments";
            }

        }

        protected void DeletedSongs_Click(object sender, EventArgs e)
        {
            if (DeletedSongDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DeletedSongDisplay.Style.Add("display", "block"); }
            else if (DeletedSongDisplay.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DeletedSongDisplay.Style.Add("display", "none"); }
            else if (DeletedSongDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DeletedSongDisplay.Style.Add("display", "block"); }
            else if (DeletedSongDisplay.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DeletedSongDisplay.Style.Add("display", "none"); }

            RepeatDelete2.DataSource = SqlDataSource8;
            RepeatDelete2.DataBind();

            if (RepeatDelete2.Items.Count == 0)
            {
                DeletedSongDisplay.ID.Contains("deleteMessage1");
                deleteMessage1.Style.Add("display", "block");
            }
            if (RepeatDelete2.Items.Count > 0)
            {
                DeletedSongDisplay.ID.Contains("deleteMessage1");
                deleteMessage1.Style.Add("display", "none");
            }

            if (DeletedSongs.Text == "View Deleted Songs")
            {
                DeletedSongs.Text = "Close Deleted Songs";
            }
            else if (DeletedSongs.Text == "Close Deleted Songs")
            {
                DeletedSongs.Text = "View Deleted Songs";
            }
        }

        protected void DeletedChristmas_Click(object sender, EventArgs e)
        {
            if (DeletedChristmasDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DeletedChristmasDisplay.Style.Add("display", "block"); }
            else if (DeletedChristmasDisplay.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DeletedChristmasDisplay.Style.Add("display", "none"); }
            else if (DeletedChristmasDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DeletedChristmasDisplay.Style.Add("display", "block"); }
            else if (DeletedChristmasDisplay.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DeletedChristmasDisplay.Style.Add("display", "none"); }

            RepeatDelete3.DataSource = SqlDataSource9;
            RepeatDelete3.DataBind();

            if (RepeatDelete3.Items.Count == 0)
            {
                DeletedChristmasDisplay.ID.Contains("deleteMessage1");
                deleteMessage2.Style.Add("display", "block");
            }
            if (RepeatDelete2.Items.Count > 0)
            {
                DeletedChristmasDisplay.ID.Contains("deleteMessage1");
                deleteMessage2.Style.Add("display", "none");
            }

            if (DeletedChristmas.Text == "View Deleted Christmas Songs")
            {
                DeletedChristmas.Text = "Close Deleted Christmas Songs";
            }
            else if (DeletedChristmas.Text == "Close Deleted Christmas Songs")
            {
                DeletedChristmas.Text = "View Deleted Christmas Songs";
            }
        }

        protected void btnContactEmail_Click(object sender, EventArgs e)
        {
            if (DisplayEmail.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayEmail.Style.Add("display", "block"); }
            else if (DisplayEmail.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayEmail.Style.Add("display", "none"); }
            else if (DisplayEmail.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayEmail.Style.Add("display", "block"); }
            else if (DisplayEmail.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayEmail.Style.Add("display", "none"); }

            Repeat3.DataSource = SqlDataSource4;
            Repeat3.DataBind();

            if (Repeat3.Items.Count <= 0)
            {
                DisplayEmail.ID.Contains("NoEmail");
                NoEmail.Style.Add("display", "block");
            }
            else if (Repeat3.Items.Count > 0)
            {
                DisplayEmail.ID.Contains("NoEmail");
                NoEmail.Style.Add("display", "none");
            }
        }

        protected void btnSongEdit_Click(object sender, EventArgs e)
        {
            if (SongDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { SongDisplay.Style.Add("display", "block"); }
            else if (SongDisplay.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { SongDisplay.Style.Add("display", "none"); }
            else if (SongDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { SongDisplay.Style.Add("display", "block"); }
            else if (SongDisplay.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { SongDisplay.Style.Add("display", "none"); }

            DeletedSongDisplay.Style.Add("display", "none");
            DeletedSongs.Text = "View Deleted Songs";
            DeletedChristmasDisplay.Style.Add("display", "none");
            DeletedChristmas.Text = "View Deleted Christmas Songs";
        }

        protected void btnAllSongs_Click(object sender, EventArgs e)
        {
            if (DisplayAllSongs.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayAllSongs.Style.Add("display", "block"); }
            else if (DisplayAllSongs.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayAllSongs.Style.Add("display", "none"); }
            else if (DisplayAllSongs.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayAllSongs.Style.Add("display", "block"); }
            else if (DisplayAllSongs.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayAllSongs.Style.Add("display", "none"); }

            if (btnAllSongs.Text == "View All Songs")
            {
                btnAllSongs.Text = "Close All Songs";
            }
            else if (btnAllSongs.Text == "Close All Songs")
            {
                btnAllSongs.Text = "View All Songs";
            }

            Repeat4.DataSource = SqlDataSource5;
            Repeat4.DataBind();
        }

        protected void btnChristmasSongs_Click(object sender, EventArgs e)
        {
            if (DisplayChristmasSongs.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayChristmasSongs.Style.Add("display", "block"); }
            else if (DisplayChristmasSongs.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayChristmasSongs.Style.Add("display", "none"); }
            else if (DisplayChristmasSongs.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayChristmasSongs.Style.Add("display", "block"); }
            else if (DisplayChristmasSongs.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayChristmasSongs.Style.Add("display", "none"); }

            Repeater1.DataSource = SqlDataSource7;
            Repeater1.DataBind();

            if (btnChristmasSongs.Text == "View Christmas Songs")
            {
                btnChristmasSongs.Text = "Close Christmas Songs";
            }
            else if (btnChristmasSongs.Text == "Close Christmas Songs")
            {
                btnChristmasSongs.Text = "View Christmas Songs";
            }
        }

        protected void BellPricing_Click(object sender, EventArgs e)
        {
            if (DisplayPricing.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayPricing.Style.Add("display", "block"); }
            else if (DisplayPricing.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayPricing.Style.Add("display", "none"); }
            else if (DisplayPricing.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayPricing.Style.Add("display", "block"); }
            else if (DisplayPricing.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayPricing.Style.Add("display", "none"); }

            RepeatPrice.DataSource = SqlDataSourcePrice;
            RepeatPrice.DataBind();

            if (RepeatPrice.Items.Count <= 0)
            {
                DisplayPricing.ID.Contains("NoPrice");
                NoPrice.Style.Add("display", "block");
            }
            else if (RepeatPrice.Items.Count > 0)
            {
                DisplayPricing.ID.Contains("NoPrice");
                NoPrice.Style.Add("display", "none");
            }
        }

        protected void UpdateLogin_Click(object sender, EventArgs e)
        {
            if (DisplayLogin.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayLogin.Style.Add("display", "block"); }
            else if (DisplayLogin.Attributes.CssStyle.Value == "display: block; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
            { DisplayLogin.Style.Add("display", "none"); }
            else if (DisplayLogin.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayLogin.Style.Add("display", "block"); }
            else if (DisplayLogin.Attributes.CssStyle.Value == "display:block;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
            { DisplayLogin.Style.Add("display", "none"); }


            RepeatLogin.DataSource = SqlDataSourceLogin;
            RepeatLogin.DataBind();

            if (RepeatLogin.Items.Count <= 0)
            {
                DisplayLogin.ID.Contains("NoInfo");
                NoInfo.Style.Add("display", "block");
            }
            else if (RepeatLogin.Items.Count > 0)
            {
                DisplayLogin.ID.Contains("NoInfo");
                NoInfo.Style.Add("display", "none");
            }
        }

        public void ConnectSales(string Sales)
        {
            Sales = txtSales1.Value;

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblSalesDelete";

            db.ExecuteNonQuery();

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "insertSales";
            db.Command.Parameters.AddWithValue("CurrentSales", Sales.ToString());

            db.ExecuteNonQuery();

            txtSales1.Value = string.Empty;

            Repeat.DataSource = null;
            Repeat.DataSource = SqlDataSource1;
            Repeat.DataBind();

            if (Repeat.Items.Count <= 0)
            {
                SalesDisplay.ID.Contains("emptyMessage");
                emptyMessage.Style.Add("display", "block");
            }
            else if (Repeat.Items.Count > 0)
            {
                SalesDisplay.ID.Contains("emptyMessage");
                emptyMessage.Style.Add("display", "none");
            }
        }

        public void ConnectContact(string Contact)
        {
            Contact = txtContact1.Value;

            if (Contact == string.Empty)
            {
                ContactDisplay.ID.Contains("emptyMessage2");
                emptyMessage2.Style.Add("display", "block");
                
            }
            else if (Contact != string.Empty)
            {

                Database db = new Database("KBellString");

                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "tblContactDelete";

                db.ExecuteNonQuery();

                db.Command.CommandType = CommandType.StoredProcedure;
                db.Command.CommandText = "insertContactMessage";
                db.Command.Parameters.AddWithValue("CurrentContact", Contact.ToString());

                db.ExecuteNonQuery();

                txtContact1.Value = string.Empty;

                Repeat1.DataSource = null;
                Repeat1.DataSource = SqlDataSource2;
                Repeat1.DataBind();

                if (Repeat1.Items.Count <= 0)
                {
                    ContactDisplay.ID.Contains("emptyMessage2");
                    emptyMessage2.Style.Add("display", "block");
                }
                else if (Repeat1.Items.Count > 0)
                {
                    ContactDisplay.ID.Contains("emptyMessage2");
                    emptyMessage2.Style.Add("display", "none");
                }
            }
        }

        public void ConnectEmail(string MainEmail, string Password, string CopyEmail, string CopyEmail2)
        {
            Database db = new Database("KBellString");
            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblEmailLoginGETALL";

            DataTable dt = db.ExecuteQuery();
            if (dt.Rows.Count >= 0)
            {
                DataRow dr = dt.Rows[0];
                MainEmail = dr["PrimaryEmail"].ToString();
                Password = dr["Password"].ToString();
                CopyEmail = dr["CopyToEmail"].ToString();
                CopyEmail2 = dr["CopyToEmail2"].ToString();
            }
            
            if (tbGmail.Text != string.Empty)
            { MainEmail = tbGmail.Text; }
            if (tbPassword.Text != string.Empty)
            { Password = tbPassword.Text; }
            if (tbSend.Text != string.Empty)
            { CopyEmail = tbSend.Text; }
            if (tbCopy.Text != string.Empty)
            { CopyEmail2 = tbCopy.Text; }

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblEmailDelete";

            db.ExecuteNonQuery();

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "insertEmail";
            db.Command.Parameters.AddWithValue("PrimaryEmail", MainEmail.ToString());
            db.Command.Parameters.AddWithValue("Password", Password.ToString());
            db.Command.Parameters.AddWithValue("CopyToEmail", CopyEmail.ToString());
            db.Command.Parameters.AddWithValue("CopyToEmail2", CopyEmail2.ToString());

            db.ExecuteNonQuery();

            tbGmail.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbSend.Text = string.Empty;
            tbCopy.Text = string.Empty;

            Repeat3.DataSource = null;
            Repeat3.DataSource = SqlDataSource4;
            Repeat3.DataBind();

            if (Repeat3.Items.Count <= 0)
            {
                DisplayEmail.ID.Contains("NoEmail");
                NoEmail.Style.Add("display", "block");
            }
            else if (Repeat3.Items.Count > 0)
            {
                DisplayEmail.ID.Contains("NoEmail");
                NoEmail.Style.Add("display", "none");
            }
        }

        public void ConnectLogin(string UpUserLogin, string UpLoginPassword)
        {
            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblLoginGETALL";

            DataTable dt = db.ExecuteQuery();
            if (dt.Rows.Count >= 0)
            {
                DataRow dr = dt.Rows[0];
                UpUserLogin = dr["Username"].ToString();
                UpLoginPassword = dr["Password"].ToString();
            }

            if (tbUpUser.Text != string.Empty)
            { UpUserLogin = tbUpUser.Text; }
            if (tbUpPass.Text != string.Empty)
            { UpLoginPassword = tbUpPass.Text; }

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblLoginDelete";

            db.ExecuteNonQuery();

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "insertLogin";
            db.Command.Parameters.AddWithValue("Username", UpUserLogin.ToString());
            db.Command.Parameters.AddWithValue("Password", UpLoginPassword.ToString());

            db.ExecuteNonQuery();

            tbUpUser.Text = string.Empty;
            tbUpPass.Text = string.Empty;

            RepeatLogin.DataSource = null;
            RepeatLogin.DataSource = SqlDataSourceLogin;
            RepeatLogin.DataBind();

            if (RepeatLogin.Items.Count <= 0)
            {
                DisplayLogin.ID.Contains("NoInfo");
                NoInfo.Style.Add("display", "block");
            }
            else if (RepeatLogin.Items.Count > 0)
            {
                DisplayLogin.ID.Contains("NoInfo");
                NoInfo.Style.Add("display", "none");
            }
        }

        public void ConnectPricing(string Bells, string Kits, string Music, string CDs)
        {
            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblPricingGETALL";

            DataTable dt = db.ExecuteQuery();
            if (dt.Rows.Count >= 0)
            {
                DataRow dr = dt.Rows[0];
                Bells = dr["bells"].ToString();
                Kits = dr["kits"].ToString();
                Music = dr["music"].ToString();
                CDs = dr["cds"].ToString();
            }

            if (tbBells.Text != string.Empty)
            { Bells = tbBells.Text; }
            if (tbKits.Text != string.Empty)
            { Kits = tbKits.Text; }
            if (tbMusic.Text != string.Empty)
            { Music = tbMusic.Text; }
            if (tbCDs.Text != string.Empty)
            { CDs = tbCDs.Text; }

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblPricingDelete";

            db.ExecuteNonQuery();

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "insertPricing";
            db.Command.Parameters.AddWithValue("bells", Bells.ToString());
            db.Command.Parameters.AddWithValue("kits", Kits.ToString());
            db.Command.Parameters.AddWithValue("music", Music.ToString());
            db.Command.Parameters.AddWithValue("cds", CDs.ToString());

            db.ExecuteNonQuery();

            tbBells.Text = string.Empty;
            tbKits.Text = string.Empty;
            tbMusic.Text = string.Empty;
            tbCDs.Text = string.Empty;

            RepeatPrice.DataSource = null;
            RepeatPrice.DataSource = SqlDataSourcePrice;
            RepeatPrice.DataBind();

            if (RepeatPrice.Items.Count <= 0)
            {
                DisplayPricing.ID.Contains("NoPrice");
                NoPrice.Style.Add("display", "block");
            }
            else if (RepeatPrice.Items.Count > 0)
            {
                DisplayPricing.ID.Contains("NoPrice");
                NoPrice.Style.Add("display", "none");
            }
        }

        public void ConnectSong(string Song)
        {
            Song = txtSong.Text;
            Deleted = "false";
            int idCount = 0;
            int idCountDelete = 0;

            Database db1 = new Database("KBellString");

            db1.Command.CommandType = CommandType.StoredProcedure;
            db1.Command.CommandText = "tblSongsGETALLdeleted";

            DataTable dt1 = db1.ExecuteQuery();
            if (dt1.Rows.Count > 0)
            {
                idCountDelete = dt1.Rows.Count;
            }

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblSongsGETALL";

            DataTable dt = db.ExecuteQuery();
            if (dt.Rows.Count > 0)
            {
                idCount = dt.Rows.Count + 1;
                idCount = idCount + idCountDelete;
            }

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "insertSongs";
            db.Command.Parameters.AddWithValue("song", Song.ToString());
            db.Command.Parameters.AddWithValue("ID", (int)idCount);
            db.Command.Parameters.AddWithValue("deleted", Deleted);

            db.ExecuteNonQuery();

            txtSong.Text = string.Empty;

            Repeat4.DataSource = null;
            Repeat4.DataSource = SqlDataSource5;
            Repeat4.DataBind();
        }

        public void ConnectChristmas(string Csong)
        {
            Csong = txtChristmas.Text;
            Deleted = "false";
            int idCount = 0;
            int idCountDelete = 0;

            Database db1 = new Database("KBellString");

            db1.Command.CommandType = CommandType.StoredProcedure;
            db1.Command.CommandText = "tblChristmasGETALLdeleted";

            DataTable dt1 = db1.ExecuteQuery();
            if (dt1.Rows.Count > 0)
            {
                idCountDelete = dt1.Rows.Count;
            }

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblChristmasGETALL";

            DataTable dt = db.ExecuteQuery();
            if (dt.Rows.Count > 0)
            {
                idCount = dt.Rows.Count + 1;
                idCount = idCount + idCountDelete;
            }

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "insertChristmas";
            db.Command.Parameters.AddWithValue("Csong", Csong.ToString());
            db.Command.Parameters.AddWithValue("ID", (int)idCount);
            db.Command.Parameters.AddWithValue("deleted", Deleted);

            db.ExecuteNonQuery();

            txtChristmas.Text = string.Empty;

            Repeater1.DataSource = null;
            Repeater1.DataSource = SqlDataSource7;
            Repeater1.DataBind();
        }

        public void InitializeBusinessData(DataRow dr)
        {
            Sales = dr["CurrentSales"].ToString();
            Contact = dr["CurrentContact"].ToString();
        }

    protected void submitSales_Click(object sender, EventArgs e)
    {
        if (txtSales1.Value != string.Empty)
        {
            ConnectSales(Sales);
        }
    }

    protected void submitContact_Click(object sender, EventArgs e)
    {
        if (txtContact1.Value != string.Empty)
        {
            ConnectContact(Contact);
        }
    }

    protected void EmailInfo_Click(object sender, EventArgs e)
    {
        ConnectEmail(MainEmail, Password, CopyEmail, CopyEmail2);
    }

    protected void UpdateLoginInfo_Click(object sender, EventArgs e)
    {
        ConnectLogin(UpUserLogin, UpLoginPassword);
    }

    protected void PriceUpdate_Click(object sender, EventArgs e)
    {
        ConnectPricing(Bells, Kits, Music, CDs);
    }

    protected void btnNewSong_Click(object sender, EventArgs e)
    {
        if(txtSong.Text != string.Empty)
        {
            ConnectSong(Song);
        }
    }

    protected void btnChristmasSong_Click(object sender, EventArgs e)
    {
        if (txtChristmas.Text != string.Empty)
        {
            ConnectChristmas(Csong);
        }
    }

    protected void clearMessage_Click(object sender, EventArgs e)
    {
        Database db = new Database("KBellString");

        db.Command.CommandType = CommandType.StoredProcedure;
        db.Command.CommandText = "tblSalesDelete";

        db.ExecuteNonQuery();

        Repeat.DataSource = null;
        Repeat.DataSource = SqlDataSource1;
        Repeat.DataBind();

        SalesDisplay.ID.Contains("emptyMessage");
        emptyMessage.Style.Add("display", "block");
    }

    protected void clearMessage2_Click(object sender, EventArgs e)
    {
        Database db = new Database("KBellString");

        db.Command.CommandType = CommandType.StoredProcedure;
        db.Command.CommandText = "tblContactDelete";

        db.ExecuteNonQuery();

        Repeat1.DataSource = null;
        Repeat1.DataSource = SqlDataSource2;
        Repeat1.DataBind();

        ContactDisplay.ID.Contains("emptyMessage2");
        emptyMessage2.Style.Add("display", "block");
    }
    
    protected void Repeat2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "deleteCom")
        {
            string Comment1 = string.Empty;
            string Name1 = string.Empty;
            string Location1 = string.Empty;
            int ID1 = 0;
            string Deleted1 = string.Empty;

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblCommentsGETALL1";

            DataTable dt = db.ExecuteQuery();
            int i = 0;

            if (dt.Rows.Count >= 0)
            {    
                do
                {
                    DataRow dr = dt.Rows[i];
                    Comment = dr["comment"].ToString();
                    Name = dr["name"].ToString();
                    Location = dr["location"].ToString();
                    Deleted = dr["deleted"].ToString();
                    ID = (int)dr["ID"];

                    if (ID.ToString() == e.CommandArgument.ToString())
                    {
                        Comment1 = Comment.ToString();
                        Name1 = Name.ToString();
                        Location1 = Location.ToString();
                        Deleted1 = "true";
                        ID1 = ID;

                        Database db1 = new Database("KBellString");
                        db1.Command.CommandType = CommandType.StoredProcedure;
                        db1.Command.CommandText = "tblCommentDelete";
                        db1.Command.Parameters.AddWithValue("ID", (int)ID1);

                        db1.ExecuteNonQuery();
                    }
                    
                    i++;
                } while (i < dt.Rows.Count);
            }

            Repeat2.DataSource = null;
            Repeat2.DataSource = SqlDataSource3;
            Repeat2.DataBind();

            RepeatDelete.DataSource = null;
            RepeatDelete.DataSource = SqlDataSource6;
            RepeatDelete.DataBind();

            if (RepeatDelete.Items.Count > 0)
            {
                DeletedCommentDisplay.ID.Contains("deleteMessage");
                deleteMessage.Style.Add("display", "none");
                if (DeletedCommentDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
                { DeletedCommentDisplay.Style.Add("display", "block");
                DeletedComments.Text = "Close Deleted Comments";
                }
                else if (DeletedCommentDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
                { DeletedCommentDisplay.Style.Add("display", "block");
                DeletedComments.Text = "Close Deleted Comments";
                }
            }
        }
    }

    protected void RepeatDelete_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "RestoreCom")
        {
            string Comment1 = string.Empty;
            string Name1 = string.Empty;
            string Location1 = string.Empty;
            int ID1 = 0;
            string Deleted1 = string.Empty;

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblCommentsGETALLdeleted";

            DataTable dt = db.ExecuteQuery();
            int i = 0;

            if (dt.Rows.Count >= 0)
            {
                do
                {
                    DataRow dr = dt.Rows[i];
                    Comment = dr["comment"].ToString();
                    Name = dr["name"].ToString();
                    Location = dr["location"].ToString();
                    Deleted = dr["deleted"].ToString();
                    ID = (int)dr["ID"];

                    if (ID.ToString() == e.CommandArgument.ToString())
                    {
                        Comment1 = Comment.ToString();
                        Name1 = Name.ToString();
                        Location1 = Location.ToString();
                        Deleted1 = "true";
                        ID1 = ID;

                        Database db1 = new Database("KBellString");
                        db1.Command.CommandType = CommandType.StoredProcedure;
                        db1.Command.CommandText = "tblCommentRestore";
                        db1.Command.Parameters.AddWithValue("ID", (int)ID1);

                        db1.ExecuteNonQuery();
                    }

                    i++;
                } while (i < dt.Rows.Count);
            }

            Repeat2.DataSource = null;
            Repeat2.DataSource = SqlDataSource3;
            Repeat2.DataBind();

            RepeatDelete.DataSource = null;
            RepeatDelete.DataSource = SqlDataSource6;
            RepeatDelete.DataBind();

            if (RepeatDelete.Items.Count == 0)
            {
                DeletedCommentDisplay.ID.Contains("deleteMessage");
                deleteMessage.Style.Add("display", "block");
            }

            if (RepeatDelete.Items.Count > 0)
            {
                DeletedCommentDisplay.ID.Contains("deleteMessage");
                deleteMessage.Style.Add("display", "none");
            }  
        }
    }

    protected void Repeat4_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deleteSon")
        {
            string Song1 = string.Empty;
            int ID1 = 0;
            string Deleted1 = string.Empty;

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblSongsGETALL";

            DataTable dt = db.ExecuteQuery();
            int i = 0;

            if (dt.Rows.Count >= 0)
            {
                do
                {
                    DataRow dr = dt.Rows[i];
                    Song = dr["song"].ToString();
                    Deleted = dr["deleted"].ToString();
                    ID = (int)dr["ID"];

                    if (ID.ToString() == e.CommandArgument.ToString())
                    {
                        Song1 = Comment.ToString();
                        Deleted1 = "true";
                        ID1 = ID;

                        Database db1 = new Database("KBellString");
                        db1.Command.CommandType = CommandType.StoredProcedure;
                        db1.Command.CommandText = "tblSongsDelete";
                        db1.Command.Parameters.AddWithValue("ID", (int)ID1);

                        db1.ExecuteNonQuery();
                    }

                    i++;
                } while (i < dt.Rows.Count);
            }

            Repeat4.DataSource = null;
            Repeat4.DataSource = SqlDataSource5;
            Repeat4.DataBind();

            RepeatDelete2.DataSource = null;
            RepeatDelete2.DataSource = SqlDataSource8;
            RepeatDelete2.DataBind();

            if (RepeatDelete2.Items.Count > 0)
            {
                DeletedSongDisplay.ID.Contains("deleteMessage1");
                deleteMessage1.Style.Add("display", "none");
                if (DeletedSongDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
                { DeletedSongDisplay.Style.Add("display", "block");
                DeletedSongs.Text = "Close Deleted Songs";
                }
                else if (DeletedSongDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
                { DeletedSongDisplay.Style.Add("display", "block");
                DeletedSongs.Text = "Close Deleted Songs";
                }
            }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "deleteCrs")
        {
            string Csong1 = string.Empty;
            int ID1 = 0;
            string Deleted1 = string.Empty;

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblChristmasGETALL";

            DataTable dt = db.ExecuteQuery();
            int i = 0;

            if (dt.Rows.Count >= 0)
            {
                do
                {
                    DataRow dr = dt.Rows[i];
                    Song = dr["Csong"].ToString();
                    Deleted = dr["deleted"].ToString();
                    ID = (int)dr["ID"];

                    if (ID.ToString() == e.CommandArgument.ToString())
                    {
                        Csong1 = Csong.ToString();
                        Deleted1 = "true";
                        ID1 = ID;

                        Database db1 = new Database("KBellString");
                        db1.Command.CommandType = CommandType.StoredProcedure;
                        db1.Command.CommandText = "tblChristmasDelete";
                        db1.Command.Parameters.AddWithValue("ID", (int)ID1);

                        db1.ExecuteNonQuery();
                    }

                    i++;
                } while (i < dt.Rows.Count);
            }

            Repeater1.DataSource = null;
            Repeater1.DataSource = SqlDataSource7;
            Repeater1.DataBind();

            RepeatDelete3.DataSource = null;
            RepeatDelete3.DataSource = SqlDataSource9;
            RepeatDelete3.DataBind();

            if (RepeatDelete3.Items.Count > 0)
            {
                DeletedChristmasDisplay.ID.Contains("deleteMessage2");
                deleteMessage2.Style.Add("display", "none");
                if (DeletedChristmasDisplay.Attributes.CssStyle.Value == "display: none; margin-top: 10px; padding-bottom: 15px; background-color: #86aca3;")
                { DeletedChristmasDisplay.Style.Add("display", "block");
                DeletedChristmas.Text = "Close Deleted Christmas Songs";
                }
                else if (DeletedChristmasDisplay.Attributes.CssStyle.Value == "display:none;margin-top:10px;padding-bottom:15px;background-color:#86aca3;")
                { DeletedChristmasDisplay.Style.Add("display", "block");
                DeletedChristmas.Text = "Close Deleted Christmas Songs";
                }
            }
        }
    }

    protected void RepeatDelete2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "RestoreSon")
        {
            string Song1 = string.Empty;
            int ID1 = 0;
            string Deleted1 = string.Empty;

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblSongsGETALLdeleted";

            DataTable dt = db.ExecuteQuery();
            int i = 0;

            if (dt.Rows.Count >= 0)
            {
                do
                {
                    DataRow dr = dt.Rows[i];
                    Song = dr["song"].ToString();
                    Deleted = dr["deleted"].ToString();
                    ID = (int)dr["ID"];

                    if (ID.ToString() == e.CommandArgument.ToString())
                    {
                        Song1 = Song.ToString();
                        Deleted1 = "true";
                        ID1 = ID;

                        Database db1 = new Database("KBellString");
                        db1.Command.CommandType = CommandType.StoredProcedure;
                        db1.Command.CommandText = "tblSongRestore";
                        db1.Command.Parameters.AddWithValue("ID", (int)ID1);

                        db1.ExecuteNonQuery();
                    }

                    i++;
                } while (i < dt.Rows.Count);
            }

            Repeat4.DataSource = null;
            Repeat4.DataSource = SqlDataSource5;
            Repeat4.DataBind();

            RepeatDelete2.DataSource = null;
            RepeatDelete2.DataSource = SqlDataSource8;
            RepeatDelete2.DataBind();

            if (RepeatDelete2.Items.Count == 0)
            {
                DeletedSongDisplay.ID.Contains("deleteMessage1");
                deleteMessage1.Style.Add("display", "block");
            }

            if (RepeatDelete2.Items.Count > 0)
            {
                DeletedSongDisplay.ID.Contains("deleteMessage1");
                deleteMessage1.Style.Add("display", "none");
            }
        }
    }

    protected void RepeatDelete3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "RestoreCrs")
        {
            string Csong1 = string.Empty;
            int ID1 = 0;
            string Deleted1 = string.Empty;

            Database db = new Database("KBellString");

            db.Command.CommandType = CommandType.StoredProcedure;
            db.Command.CommandText = "tblChristmasGETALLdeleted";

            DataTable dt = db.ExecuteQuery();
            int i = 0;

            if (dt.Rows.Count >= 0)
            {
                do
                {
                    DataRow dr = dt.Rows[i];
                    Song = dr["Csong"].ToString();
                    Deleted = dr["deleted"].ToString();
                    ID = (int)dr["ID"];

                    if (ID.ToString() == e.CommandArgument.ToString())
                    {
                        Csong1 = Csong.ToString();
                        Deleted1 = "true";
                        ID1 = ID;

                        Database db1 = new Database("KBellString");
                        db1.Command.CommandType = CommandType.StoredProcedure;
                        db1.Command.CommandText = "tblChristmasRestore";
                        db1.Command.Parameters.AddWithValue("ID", (int)ID1);

                        db1.ExecuteNonQuery();
                    }

                    i++;
                } while (i < dt.Rows.Count);
            }

            Repeater1.DataSource = null;
            Repeater1.DataSource = SqlDataSource7;
            Repeater1.DataBind();

            RepeatDelete3.DataSource = null;
            RepeatDelete3.DataSource = SqlDataSource9;
            RepeatDelete3.DataBind();

            if (RepeatDelete3.Items.Count == 0)
            {
                DeletedChristmasDisplay.ID.Contains("deleteMessage2");
                deleteMessage2.Style.Add("display", "block");
            }

            if (RepeatDelete3.Items.Count > 0)
            {
                DeletedChristmasDisplay.ID.Contains("deleteMessage2");
                deleteMessage2.Style.Add("display", "none");
            }
        }
    }
}
}
