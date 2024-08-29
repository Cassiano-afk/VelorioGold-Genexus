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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.transactions {
   public class gerenciadordetransmissoesgeneral : GXWebComponent
   {
      public gerenciadordetransmissoesgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Design.GoldLegacy", true);
         }
      }

      public gerenciadordetransmissoesgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_IdTransmissao )
      {
         this.A55IdTransmissao = aP0_IdTransmissao;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkAoVivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "IdTransmissao");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A55IdTransmissao = (short)(Math.Round(NumberUtil.Val( GetPar( "IdTransmissao"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A55IdTransmissao});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "IdTransmissao");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "IdTransmissao");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0D2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV11Pgmname = "Transactions.GerenciadorDeTransmissoesGeneral";
               WS0D2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Gerenciador De Transmissoes General") ;
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
         }
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 1318140), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("transactions.gerenciadordetransmissoesgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A55IdTransmissao,4,0))}, new string[] {"IdTransmissao"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA55IdTransmissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA55IdTransmissao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IDTRANSMISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55IdTransmissao), 4, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm0D2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "Transactions.GerenciadorDeTransmissoesGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Gerenciador De Transmissoes General" ;
      }

      protected void WB0D0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "transactions.gerenciadordetransmissoesgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "end", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Modifica", bttBtnupdate_Jsonclick, 7, "Modifica", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110d1_client"+"'", TempTags, "", 2, "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Eliminar", bttBtndelete_Jsonclick, 7, "Eliminar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120d1_client"+"'", TempTags, "", 2, "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInscricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInscricao_Internalname, "Inscricao", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtInscricao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Inscricao), 9, 0, ",", "")), StringUtil.LTrim( ((edtInscricao_Enabled!=0) ? context.localUtil.Format( (decimal)(A1Inscricao), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1Inscricao), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInscricao_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtInscricao_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNome_Internalname, "Nome", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtNome_Internalname, A2Nome, StringUtil.RTrim( context.localUtil.Format( A2Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNascimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNascimento_Internalname, "Nascimento", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtNascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtNascimento_Internalname, context.localUtil.Format(A8Nascimento, "99/99/9999"), context.localUtil.Format( A8Nascimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNascimento_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtNascimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtNascimento_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFalecimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFalecimento_Internalname, "Falecimento", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtFalecimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFalecimento_Internalname, context.localUtil.Format(A9Falecimento, "99/99/9999"), context.localUtil.Format( A9Falecimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,33);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFalecimento_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFalecimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtFalecimento_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFalecimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDataVelorio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDataVelorio_Internalname, "Velorio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtDataVelorio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtDataVelorio_Internalname, context.localUtil.Format(A56DataVelorio, "99/99/99"), context.localUtil.Format( A56DataVelorio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,38);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataVelorio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtDataVelorio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtDataVelorio_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataVelorio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHoraInicio_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHoraInicio_Internalname, "Inicio", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtHoraInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtHoraInicio_Internalname, context.localUtil.TToC( A57HoraInicio, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A57HoraInicio, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,43);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHoraInicio_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtHoraInicio_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtHoraInicio_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHoraInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHoraFim_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtHoraFim_Internalname, "Fim", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtHoraFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtHoraFim_Internalname, context.localUtil.TToC( A58HoraFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A58HoraFim, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHoraFim_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtHoraFim_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            GxWebStd.gx_bitmap( context, edtHoraFim_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHoraFim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoesGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAoVivo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkAoVivo_Internalname, "Vivo", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkAoVivo_Internalname, StringUtil.BoolToStr( A66AoVivo), "", "Vivo", 1, chkAoVivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0D2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
               }
            }
            Form.Meta.addItem("description", "Gerenciador De Transmissoes General", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0D0( ) ;
            }
         }
      }

      protected void WS0D2( )
      {
         START0D2( ) ;
         EVT0D2( ) ;
      }

      protected void EVT0D2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
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
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0D2( ) ;
            }
         }
      }

      protected void PA0D2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         A66AoVivo = StringUtil.StrToBool( StringUtil.BoolToStr( A66AoVivo));
         AssignAttri(sPrefix, false, "A66AoVivo", A66AoVivo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV11Pgmname = "Transactions.GerenciadorDeTransmissoesGeneral";
      }

      protected void RF0D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000D2 */
            pr_default.execute(0, new Object[] {A55IdTransmissao});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A66AoVivo = H000D2_A66AoVivo[0];
               AssignAttri(sPrefix, false, "A66AoVivo", A66AoVivo);
               A58HoraFim = H000D2_A58HoraFim[0];
               AssignAttri(sPrefix, false, "A58HoraFim", context.localUtil.TToC( A58HoraFim, 0, 5, 0, 3, "/", ":", " "));
               A57HoraInicio = H000D2_A57HoraInicio[0];
               AssignAttri(sPrefix, false, "A57HoraInicio", context.localUtil.TToC( A57HoraInicio, 0, 5, 0, 3, "/", ":", " "));
               A56DataVelorio = H000D2_A56DataVelorio[0];
               AssignAttri(sPrefix, false, "A56DataVelorio", context.localUtil.Format(A56DataVelorio, "99/99/99"));
               A2Nome = H000D2_A2Nome[0];
               AssignAttri(sPrefix, false, "A2Nome", A2Nome);
               A1Inscricao = H000D2_A1Inscricao[0];
               AssignAttri(sPrefix, false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
               /* Using cursor H000D3 */
               pr_datastore1.execute(0, new Object[] {A1Inscricao, A2Nome});
               A9Falecimento = H000D3_A9Falecimento[0];
               n9Falecimento = H000D3_n9Falecimento[0];
               AssignAttri(sPrefix, false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
               A8Nascimento = H000D3_A8Nascimento[0];
               n8Nascimento = H000D3_n8Nascimento[0];
               AssignAttri(sPrefix, false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
               pr_datastore1.close(0);
               /* Execute user event: Load */
               E140D2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_datastore1.close(0);
            WB0D0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0D2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV11Pgmname = "Transactions.GerenciadorDeTransmissoesGeneral";
         edtInscricao_Enabled = 0;
         AssignProp(sPrefix, false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         edtNome_Enabled = 0;
         AssignProp(sPrefix, false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         edtNascimento_Enabled = 0;
         AssignProp(sPrefix, false, edtNascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNascimento_Enabled), 5, 0), true);
         edtFalecimento_Enabled = 0;
         AssignProp(sPrefix, false, edtFalecimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFalecimento_Enabled), 5, 0), true);
         edtDataVelorio_Enabled = 0;
         AssignProp(sPrefix, false, edtDataVelorio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataVelorio_Enabled), 5, 0), true);
         edtHoraInicio_Enabled = 0;
         AssignProp(sPrefix, false, edtHoraInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHoraInicio_Enabled), 5, 0), true);
         edtHoraFim_Enabled = 0;
         AssignProp(sPrefix, false, edtHoraFim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHoraFim_Enabled), 5, 0), true);
         chkAoVivo.Enabled = 0;
         AssignProp(sPrefix, false, chkAoVivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAoVivo.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130D2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA55IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA55IdTransmissao"), ",", "."), 18, MidpointRounding.ToEven));
            A55IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"IDTRANSMISSAO"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A1Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInscricao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = cgiGet( edtNome_Internalname);
            AssignAttri(sPrefix, false, "A2Nome", A2Nome);
            A8Nascimento = context.localUtil.CToD( cgiGet( edtNascimento_Internalname), 2);
            n8Nascimento = false;
            AssignAttri(sPrefix, false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
            A9Falecimento = context.localUtil.CToD( cgiGet( edtFalecimento_Internalname), 2);
            n9Falecimento = false;
            AssignAttri(sPrefix, false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
            A56DataVelorio = context.localUtil.CToD( cgiGet( edtDataVelorio_Internalname), 2);
            AssignAttri(sPrefix, false, "A56DataVelorio", context.localUtil.Format(A56DataVelorio, "99/99/99"));
            A57HoraInicio = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraInicio_Internalname)));
            AssignAttri(sPrefix, false, "A57HoraInicio", context.localUtil.TToC( A57HoraInicio, 0, 5, 0, 3, "/", ":", " "));
            A58HoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraFim_Internalname)));
            AssignAttri(sPrefix, false, "A58HoraFim", context.localUtil.TToC( A58HoraFim, 0, 5, 0, 3, "/", ":", " "));
            A66AoVivo = StringUtil.StrToBool( cgiGet( chkAoVivo_Internalname));
            AssignAttri(sPrefix, false, "A66AoVivo", A66AoVivo);
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
         E130D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130D2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140D2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV11Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Transactions.GerenciadorDeTransmissoes";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "IdTransmissao";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6IdTransmissao), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A55IdTransmissao = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
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
         PA0D2( ) ;
         WS0D2( ) ;
         WE0D2( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA55IdTransmissao = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0D2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "transactions\\gerenciadordetransmissoesgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0D2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A55IdTransmissao = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
         }
         wcpOA55IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA55IdTransmissao"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A55IdTransmissao != wcpOA55IdTransmissao ) ) )
         {
            setjustcreated();
         }
         wcpOA55IdTransmissao = A55IdTransmissao;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA55IdTransmissao = cgiGet( sPrefix+"A55IdTransmissao_CTRL");
         if ( StringUtil.Len( sCtrlA55IdTransmissao) > 0 )
         {
            A55IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA55IdTransmissao), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
         }
         else
         {
            A55IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A55IdTransmissao_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0D2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A55IdTransmissao_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55IdTransmissao), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA55IdTransmissao)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A55IdTransmissao_CTRL", StringUtil.RTrim( sCtrlA55IdTransmissao));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202482519405949", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("transactions/gerenciadordetransmissoesgeneral.js", "?202482519405949", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkAoVivo.Name = "AOVIVO";
         chkAoVivo.WebTags = "";
         chkAoVivo.Caption = "Vivo";
         AssignProp(sPrefix, false, chkAoVivo_Internalname, "TitleCaption", chkAoVivo.Caption, true);
         chkAoVivo.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtInscricao_Internalname = sPrefix+"INSCRICAO";
         edtNome_Internalname = sPrefix+"NOME";
         edtNascimento_Internalname = sPrefix+"NASCIMENTO";
         edtFalecimento_Internalname = sPrefix+"FALECIMENTO";
         edtDataVelorio_Internalname = sPrefix+"DATAVELORIO";
         edtHoraInicio_Internalname = sPrefix+"HORAINICIO";
         edtHoraFim_Internalname = sPrefix+"HORAFIM";
         chkAoVivo_Internalname = sPrefix+"AOVIVO";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Design.GoldLegacy", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         chkAoVivo.Caption = "Vivo";
         chkAoVivo.Enabled = 0;
         edtHoraFim_Jsonclick = "";
         edtHoraFim_Enabled = 0;
         edtHoraInicio_Jsonclick = "";
         edtHoraInicio_Enabled = 0;
         edtDataVelorio_Jsonclick = "";
         edtDataVelorio_Enabled = 0;
         edtFalecimento_Jsonclick = "";
         edtFalecimento_Enabled = 0;
         edtNascimento_Jsonclick = "";
         edtNascimento_Enabled = 0;
         edtNome_Jsonclick = "";
         edtNome_Enabled = 0;
         edtInscricao_Jsonclick = "";
         edtInscricao_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9"},{"av":"A66AoVivo","fld":"AOVIVO"}]}""");
         setEventMetadata("'DOUPDATE'","""{"handler":"E110D1","iparms":[{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9"}]}""");
         setEventMetadata("'DODELETE'","""{"handler":"E120D1","iparms":[{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_INSCRICAO","""{"handler":"Valid_Inscricao","iparms":[]}""");
         setEventMetadata("VALID_NOME","""{"handler":"Valid_Nome","iparms":[]}""");
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
         sPrefix = "";
         AV11Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A2Nome = "";
         A8Nascimento = DateTime.MinValue;
         A9Falecimento = DateTime.MinValue;
         A56DataVelorio = DateTime.MinValue;
         A57HoraInicio = (DateTime)(DateTime.MinValue);
         A58HoraFim = (DateTime)(DateTime.MinValue);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H000D2_A55IdTransmissao = new short[1] ;
         H000D2_A66AoVivo = new bool[] {false} ;
         H000D2_A58HoraFim = new DateTime[] {DateTime.MinValue} ;
         H000D2_A57HoraInicio = new DateTime[] {DateTime.MinValue} ;
         H000D2_A56DataVelorio = new DateTime[] {DateTime.MinValue} ;
         H000D2_A2Nome = new string[] {""} ;
         H000D2_A1Inscricao = new int[1] ;
         H000D3_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         H000D3_n9Falecimento = new bool[] {false} ;
         H000D3_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         H000D3_n8Nascimento = new bool[] {false} ;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA55IdTransmissao = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.transactions.gerenciadordetransmissoesgeneral__datastore1(),
            new Object[][] {
                new Object[] {
               H000D3_A9Falecimento, H000D3_n9Falecimento, H000D3_A8Nascimento, H000D3_n8Nascimento
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.transactions.gerenciadordetransmissoesgeneral__default(),
            new Object[][] {
                new Object[] {
               H000D2_A55IdTransmissao, H000D2_A66AoVivo, H000D2_A58HoraFim, H000D2_A57HoraInicio, H000D2_A56DataVelorio, H000D2_A2Nome, H000D2_A1Inscricao
               }
            }
         );
         AV11Pgmname = "Transactions.GerenciadorDeTransmissoesGeneral";
         /* GeneXus formulas. */
         AV11Pgmname = "Transactions.GerenciadorDeTransmissoesGeneral";
      }

      private short A55IdTransmissao ;
      private short wcpOA55IdTransmissao ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6IdTransmissao ;
      private short nGXWrapped ;
      private int A1Inscricao ;
      private int edtInscricao_Enabled ;
      private int edtNome_Enabled ;
      private int edtNascimento_Enabled ;
      private int edtFalecimento_Enabled ;
      private int edtDataVelorio_Enabled ;
      private int edtHoraInicio_Enabled ;
      private int edtHoraFim_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV11Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtInscricao_Internalname ;
      private string edtInscricao_Jsonclick ;
      private string edtNome_Internalname ;
      private string edtNome_Jsonclick ;
      private string edtNascimento_Internalname ;
      private string edtNascimento_Jsonclick ;
      private string edtFalecimento_Internalname ;
      private string edtFalecimento_Jsonclick ;
      private string edtDataVelorio_Internalname ;
      private string edtDataVelorio_Jsonclick ;
      private string edtHoraInicio_Internalname ;
      private string edtHoraInicio_Jsonclick ;
      private string edtHoraFim_Internalname ;
      private string edtHoraFim_Jsonclick ;
      private string chkAoVivo_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA55IdTransmissao ;
      private DateTime A57HoraInicio ;
      private DateTime A58HoraFim ;
      private DateTime A8Nascimento ;
      private DateTime A9Falecimento ;
      private DateTime A56DataVelorio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A66AoVivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n9Falecimento ;
      private bool n8Nascimento ;
      private bool returnInSub ;
      private string A2Nome ;
      private GXWebForm Form ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkAoVivo ;
      private IDataStoreProvider pr_default ;
      private short[] H000D2_A55IdTransmissao ;
      private bool[] H000D2_A66AoVivo ;
      private DateTime[] H000D2_A58HoraFim ;
      private DateTime[] H000D2_A57HoraInicio ;
      private DateTime[] H000D2_A56DataVelorio ;
      private string[] H000D2_A2Nome ;
      private int[] H000D2_A1Inscricao ;
      private IDataStoreProvider pr_datastore1 ;
      private DateTime[] H000D3_A9Falecimento ;
      private bool[] H000D3_n9Falecimento ;
      private DateTime[] H000D3_A8Nascimento ;
      private bool[] H000D3_n8Nascimento ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class gerenciadordetransmissoesgeneral__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000D3;
          prmH000D3 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000D3", "SELECT [Falecimento], [Nascimento] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000D3,1, GxCacheFrequency.OFF ,true,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class gerenciadordetransmissoesgeneral__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH000D2;
        prmH000D2 = new Object[] {
        new ParDef("@IdTransmissao",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("H000D2", "SELECT [IdTransmissao], [AoVivo], [HoraFim], [HoraInicio], [DataVelorio], [Nome], [Inscricao] FROM [GerenciadorDeTransmissoes] WHERE [IdTransmissao] = @IdTransmissao ORDER BY [IdTransmissao] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000D2,1, GxCacheFrequency.OFF ,true,true )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.getBool(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
     }
  }

}

}
