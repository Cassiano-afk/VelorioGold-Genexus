using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gamexamplelogin : GXHttpHandler
   {
      public gamexamplelogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Design.GoldLegacy", true);
      }

      public gamexamplelogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavLogonto = new GXCombobox();
         chkavRememberme = new GXCheckbox();
         chkavKeepmeloggedin = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridextauthtypes") == 0 )
            {
               gxnrGridextauthtypes_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridextauthtypes") == 0 )
            {
               gxgrGridextauthtypes_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridextauthtypes_newrow_invoke( )
      {
         nRC_GXsfl_62 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_62"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_62_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_62_idx = GetPar( "sGXsfl_62_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridextauthtypes_newrow( ) ;
         /* End function gxnrGridextauthtypes_newrow_invoke */
      }

      protected void gxgrGridextauthtypes_refresh_invoke( )
      {
         AV18IDP_State = GetPar( "IDP_State");
         AV8AuxUserName = GetPar( "AuxUserName");
         AV33UserRememberMe = (short)(Math.Round(NumberUtil.Val( GetPar( "UserRememberMe"), "."), 18, MidpointRounding.ToEven));
         AV28RememberMe = StringUtil.StrToBool( GetPar( "RememberMe"));
         AV23KeepMeLoggedIn = StringUtil.StrToBool( GetPar( "KeepMeLoggedIn"));
         AV24Language = GetPar( "Language");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridextauthtypes_refresh( AV18IDP_State, AV8AuxUserName, AV33UserRememberMe, AV28RememberMe, AV23KeepMeLoggedIn, AV24Language) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridextauthtypes_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            PA0T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavNameauthtype_Enabled = 0;
               AssignProp("", false, edtavNameauthtype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNameauthtype_Enabled), 5, 0), !bGXsfl_62_Refreshing);
               WS0T2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0T2( ) ;
               }
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Login") ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1318140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamexamplelogin.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV8AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV24Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24Language, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_62", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_62), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV18IDP_State));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV8AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV24Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24Language, "")), context));
         GxWebStd.gx_hidden_field( context, "subGridextauthtypes_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TBLEXTERNALSAUTH_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTblexternalsauth_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TBLEXTERNALSAUTH_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divTblexternalsauth_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0T2( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "GAMExampleLogin" ;
      }

      public override string GetPgmdesc( )
      {
         return "Login" ;
      }

      protected void WB0T0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "table-login stack-top-xxl", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-xl", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbtitle_Internalname, "Login", "", "", lblTbtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbcurrentrepository_Internalname, lblTbcurrentrepository_Caption, "", "", lblTbcurrentrepository_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", lblTbcurrentrepository_Visible, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecreateaccount_Internalname, divTablecreateaccount_Visible, 0, "px", 0, "px", "Table w-100", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbhaveaccount_Internalname, "Não tem uma conta?", "", "", lblTbhaveaccount_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbregister_Internalname, "Registrar", "", "", lblTbregister_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110t1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavLogonto.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavLogonto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavLogonto_Internalname, "Acessar", "col-xs-12 AttributeLabel w-100Label", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_62_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavLogonto, cmbavLogonto_Internalname, StringUtil.RTrim( AV26LogOnTo), 1, cmbavLogonto_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVLOGONTO.CLICK."+"'", "char", "", cmbavLogonto.Visible, cmbavLogonto.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute w-100", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 0, "HLP_GAMExampleLogin.htm");
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV26LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", (string)(cmbavLogonto.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "Usuário", "col-xs-12 AttributeLabel w-100Label", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_62_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV31UserName, StringUtil.RTrim( context.localUtil.Format( AV31UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", edtavUsername_Invitemessage, edtavUsername_Jsonclick, 0, "Attribute w-100", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 0, "px", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserpassword_Internalname, "Senha", "col-xs-12 AttributeLabel w-100Label", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_62_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserpassword_Internalname, StringUtil.RTrim( AV32UserPassword), StringUtil.RTrim( context.localUtil.Format( AV32UserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\""+" "+"idenableshowpasswordhint=\"False\""+" ", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", edtavUserpassword_Invitemessage, edtavUserpassword_Jsonclick, 0, "Attribute w-100", "", "", "", "", edtavUserpassword_Visible, edtavUserpassword_Enabled, 0, "text", "", 0, "px", 1, "row", 50, -1, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMPassword", "start", true, "", "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "end", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbforgotpwd_Internalname, "Esqueceu sua senha?", "", "", lblTbforgotpwd_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120t1_client"+"'", "", "TextBlock", 7, "", lblTbforgotpwd_Visible, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavRememberme.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavRememberme_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_62_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavRememberme_Internalname, StringUtil.BoolToStr( AV28RememberMe), "", "", chkavRememberme.Visible, chkavRememberme.Enabled, "true", "Remember Me", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(40, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,40);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblloginbutton_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavKeepmeloggedin.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavKeepmeloggedin_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_62_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavKeepmeloggedin_Internalname, StringUtil.BoolToStr( AV23KeepMeLoggedIn), "", "", chkavKeepmeloggedin.Visible, chkavKeepmeloggedin.Enabled, "true", "Mantenha-me conectado", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(51, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,51);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "Button Primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttLogin_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(62), 2, 0)+","+"null"+");", bttLogin_Caption, bttLogin_Jsonclick, 5, "ENTRAR", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-top-l", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblexternalsauth_Internalname, divTblexternalsauth_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 stack-bottom-l", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTbexternalauthentication_Internalname, "Ou se logue com", "", "", lblTbexternalauthentication_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "text-line-separator", 0, "", 1, 1, 0, 0, "HLP_GAMExampleLogin.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /*  Grid Control  */
            GridextauthtypesContainer.SetIsFreestyle(true);
            GridextauthtypesContainer.SetWrapped(nGXWrapped);
            StartGridControl62( ) ;
         }
         if ( wbEnd == 62 )
         {
            wbEnd = 0;
            nRC_GXsfl_62 = (int)(nGXsfl_62_idx-1);
            if ( GridextauthtypesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               if ( subGridextauthtypes_Visible != 0 )
               {
                  sStyleString = "";
               }
               else
               {
                  sStyleString = " style=\"display:none;\"";
               }
               context.WriteHtmlText( "<div id=\""+"GridextauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridextauthtypes", GridextauthtypesContainer, subGridextauthtypes_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData", GridextauthtypesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData"+"V", GridextauthtypesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridextauthtypesContainerData"+"V"+"\" value='"+GridextauthtypesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 62 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridextauthtypesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  if ( subGridextauthtypes_Visible != 0 )
                  {
                     sStyleString = "";
                  }
                  else
                  {
                     sStyleString = " style=\"display:none;\"";
                  }
                  context.WriteHtmlText( "<div id=\""+"GridextauthtypesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridextauthtypes", GridextauthtypesContainer, subGridextauthtypes_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData", GridextauthtypesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridextauthtypesContainerData"+"V", GridextauthtypesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridextauthtypesContainerData"+"V"+"\" value='"+GridextauthtypesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0T2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Login", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0T0( ) ;
      }

      protected void WS0T2( )
      {
         START0T2( ) ;
         EVT0T2( ) ;
      }

      protected void EVT0T2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "VLOGONTO.CLICK") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E130T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E140T2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'SelectAuthenticationType' */
                           E150T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 21), "GRIDEXTAUTHTYPES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "'SELECTAUTHENTICATIONTYPE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                        {
                           nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
                           SubsflControlProps_622( ) ;
                           AV27NameAuthType = cgiGet( edtavNameauthtype_Internalname);
                           AssignAttri("", false, edtavNameauthtype_Internalname, AV27NameAuthType);
                           GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_62_idx, GetSecureSignedToken( sGXsfl_62_idx, StringUtil.RTrim( context.localUtil.Format( AV27NameAuthType, "")), context));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E160T2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Refresh */
                                 E170T2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "GRIDEXTAUTHTYPES.LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Gridextauthtypes.Load */
                                 E180T2 ();
                              }
                              else if ( StringUtil.StrCmp(sEvt, "'SELECTAUTHENTICATIONTYPE'") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: 'SelectAuthenticationType' */
                                 E150T2 ();
                                 /* No code required for Cancel button. It is implemented as the Reset button. */
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                              }
                           }
                           else
                           {
                           }
                        }
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE0T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0T2( ) ;
            }
         }
      }

      protected void PA0T2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavLogonto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridextauthtypes_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_622( ) ;
         while ( nGXsfl_62_idx <= nRC_GXsfl_62 )
         {
            sendrow_622( ) ;
            nGXsfl_62_idx = ((subGridextauthtypes_Islastpage==1)&&(nGXsfl_62_idx+1>subGridextauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_622( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridextauthtypesContainer)) ;
         /* End function gxnrGridextauthtypes_newrow */
      }

      protected void gxgrGridextauthtypes_refresh( string AV18IDP_State ,
                                                   string AV8AuxUserName ,
                                                   short AV33UserRememberMe ,
                                                   bool AV28RememberMe ,
                                                   bool AV23KeepMeLoggedIn ,
                                                   string AV24Language )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDEXTAUTHTYPES_nCurrentRecord = 0;
         RF0T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridextauthtypes_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27NameAuthType, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAMEAUTHTYPE", StringUtil.RTrim( AV27NameAuthType));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV26LogOnTo = cmbavLogonto.getValidValue(AV26LogOnTo);
            AssignAttri("", false, "AV26LogOnTo", AV26LogOnTo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavLogonto.CurrentValue = StringUtil.RTrim( AV26LogOnTo);
            AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         }
         AV28RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV28RememberMe));
         AssignAttri("", false, "AV28RememberMe", AV28RememberMe);
         AV23KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV23KeepMeLoggedIn));
         AssignAttri("", false, "AV23KeepMeLoggedIn", AV23KeepMeLoggedIn);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavNameauthtype_Enabled = 0;
      }

      protected void RF0T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridextauthtypesContainer.ClearRows();
         }
         wbStart = 62;
         /* Execute user event: Refresh */
         E170T2 ();
         nGXsfl_62_idx = 1;
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_622( ) ;
         bGXsfl_62_Refreshing = true;
         GridextauthtypesContainer.AddObjectProperty("GridName", "Gridextauthtypes");
         GridextauthtypesContainer.AddObjectProperty("CmpContext", "");
         GridextauthtypesContainer.AddObjectProperty("InMasterPage", "false");
         GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridextauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridextauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Backcolorstyle), 1, 0, ".", "")));
         GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
         GridextauthtypesContainer.PageSize = subGridextauthtypes_fnc_Recordsperpage( );
         if ( subGridextauthtypes_Islastpage != 0 )
         {
            GRIDEXTAUTHTYPES_nFirstRecordOnPage = (long)(subGridextauthtypes_fnc_Recordcount( )-subGridextauthtypes_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRIDEXTAUTHTYPES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDEXTAUTHTYPES_nFirstRecordOnPage), 15, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("GRIDEXTAUTHTYPES_nFirstRecordOnPage", GRIDEXTAUTHTYPES_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_622( ) ;
            /* Execute user event: Gridextauthtypes.Load */
            E180T2 ();
            wbEnd = 62;
            WB0T0( ) ;
         }
         bGXsfl_62_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0T2( )
      {
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV8AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERREMEMBERME", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33UserRememberMe), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERREMEMBERME", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV33UserRememberMe), "Z9"), context));
         GxWebStd.gx_hidden_field( context, "vLANGUAGE", StringUtil.RTrim( AV24Language));
         GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24Language, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_62_idx, GetSecureSignedToken( sGXsfl_62_idx, StringUtil.RTrim( context.localUtil.Format( AV27NameAuthType, "")), context));
      }

      protected int subGridextauthtypes_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridextauthtypes_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridextauthtypes_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridextauthtypes_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavNameauthtype_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E160T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_62 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_62"), ",", "."), 18, MidpointRounding.ToEven));
            AV18IDP_State = cgiGet( "vIDP_STATE");
            subGridextauthtypes_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGridextauthtypes_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            divTblexternalsauth_Visible = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TBLEXTERNALSAUTH_Visible"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            cmbavLogonto.Name = cmbavLogonto_Internalname;
            cmbavLogonto.CurrentValue = cgiGet( cmbavLogonto_Internalname);
            AV26LogOnTo = cgiGet( cmbavLogonto_Internalname);
            AssignAttri("", false, "AV26LogOnTo", AV26LogOnTo);
            AV31UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV31UserName", AV31UserName);
            AV32UserPassword = cgiGet( edtavUserpassword_Internalname);
            AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
            AV28RememberMe = StringUtil.StrToBool( cgiGet( chkavRememberme_Internalname));
            AssignAttri("", false, "AV28RememberMe", AV28RememberMe);
            AV23KeepMeLoggedIn = StringUtil.StrToBool( cgiGet( chkavKeepmeloggedin_Internalname));
            AssignAttri("", false, "AV23KeepMeLoggedIn", AV23KeepMeLoggedIn);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E160T2 ();
         if (returnInSub) return;
      }

      protected void E160T2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTbcurrentrepository_Visible = 0;
         AssignProp("", false, lblTbcurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbcurrentrepository_Visible), 5, 0), true);
         divTblexternalsauth_Visible = 0;
         AssignProp("", false, divTblexternalsauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblexternalsauth_Visible), 5, 0), true);
         AV19isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).checkconnection();
         AssignAttri("", false, "AV19isConnectionOK", AV19isConnectionOK);
         if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).ismultitenant() )
         {
            /* Execute user subroutine: 'ISMULTITENANTINSTALLATION' */
            S112 ();
            if (returnInSub) return;
         }
         else
         {
            if ( ! AV19isConnectionOK )
            {
               if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV29RepositoryGUID) )
               {
                  AV19isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV29RepositoryGUID, out  AV13GAMErrorCollection);
                  AssignAttri("", false, "AV19isConnectionOK", AV19isConnectionOK);
               }
               else
               {
                  AV9ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
                  if ( AV9ConnectionInfoCollection.Count > 0 )
                  {
                     AV19isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV9ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV13GAMErrorCollection);
                     AssignAttri("", false, "AV19isConnectionOK", AV19isConnectionOK);
                  }
               }
            }
            if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isgamadministrator(out  AV13GAMErrorCollection) )
            {
               AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
               lblTbcurrentrepository_Caption = "Repositório:"+AV15GAMRepository.gxTpr_Name;
               AssignProp("", false, lblTbcurrentrepository_Internalname, "Caption", lblTbcurrentrepository_Caption, true);
               lblTbcurrentrepository_Visible = 1;
               AssignProp("", false, lblTbcurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbcurrentrepository_Visible), 5, 0), true);
            }
         }
      }

      protected void E170T2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         subGridextauthtypes_Visible = 0;
         AssignProp("", false, "GridextauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridextauthtypes_Visible), 5, 0), true);
         AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Useridentification, "name") == 0 )
         {
            edtavUsername_Invitemessage = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"name");
            AssignProp("", false, edtavUsername_Internalname, "Invitemessage", edtavUsername_Invitemessage, true);
         }
         else if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Useridentification, "email") == 0 )
         {
            edtavUsername_Invitemessage = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"email");
            AssignProp("", false, edtavUsername_Internalname, "Invitemessage", edtavUsername_Invitemessage, true);
         }
         else if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Useridentification, "namema") == 0 )
         {
            edtavUsername_Invitemessage = GeneXus.Programs.genexussecuritycommon.gxdomaingamrepositoryuseridentifications.getDescription(context,"namema");
            AssignProp("", false, edtavUsername_Internalname, "Invitemessage", edtavUsername_Invitemessage, true);
         }
         AV17hasErrors = false;
         AV13GAMErrorCollection = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
         if ( AV13GAMErrorCollection.Count > 0 )
         {
            if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 13 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 1 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 104 ) )
            {
            }
            else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 161 )
            {
               CallWebObject(formatLink("gamexampleupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV18IDP_State))}, new string[] {"IDP_State"}) );
               context.wjLocDisableFrm = 1;
               AV17hasErrors = true;
            }
            else
            {
               AV17hasErrors = true;
               AV32UserPassword = "";
               AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S122 ();
               if (returnInSub) return;
            }
         }
         if ( ! AV17hasErrors )
         {
            AV22isValidSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).isvalid(out  AV16GAMSession, out  AV14GAMErrorDelete);
            if ( AV22isValidSession && ! AV16GAMSession.gxTpr_Isanonymous )
            {
               AV30URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30URL)) )
               {
                  CallWebObject(formatLink("gamhome.aspx") );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  CallWebObject(formatLink(AV30URL) );
                  context.wjLocDisableFrm = 0;
               }
            }
            else
            {
               cmbavLogonto.removeAllItems();
               AV24Language = context.GetLanguageProperty( "culture");
               AssignAttri("", false, "AV24Language", AV24Language);
               GxWebStd.gx_hidden_field( context, "gxhash_vLANGUAGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24Language, "")), context));
               AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV24Language, out  AV13GAMErrorCollection);
               AV34GXV1 = 1;
               while ( AV34GXV1 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV34GXV1));
                  if ( AV6AuthenticationType.gxTpr_Needusername )
                  {
                     cmbavLogonto.addItem(AV6AuthenticationType.gxTpr_Name, AV6AuthenticationType.gxTpr_Description, 0);
                  }
                  else
                  {
                     subGridextauthtypes_Visible = 1;
                     AssignProp("", false, "GridextauthtypesContainerDiv", "Visible", StringUtil.LTrimStr( (decimal)(subGridextauthtypes_Visible), 5, 0), true);
                  }
                  AV34GXV1 = (int)(AV34GXV1+1);
               }
               if ( cmbavLogonto.ItemCount <= 1 )
               {
                  cmbavLogonto.Visible = 0;
                  AssignProp("", false, cmbavLogonto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavLogonto.Visible), 5, 0), true);
               }
               else
               {
                  AV26LogOnTo = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(1)).gxTpr_Name;
                  AssignAttri("", false, "AV26LogOnTo", AV26LogOnTo);
               }
               AV21isOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getrememberlogin(out  AV26LogOnTo, out  AV8AuxUserName, out  AV33UserRememberMe, out  AV13GAMErrorCollection);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8AuxUserName)) )
               {
                  AV31UserName = AV8AuxUserName;
                  AssignAttri("", false, "AV31UserName", AV31UserName);
               }
               if ( AV33UserRememberMe == 2 )
               {
                  AV28RememberMe = true;
                  AssignAttri("", false, "AV28RememberMe", AV28RememberMe);
               }
               if ( cmbavLogonto.ItemCount > 1 )
               {
                  AV26LogOnTo = AV15GAMRepository.gxTpr_Defaultauthenticationtypename;
                  AssignAttri("", false, "AV26LogOnTo", AV26LogOnTo);
               }
               /* Execute user subroutine: 'DISPLAYCHECKBOX' */
               S132 ();
               if (returnInSub) return;
               AV35GXV2 = 1;
               while ( AV35GXV2 <= AV7AuthenticationTypes.Count )
               {
                  AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV35GXV2));
                  if ( StringUtil.StrCmp(AV6AuthenticationType.gxTpr_Name, AV26LogOnTo) == 0 )
                  {
                     /* Execute user subroutine: 'VALIDLOGONTOOTP' */
                     S142 ();
                     if (returnInSub) return;
                     if (true) break;
                  }
                  AV35GXV2 = (int)(AV35GXV2+1);
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15GAMRepository", AV15GAMRepository);
         cmbavLogonto.CurrentValue = StringUtil.RTrim( AV26LogOnTo);
         AssignProp("", false, cmbavLogonto_Internalname, "Values", cmbavLogonto.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      private void E180T2( )
      {
         /* Gridextauthtypes_Load Routine */
         returnInSub = false;
         AV36GXV3 = 1;
         while ( AV36GXV3 <= AV7AuthenticationTypes.Count )
         {
            AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV36GXV3));
            if ( AV6AuthenticationType.gxTpr_Redirtoauthenticate )
            {
               AV27NameAuthType = GXUtil.UrlEncode( StringUtil.Trim( AV6AuthenticationType.gxTpr_Name));
               AssignAttri("", false, edtavNameauthtype_Internalname, AV27NameAuthType);
               GxWebStd.gx_hidden_field( context, "gxhash_vNAMEAUTHTYPE"+"_"+sGXsfl_62_idx, GetSecureSignedToken( sGXsfl_62_idx, StringUtil.RTrim( context.localUtil.Format( AV27NameAuthType, "")), context));
               bttExternalauthentication_Caption = StringUtil.Trim( AV6AuthenticationType.gxTpr_Description);
               AssignProp("", false, bttExternalauthentication_Internalname, "Caption", bttExternalauthentication_Caption, !bGXsfl_62_Refreshing);
               bttExternalauthentication_Tooltiptext = StringUtil.Format( "Faça login com %1", StringUtil.Trim( AV6AuthenticationType.gxTpr_Description), "", "", "", "", "", "", "", "");
               AssignProp("", false, bttExternalauthentication_Internalname, "Tooltiptext", bttExternalauthentication_Tooltiptext, !bGXsfl_62_Refreshing);
               if ( divTblexternalsauth_Visible == 0 )
               {
                  divTblexternalsauth_Visible = 1;
                  AssignProp("", false, divTblexternalsauth_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblexternalsauth_Visible), 5, 0), true);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 62;
               }
               sendrow_622( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_62_Refreshing )
               {
                  DoAjaxLoad(62, GridextauthtypesRow);
               }
            }
            AV36GXV3 = (int)(AV36GXV3+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      protected void E130T2( )
      {
         /* Logonto_Click Routine */
         returnInSub = false;
         AV7AuthenticationTypes = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getenabledauthenticationtypes(AV24Language, out  AV13GAMErrorCollection);
         AV20isModeOTP = false;
         AV37GXV4 = 1;
         while ( AV37GXV4 <= AV7AuthenticationTypes.Count )
         {
            AV6AuthenticationType = ((GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple)AV7AuthenticationTypes.Item(AV37GXV4));
            if ( StringUtil.StrCmp(AV6AuthenticationType.gxTpr_Name, AV26LogOnTo) == 0 )
            {
               /* Execute user subroutine: 'VALIDLOGONTOOTP' */
               S142 ();
               if (returnInSub) return;
               if (true) break;
            }
            AV37GXV4 = (int)(AV37GXV4+1);
         }
         if ( ! AV20isModeOTP )
         {
            edtavUserpassword_Visible = 1;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            edtavUserpassword_Invitemessage = "Senha";
            AssignProp("", false, edtavUserpassword_Internalname, "Invitemessage", edtavUserpassword_Invitemessage, true);
            bttLogin_Caption = "ENTRAR";
            AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            lblTbforgotpwd_Visible = 1;
            AssignProp("", false, lblTbforgotpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbforgotpwd_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6AuthenticationType", AV6AuthenticationType);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E140T2 ();
         if (returnInSub) return;
      }

      protected void E140T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         if ( AV23KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV28RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV26LogOnTo;
         AV5AdditionalParameter.gxTpr_Otpstep = 1;
         AV25LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV31UserName, AV32UserPassword, AV5AdditionalParameter, out  AV13GAMErrorCollection);
         if ( AV25LoginOK )
         {
            AV30URL = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrorsurl();
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30URL)) )
            {
               CallWebObject(formatLink("gamhome.aspx") );
               context.wjLocDisableFrm = 1;
            }
            else
            {
               CallWebObject(formatLink(AV30URL) );
               context.wjLocDisableFrm = 0;
            }
         }
         else
         {
            if ( AV13GAMErrorCollection.Count > 0 )
            {
               if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 24 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 23 ) )
               {
                  CallWebObject(formatLink("gamexamplechangepassword.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV18IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 161 )
               {
                  CallWebObject(formatLink("gamexampleupdateregisteruser.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV18IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else if ( ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 400 ) || ( ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(1)).gxTpr_Code == 410 ) )
               {
                  AV14GAMErrorDelete = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getlasterrors();
                  CallWebObject(formatLink("gamexampleotpauthentication.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV18IDP_State))}, new string[] {"IDP_State"}) );
                  context.wjLocDisableFrm = 1;
               }
               else
               {
                  AV32UserPassword = "";
                  AssignAttri("", false, "AV32UserPassword", AV32UserPassword);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void E150T2( )
      {
         /* 'SelectAuthenticationType' Routine */
         returnInSub = false;
         if ( AV23KeepMeLoggedIn )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 3;
         }
         else if ( AV28RememberMe )
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 2;
         }
         else
         {
            AV5AdditionalParameter.gxTpr_Rememberusertype = 1;
         }
         AV5AdditionalParameter.gxTpr_Authenticationtypename = AV27NameAuthType;
         AV25LoginOK = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).login(AV31UserName, AV32UserPassword, AV5AdditionalParameter, out  AV13GAMErrorCollection);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5AdditionalParameter", AV5AdditionalParameter);
      }

      protected void S112( )
      {
         /* 'ISMULTITENANTINSTALLATION' Routine */
         returnInSub = false;
         AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         if ( ! (0==AV15GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
         {
            AV19isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV15GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV13GAMErrorCollection);
            AssignAttri("", false, "AV19isConnectionOK", AV19isConnectionOK);
         }
         if ( ! AV19isConnectionOK )
         {
            if ( new GeneXus.Programs.genexussecurity.SdtGAM(context).getdefaultrepository(out  AV29RepositoryGUID) )
            {
               AV19isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryguid(AV29RepositoryGUID, out  AV13GAMErrorCollection);
               AssignAttri("", false, "AV19isConnectionOK", AV19isConnectionOK);
            }
            else
            {
               AV9ConnectionInfoCollection = new GeneXus.Programs.genexussecurity.SdtGAM(context).getconnections();
               if ( AV9ConnectionInfoCollection.Count > 0 )
               {
                  AV19isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnection(((GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo)AV9ConnectionInfoCollection.Item(1)).gxTpr_Name, out  AV13GAMErrorCollection);
                  AssignAttri("", false, "AV19isConnectionOK", AV19isConnectionOK);
               }
            }
         }
         if ( AV19isConnectionOK )
         {
            AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            if ( ! (0==AV15GAMRepository.gxTpr_Authenticationmasterrepositoryid) )
            {
               AV19isConnectionOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).setconnectionbyrepositoryid(AV15GAMRepository.gxTpr_Authenticationmasterrepositoryid, out  AV13GAMErrorCollection);
               AssignAttri("", false, "AV19isConnectionOK", AV19isConnectionOK);
               AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
            }
            lblTbcurrentrepository_Caption = "Repositório:"+AV15GAMRepository.gxTpr_Name;
            AssignProp("", false, lblTbcurrentrepository_Internalname, "Caption", lblTbcurrentrepository_Caption, true);
            lblTbcurrentrepository_Visible = 1;
            AssignProp("", false, lblTbcurrentrepository_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbcurrentrepository_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'DISPLAYCHECKBOX' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Userremembermetype, "Login") == 0 )
         {
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Userremembermetype, "Auth") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV15GAMRepository.gxTpr_Userremembermetype, "Both") == 0 )
         {
            chkavKeepmeloggedin.Visible = 1;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
            chkavRememberme.Visible = 1;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
         }
         else
         {
            chkavRememberme.Visible = 0;
            AssignProp("", false, chkavRememberme_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavRememberme.Visible), 5, 0), true);
            chkavKeepmeloggedin.Visible = 0;
            AssignProp("", false, chkavKeepmeloggedin_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavKeepmeloggedin.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'VALIDLOGONTOOTP' Routine */
         returnInSub = false;
         if ( AV6AuthenticationType.gxTpr_Needusername && ! AV6AuthenticationType.gxTpr_Needuserpassword )
         {
            AV20isModeOTP = true;
            edtavUserpassword_Visible = 0;
            AssignProp("", false, edtavUserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserpassword_Visible), 5, 0), true);
            if ( AV6AuthenticationType.gxTpr_Istotp )
            {
               bttLogin_Caption = "PRÓXIMO";
               AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            }
            else
            {
               bttLogin_Caption = "ME ENVIE UM CÓDIGO";
               AssignProp("", false, bttLogin_Internalname, "Caption", bttLogin_Caption, true);
            }
            lblTbforgotpwd_Visible = 0;
            AssignProp("", false, lblTbforgotpwd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblTbforgotpwd_Visible), 5, 0), true);
            divTablecreateaccount_Visible = 0;
            AssignProp("", false, divTablecreateaccount_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecreateaccount_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV38GXV5 = 1;
         while ( AV38GXV5 <= AV13GAMErrorCollection.Count )
         {
            AV12GAMError = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV13GAMErrorCollection.Item(AV38GXV5));
            GX_msglist.addItem(AV12GAMError.gxTpr_Message);
            AV38GXV5 = (int)(AV38GXV5+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0T2( ) ;
         WS0T2( ) ;
         WE0T2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202482519415491", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gamexamplelogin.js", "?202482519415494", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_622( )
      {
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_62_idx;
      }

      protected void SubsflControlProps_fel_622( )
      {
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE_"+sGXsfl_62_fel_idx;
      }

      protected void sendrow_622( )
      {
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_622( ) ;
         WB0T0( ) ;
         GridextauthtypesRow = GXWebRow.GetNew(context,GridextauthtypesContainer);
         if ( subGridextauthtypes_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridextauthtypes_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
            {
               subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Odd";
            }
         }
         else if ( subGridextauthtypes_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridextauthtypes_Backstyle = 0;
            subGridextauthtypes_Backcolor = subGridextauthtypes_Allbackcolor;
            if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
            {
               subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Uniform";
            }
         }
         else if ( subGridextauthtypes_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridextauthtypes_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
            {
               subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Odd";
            }
            subGridextauthtypes_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGridextauthtypes_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridextauthtypes_Backstyle = 1;
            if ( ((int)((nGXsfl_62_idx) % (2))) == 0 )
            {
               subGridextauthtypes_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
               {
                  subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Even";
               }
            }
            else
            {
               subGridextauthtypes_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGridextauthtypes_Class, "") != 0 )
               {
                  subGridextauthtypes_Linesclass = subGridextauthtypes_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridextauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGridextauthtypes_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_62_idx+"\">") ;
         }
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTblgridextauthtypes_Internalname+"_"+sGXsfl_62_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 stack-bottom-l",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary w-100";
         StyleString = "";
         GridextauthtypesRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttExternalauthentication_Internalname+"_"+sGXsfl_62_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(62), 2, 0)+","+"null"+");",(string)bttExternalauthentication_Caption,(string)bttExternalauthentication_Jsonclick,(short)5,(string)bttExternalauthentication_Tooltiptext,(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'SELECTAUTHENTICATIONTYPE\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridextauthtypesRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridextauthtypesRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,(string)"Name Auth Type",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_62_idx + "',62)\"";
         ROClassString = "Attribute";
         GridextauthtypesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNameauthtype_Internalname,StringUtil.RTrim( AV27NameAuthType),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNameauthtype_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavNameauthtype_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMAuthenticationTypeName",(string)"start",(bool)true,(string)""});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridextauthtypesRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0T2( ) ;
         /* End of Columns property logic. */
         GridextauthtypesContainer.AddRow(GridextauthtypesRow);
         nGXsfl_62_idx = ((subGridextauthtypes_Islastpage==1)&&(nGXsfl_62_idx+1>subGridextauthtypes_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_622( ) ;
         /* End function sendrow_622 */
      }

      protected void init_web_controls( )
      {
         cmbavLogonto.Name = "vLOGONTO";
         cmbavLogonto.WebTags = "";
         if ( cmbavLogonto.ItemCount > 0 )
         {
            AV26LogOnTo = cmbavLogonto.getValidValue(AV26LogOnTo);
            AssignAttri("", false, "AV26LogOnTo", AV26LogOnTo);
         }
         chkavRememberme.Name = "vREMEMBERME";
         chkavRememberme.WebTags = "";
         chkavRememberme.Caption = "";
         AssignProp("", false, chkavRememberme_Internalname, "TitleCaption", chkavRememberme.Caption, true);
         chkavRememberme.CheckedValue = "false";
         AV28RememberMe = StringUtil.StrToBool( StringUtil.BoolToStr( AV28RememberMe));
         AssignAttri("", false, "AV28RememberMe", AV28RememberMe);
         chkavKeepmeloggedin.Name = "vKEEPMELOGGEDIN";
         chkavKeepmeloggedin.WebTags = "";
         chkavKeepmeloggedin.Caption = "";
         AssignProp("", false, chkavKeepmeloggedin_Internalname, "TitleCaption", chkavKeepmeloggedin.Caption, true);
         chkavKeepmeloggedin.CheckedValue = "false";
         AV23KeepMeLoggedIn = StringUtil.StrToBool( StringUtil.BoolToStr( AV23KeepMeLoggedIn));
         AssignAttri("", false, "AV23KeepMeLoggedIn", AV23KeepMeLoggedIn);
         /* End function init_web_controls */
      }

      protected void StartGridControl62( )
      {
         if ( GridextauthtypesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridextauthtypesContainer"+"DivS\" data-gxgridid=\"62\">") ;
            sStyleString = "";
            if ( subGridextauthtypes_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGridextauthtypes_Internalname, subGridextauthtypes_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridextauthtypesContainer.AddObjectProperty("GridName", "Gridextauthtypes");
         }
         else
         {
            GridextauthtypesContainer.AddObjectProperty("GridName", "Gridextauthtypes");
            GridextauthtypesContainer.AddObjectProperty("Header", subGridextauthtypes_Header);
            GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridextauthtypesContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridextauthtypesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Backcolorstyle), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Visible), 5, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("CmpContext", "");
            GridextauthtypesContainer.AddObjectProperty("InMasterPage", "false");
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV27NameAuthType)));
            GridextauthtypesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNameauthtype_Enabled), 5, 0, ".", "")));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridextauthtypesContainer.AddColumnProperties(GridextauthtypesColumn);
            GridextauthtypesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Selectedindex), 4, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Allowselection), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Selectioncolor), 9, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Allowhovering), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Hoveringcolor), 9, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Allowcollapsing), 1, 0, ".", "")));
            GridextauthtypesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridextauthtypes_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTbtitle_Internalname = "TBTITLE";
         lblTbcurrentrepository_Internalname = "TBCURRENTREPOSITORY";
         lblTbhaveaccount_Internalname = "TBHAVEACCOUNT";
         lblTbregister_Internalname = "TBREGISTER";
         divTablecreateaccount_Internalname = "TABLECREATEACCOUNT";
         cmbavLogonto_Internalname = "vLOGONTO";
         edtavUsername_Internalname = "vUSERNAME";
         edtavUserpassword_Internalname = "vUSERPASSWORD";
         lblTbforgotpwd_Internalname = "TBFORGOTPWD";
         chkavRememberme_Internalname = "vREMEMBERME";
         chkavKeepmeloggedin_Internalname = "vKEEPMELOGGEDIN";
         bttLogin_Internalname = "LOGIN";
         divTblloginbutton_Internalname = "TBLLOGINBUTTON";
         lblTbexternalauthentication_Internalname = "TBEXTERNALAUTHENTICATION";
         bttExternalauthentication_Internalname = "EXTERNALAUTHENTICATION";
         edtavNameauthtype_Internalname = "vNAMEAUTHTYPE";
         divTblgridextauthtypes_Internalname = "TBLGRIDEXTAUTHTYPES";
         divTblexternalsauth_Internalname = "TBLEXTERNALSAUTH";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridextauthtypes_Internalname = "GRIDEXTAUTHTYPES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridextauthtypes_Allowcollapsing = 0;
         chkavKeepmeloggedin.Caption = "";
         chkavRememberme.Caption = "";
         edtavNameauthtype_Jsonclick = "";
         edtavNameauthtype_Enabled = 0;
         subGridextauthtypes_Class = "FreeStyleGrid";
         bttExternalauthentication_Tooltiptext = "Autenticação Externa";
         bttExternalauthentication_Caption = "Autenticação Externa";
         subGridextauthtypes_Backcolorstyle = 0;
         subGridextauthtypes_Visible = 1;
         divTblexternalsauth_Visible = 1;
         bttLogin_Jsonclick = "";
         bttLogin_Caption = "ENTRAR";
         chkavKeepmeloggedin.Enabled = 1;
         chkavKeepmeloggedin.Visible = 1;
         chkavRememberme.Enabled = 1;
         chkavRememberme.Visible = 1;
         lblTbforgotpwd_Visible = 1;
         edtavUserpassword_Jsonclick = "";
         edtavUserpassword_Invitemessage = "";
         edtavUserpassword_Enabled = 1;
         edtavUserpassword_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Invitemessage = "";
         edtavUsername_Enabled = 1;
         cmbavLogonto_Jsonclick = "";
         cmbavLogonto.Enabled = 1;
         cmbavLogonto.Visible = 1;
         divTablecreateaccount_Visible = 1;
         lblTbcurrentrepository_Caption = "";
         lblTbcurrentrepository_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRIDEXTAUTHTYPES_nFirstRecordOnPage"},{"av":"GRIDEXTAUTHTYPES_nEOF"},{"av":"AV18IDP_State","fld":"vIDP_STATE"},{"av":"AV28RememberMe","fld":"vREMEMBERME"},{"av":"AV23KeepMeLoggedIn","fld":"vKEEPMELOGGEDIN"},{"av":"AV8AuxUserName","fld":"vAUXUSERNAME","hsh":true},{"av":"AV33UserRememberMe","fld":"vUSERREMEMBERME","pic":"Z9","hsh":true},{"av":"AV24Language","fld":"vLANGUAGE","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"subGridextauthtypes_Visible","ctrl":"GRIDEXTAUTHTYPES","prop":"Visible"},{"av":"edtavUsername_Invitemessage","ctrl":"vUSERNAME","prop":"Invitemessage"},{"av":"AV18IDP_State","fld":"vIDP_STATE"},{"av":"AV32UserPassword","fld":"vUSERPASSWORD"},{"av":"cmbavLogonto"},{"av":"AV26LogOnTo","fld":"vLOGONTO"},{"av":"AV24Language","fld":"vLANGUAGE","hsh":true},{"av":"AV31UserName","fld":"vUSERNAME"},{"av":"AV28RememberMe","fld":"vREMEMBERME"},{"av":"chkavKeepmeloggedin.Visible","ctrl":"vKEEPMELOGGEDIN","prop":"Visible"},{"av":"chkavRememberme.Visible","ctrl":"vREMEMBERME","prop":"Visible"},{"av":"edtavUserpassword_Visible","ctrl":"vUSERPASSWORD","prop":"Visible"},{"ctrl":"TBTITLE","prop":"Caption"},{"av":"lblTbforgotpwd_Visible","ctrl":"TBFORGOTPWD","prop":"Visible"},{"av":"divTablecreateaccount_Visible","ctrl":"TABLECREATEACCOUNT","prop":"Visible"}]}""");
         setEventMetadata("GRIDEXTAUTHTYPES.LOAD","""{"handler":"E180T2","iparms":[{"av":"divTblexternalsauth_Visible","ctrl":"TBLEXTERNALSAUTH","prop":"Visible"}]""");
         setEventMetadata("GRIDEXTAUTHTYPES.LOAD",""","oparms":[{"av":"AV27NameAuthType","fld":"vNAMEAUTHTYPE","hsh":true},{"ctrl":"EXTERNALAUTHENTICATION","prop":"Caption"},{"ctrl":"EXTERNALAUTHENTICATION","prop":"Tooltiptext"},{"av":"divTblexternalsauth_Visible","ctrl":"TBLEXTERNALSAUTH","prop":"Visible"}]}""");
         setEventMetadata("VLOGONTO.CLICK","""{"handler":"E130T2","iparms":[{"av":"AV24Language","fld":"vLANGUAGE","hsh":true},{"av":"cmbavLogonto"},{"av":"AV26LogOnTo","fld":"vLOGONTO"}]""");
         setEventMetadata("VLOGONTO.CLICK",""","oparms":[{"av":"edtavUserpassword_Visible","ctrl":"vUSERPASSWORD","prop":"Visible"},{"av":"edtavUserpassword_Invitemessage","ctrl":"vUSERPASSWORD","prop":"Invitemessage"},{"ctrl":"TBTITLE","prop":"Caption"},{"av":"lblTbforgotpwd_Visible","ctrl":"TBFORGOTPWD","prop":"Visible"},{"av":"divTablecreateaccount_Visible","ctrl":"TABLECREATEACCOUNT","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E140T2","iparms":[{"av":"AV23KeepMeLoggedIn","fld":"vKEEPMELOGGEDIN"},{"av":"AV28RememberMe","fld":"vREMEMBERME"},{"av":"cmbavLogonto"},{"av":"AV26LogOnTo","fld":"vLOGONTO"},{"av":"AV31UserName","fld":"vUSERNAME"},{"av":"AV32UserPassword","fld":"vUSERPASSWORD"},{"av":"AV18IDP_State","fld":"vIDP_STATE"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV18IDP_State","fld":"vIDP_STATE"},{"av":"AV32UserPassword","fld":"vUSERPASSWORD"}]}""");
         setEventMetadata("'FORGOTPASSWORD'","""{"handler":"E120T1","iparms":[{"av":"AV18IDP_State","fld":"vIDP_STATE"}]""");
         setEventMetadata("'FORGOTPASSWORD'",""","oparms":[{"av":"AV18IDP_State","fld":"vIDP_STATE"}]}""");
         setEventMetadata("'REGISTER'","""{"handler":"E110T1","iparms":[]}""");
         setEventMetadata("'SELECTAUTHENTICATIONTYPE'","""{"handler":"E150T2","iparms":[{"av":"AV23KeepMeLoggedIn","fld":"vKEEPMELOGGEDIN"},{"av":"AV28RememberMe","fld":"vREMEMBERME"},{"av":"AV27NameAuthType","fld":"vNAMEAUTHTYPE","hsh":true},{"av":"AV31UserName","fld":"vUSERNAME"},{"av":"AV32UserPassword","fld":"vUSERPASSWORD"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Nameauthtype","iparms":[]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV18IDP_State = "";
         AV8AuxUserName = "";
         AV24Language = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         lblTbtitle_Jsonclick = "";
         lblTbcurrentrepository_Jsonclick = "";
         lblTbhaveaccount_Jsonclick = "";
         lblTbregister_Jsonclick = "";
         TempTags = "";
         AV26LogOnTo = "";
         AV31UserName = "";
         AV32UserPassword = "";
         lblTbforgotpwd_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTbexternalauthentication_Jsonclick = "";
         GridextauthtypesContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV27NameAuthType = "";
         AV29RepositoryGUID = "";
         AV13GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV9ConnectionInfoCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo>( context, "GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo", "GeneXus.Programs");
         AV15GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV16GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV14GAMErrorDelete = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV30URL = "";
         AV7AuthenticationTypes = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple>( context, "GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple", "GeneXus.Programs");
         AV6AuthenticationType = new GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple(context);
         GridextauthtypesRow = new GXWebRow();
         AV5AdditionalParameter = new GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters(context);
         AV12GAMError = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridextauthtypes_Linesclass = "";
         bttExternalauthentication_Jsonclick = "";
         ROClassString = "";
         subGridextauthtypes_Header = "";
         GridextauthtypesColumn = new GXWebColumn();
         /* GeneXus formulas. */
         edtavNameauthtype_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV33UserRememberMe ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridextauthtypes_Backcolorstyle ;
      private short GRIDEXTAUTHTYPES_nEOF ;
      private short nGXWrapped ;
      private short subGridextauthtypes_Backstyle ;
      private short subGridextauthtypes_Allowselection ;
      private short subGridextauthtypes_Allowhovering ;
      private short subGridextauthtypes_Allowcollapsing ;
      private short subGridextauthtypes_Collapsed ;
      private int divTblexternalsauth_Visible ;
      private int nRC_GXsfl_62 ;
      private int subGridextauthtypes_Recordcount ;
      private int nGXsfl_62_idx=1 ;
      private int edtavNameauthtype_Enabled ;
      private int lblTbcurrentrepository_Visible ;
      private int divTablecreateaccount_Visible ;
      private int edtavUsername_Enabled ;
      private int edtavUserpassword_Visible ;
      private int edtavUserpassword_Enabled ;
      private int lblTbforgotpwd_Visible ;
      private int subGridextauthtypes_Visible ;
      private int subGridextauthtypes_Islastpage ;
      private int AV34GXV1 ;
      private int AV35GXV2 ;
      private int AV36GXV3 ;
      private int AV37GXV4 ;
      private int AV38GXV5 ;
      private int idxLst ;
      private int subGridextauthtypes_Backcolor ;
      private int subGridextauthtypes_Allbackcolor ;
      private int subGridextauthtypes_Selectedindex ;
      private int subGridextauthtypes_Selectioncolor ;
      private int subGridextauthtypes_Hoveringcolor ;
      private long GRIDEXTAUTHTYPES_nCurrentRecord ;
      private long GRIDEXTAUTHTYPES_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_62_idx="0001" ;
      private string AV18IDP_State ;
      private string AV24Language ;
      private string edtavNameauthtype_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTbtitle_Internalname ;
      private string lblTbtitle_Jsonclick ;
      private string lblTbcurrentrepository_Internalname ;
      private string lblTbcurrentrepository_Caption ;
      private string lblTbcurrentrepository_Jsonclick ;
      private string divTablecreateaccount_Internalname ;
      private string lblTbhaveaccount_Internalname ;
      private string lblTbhaveaccount_Jsonclick ;
      private string lblTbregister_Internalname ;
      private string lblTbregister_Jsonclick ;
      private string cmbavLogonto_Internalname ;
      private string TempTags ;
      private string AV26LogOnTo ;
      private string cmbavLogonto_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Invitemessage ;
      private string edtavUsername_Jsonclick ;
      private string edtavUserpassword_Internalname ;
      private string AV32UserPassword ;
      private string edtavUserpassword_Invitemessage ;
      private string edtavUserpassword_Jsonclick ;
      private string lblTbforgotpwd_Internalname ;
      private string lblTbforgotpwd_Jsonclick ;
      private string chkavRememberme_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTblloginbutton_Internalname ;
      private string chkavKeepmeloggedin_Internalname ;
      private string bttLogin_Internalname ;
      private string bttLogin_Caption ;
      private string bttLogin_Jsonclick ;
      private string divTblexternalsauth_Internalname ;
      private string lblTbexternalauthentication_Internalname ;
      private string lblTbexternalauthentication_Jsonclick ;
      private string sStyleString ;
      private string subGridextauthtypes_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV27NameAuthType ;
      private string AV29RepositoryGUID ;
      private string bttExternalauthentication_Caption ;
      private string bttExternalauthentication_Internalname ;
      private string bttExternalauthentication_Tooltiptext ;
      private string sGXsfl_62_fel_idx="0001" ;
      private string subGridextauthtypes_Class ;
      private string subGridextauthtypes_Linesclass ;
      private string divTblgridextauthtypes_Internalname ;
      private string bttExternalauthentication_Jsonclick ;
      private string ROClassString ;
      private string edtavNameauthtype_Jsonclick ;
      private string subGridextauthtypes_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV28RememberMe ;
      private bool AV23KeepMeLoggedIn ;
      private bool bGXsfl_62_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV19isConnectionOK ;
      private bool gx_refresh_fired ;
      private bool AV17hasErrors ;
      private bool AV22isValidSession ;
      private bool AV21isOK ;
      private bool AV20isModeOTP ;
      private bool AV25LoginOK ;
      private string AV8AuxUserName ;
      private string AV31UserName ;
      private string AV30URL ;
      private GXWebGrid GridextauthtypesContainer ;
      private GXWebRow GridextauthtypesRow ;
      private GXWebColumn GridextauthtypesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavLogonto ;
      private GXCheckbox chkavRememberme ;
      private GXCheckbox chkavKeepmeloggedin ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV13GAMErrorCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMConnectionInfo> AV9ConnectionInfoCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV15GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV16GAMSession ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14GAMErrorDelete ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple> AV7AuthenticationTypes ;
      private GeneXus.Programs.genexussecurity.SdtGAMAuthenticationTypeSimple AV6AuthenticationType ;
      private GeneXus.Programs.genexussecurity.SdtGAMLoginAdditionalParameters AV5AdditionalParameter ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV12GAMError ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
