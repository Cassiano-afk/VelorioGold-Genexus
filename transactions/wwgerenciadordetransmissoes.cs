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
   public class wwgerenciadordetransmissoes : GXDataArea
   {
      public wwgerenciadordetransmissoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Design.GoldLegacy", true);
      }

      public wwgerenciadordetransmissoes( IGxContext context )
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
         chkavAovivo = new GXCheckbox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_29 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_29"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_29_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_29_idx = GetPar( "sGXsfl_29_idx");
         AV14Update = GetPar( "Update");
         AV15Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV11DataVelorio = context.localUtil.ParseDateParm( GetPar( "DataVelorio"));
         AV12Inscricao = (int)(Math.Round(NumberUtil.Val( GetPar( "Inscricao"), "."), 18, MidpointRounding.ToEven));
         AV13Nome = GetPar( "Nome");
         AV16ADVANCED_LABEL_TEMPLATE = GetPar( "ADVANCED_LABEL_TEMPLATE");
         AV14Update = GetPar( "Update");
         AV15Delete = GetPar( "Delete");
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         A55IdTransmissao = (short)(Math.Round(NumberUtil.Val( GetPar( "IdTransmissao"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV11DataVelorio, AV12Inscricao, AV13Nome, AV16ADVANCED_LABEL_TEMPLATE, AV14Update, AV15Delete, Gx_date, A55IdTransmissao) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA0C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0C2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("transactions.wwgerenciadordetransmissoes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV16ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "IDTRANSMISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55IdTransmissao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_IDTRANSMISSAO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A55IdTransmissao), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDATAVELORIO", context.localUtil.Format(AV11DataVelorio, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vINSCRICAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Inscricao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vNOME", AV13Nome);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_29", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_29), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV16ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "IDTRANSMISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55IdTransmissao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_IDTRANSMISSAO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A55IdTransmissao), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "INSCRICAOFILTERCONTAINER_Class", StringUtil.RTrim( divInscricaofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "NOMEFILTERCONTAINER_Class", StringUtil.RTrim( divNomefiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0C2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("transactions.wwgerenciadordetransmissoes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Transactions.WWGerenciadorDeTransmissoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Work With Gerenciador De Transmissões | Velório Gold" ;
      }

      protected void WB0C0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__title-cell", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Gerenciador De Transmissões", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__actions-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Inserir", bttBtninsert_Jsonclick, 5, "Inserir", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDatavelorio_Internalname, "Data Velorio", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_29_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavDatavelorio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavDatavelorio_Internalname, context.localUtil.Format(AV11DataVelorio, "99/99/99"), context.localUtil.Format( AV11DataVelorio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDatavelorio_Jsonclick, 0, "attribute-search", "", "", "", "", 1, edtavDatavelorio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_bitmap( context, edtavDatavelorio_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavDatavelorio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__toggle-cell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Show Filters", bttBtntoggle_Jsonclick, 7, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110c1_client"+"'", TempTags, "", 2, "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl29( ) ;
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            nRC_GXsfl_29 = (int)(nGXsfl_29_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 ww__filters-cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            ClassString = "filters-container__close";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggleontable_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Hide Filters", bttBtntoggleontable_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110c1_client"+"'", TempTags, "", 2, "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInscricaofiltercontainer_Internalname, 1, 0, "px", 0, "px", divInscricaofiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinscricaofilter_Internalname, lblLblinscricaofilter_Caption, "", "", lblLblinscricaofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "filter-item__label", 0, "", 1, 1, 0, 1, "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavInscricao_Internalname, "Inscricao", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_29_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavInscricao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Inscricao), 9, 0, ",", "")), StringUtil.LTrim( ((edtavInscricao_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12Inscricao), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV12Inscricao), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavInscricao_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavInscricao_Visible, edtavInscricao_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNomefiltercontainer_Internalname, 1, 0, "px", 0, "px", divNomefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblnomefilter_Internalname, lblLblnomefilter_Caption, "", "", lblLblnomefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "filter-item__label", 0, "", 1, 1, 0, 1, "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNome_Internalname, "Nome", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_29_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNome_Internalname, AV13Nome, StringUtil.RTrim( context.localUtil.Format( AV13Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNome_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavNome_Visible, edtavNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Transactions/WWGerenciadorDeTransmissoes.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0C2( )
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
         Form.Meta.addItem("description", "Work With Gerenciador De Transmissões | Velório Gold", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0C0( ) ;
      }

      protected void WS0C2( )
      {
         START0C2( ) ;
         EVT0C2( ) ;
      }

      protected void EVT0C2( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E120C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_29_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
                              SubsflControlProps_292( ) ;
                              AV21AoVivo = StringUtil.StrToBool( cgiGet( chkavAovivo_Internalname));
                              AssignAttri("", false, chkavAovivo_Internalname, AV21AoVivo);
                              A1Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInscricao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A2Nome = cgiGet( edtNome_Internalname);
                              A8Nascimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtNascimento_Internalname), 0));
                              n8Nascimento = false;
                              A9Falecimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtFalecimento_Internalname), 0));
                              n9Falecimento = false;
                              A56DataVelorio = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtDataVelorio_Internalname), 0));
                              A57HoraInicio = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraInicio_Internalname), 0));
                              A58HoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraFim_Internalname), 0));
                              AV14Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV14Update);
                              AV15Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV15Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E140C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Grid.Load */
                                    E150C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Datavelorio Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vDATAVELORIO"), 0) != AV11DataVelorio )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Inscricao Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vINSCRICAO"), ",", ".") != Convert.ToDecimal( AV12Inscricao )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Nome Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNOME"), AV13Nome) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
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
      }

      protected void WE0C2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0C2( )
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
               GX_FocusControl = edtavDatavelorio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_292( ) ;
         while ( nGXsfl_29_idx <= nRC_GXsfl_29 )
         {
            sendrow_292( ) ;
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       DateTime AV11DataVelorio ,
                                       int AV12Inscricao ,
                                       string AV13Nome ,
                                       string AV16ADVANCED_LABEL_TEMPLATE ,
                                       string AV14Update ,
                                       string AV15Delete ,
                                       DateTime Gx_date ,
                                       short A55IdTransmissao )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
      }

      public void Refresh( )
      {
         GRID_nFirstRecordOnPage = 0;
         GRID_nCurrentRecord = 0;
         GXCCtl = "GRID_nFirstRecordOnPage_" + sGXsfl_29_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         send_integrity_hashes( ) ;
         RF0C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV22Pgmname = "Transactions.WWGerenciadorDeTransmissoes";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      protected int subGridclient_rec_count_fnc( )
      {
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11DataVelorio ,
                                              AV12Inscricao ,
                                              AV13Nome ,
                                              A56DataVelorio ,
                                              A1Inscricao ,
                                              A2Nome } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT
                                              }
         });
         lV13Nome = StringUtil.Concat( StringUtil.RTrim( AV13Nome), "%", "");
         /* Using cursor H000C2 */
         pr_default.execute(0, new Object[] {AV11DataVelorio, AV12Inscricao, lV13Nome});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A55IdTransmissao = H000C2_A55IdTransmissao[0];
            A58HoraFim = H000C2_A58HoraFim[0];
            A57HoraInicio = H000C2_A57HoraInicio[0];
            A56DataVelorio = H000C2_A56DataVelorio[0];
            A2Nome = H000C2_A2Nome[0];
            A1Inscricao = H000C2_A1Inscricao[0];
            /* Using cursor H000C3 */
            pr_datastore1.execute(0, new Object[] {A1Inscricao, A2Nome});
            A9Falecimento = H000C3_A9Falecimento[0];
            n9Falecimento = H000C3_n9Falecimento[0];
            A8Nascimento = H000C3_A8Nascimento[0];
            n8Nascimento = H000C3_n8Nascimento[0];
            pr_datastore1.close(0);
            GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         pr_datastore1.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF0C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 29;
         /* Execute user event: Refresh */
         E140C2 ();
         nGXsfl_29_idx = (int)(1+GRID_nFirstRecordOnPage);
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         bGXsfl_29_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ww__grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_292( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV11DataVelorio ,
                                                 AV12Inscricao ,
                                                 AV13Nome ,
                                                 A56DataVelorio ,
                                                 A1Inscricao ,
                                                 A2Nome } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT
                                                 }
            });
            lV13Nome = StringUtil.Concat( StringUtil.RTrim( AV13Nome), "%", "");
            /* Using cursor H000C4 */
            pr_default.execute(1, new Object[] {AV11DataVelorio, AV12Inscricao, lV13Nome});
            nGXsfl_29_idx = (int)(1+GRID_nFirstRecordOnPage);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A55IdTransmissao = H000C4_A55IdTransmissao[0];
               A58HoraFim = H000C4_A58HoraFim[0];
               A57HoraInicio = H000C4_A57HoraInicio[0];
               A56DataVelorio = H000C4_A56DataVelorio[0];
               A2Nome = H000C4_A2Nome[0];
               A1Inscricao = H000C4_A1Inscricao[0];
               /* Using cursor H000C5 */
               pr_datastore1.execute(1, new Object[] {A1Inscricao, A2Nome});
               A9Falecimento = H000C5_A9Falecimento[0];
               n9Falecimento = H000C5_n9Falecimento[0];
               A8Nascimento = H000C5_A8Nascimento[0];
               n8Nascimento = H000C5_n8Nascimento[0];
               pr_datastore1.close(1);
               /* Execute user event: Grid.Load */
               E150C2 ();
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            pr_datastore1.close(1);
            wbEnd = 29;
            WB0C0( ) ;
         }
         bGXsfl_29_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0C2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV16ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "IDTRANSMISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55IdTransmissao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_IDTRANSMISSAO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A55IdTransmissao), "ZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(subGridclient_rec_count_fnc()) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11DataVelorio, AV12Inscricao, AV13Nome, AV16ADVANCED_LABEL_TEMPLATE, AV14Update, AV15Delete, Gx_date, A55IdTransmissao) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         if ( GRID_nEOF == 1 )
         {
            GRID_nFirstRecordOnPage = GRID_nCurrentRecord;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11DataVelorio, AV12Inscricao, AV13Nome, AV16ADVANCED_LABEL_TEMPLATE, AV14Update, AV15Delete, Gx_date, A55IdTransmissao) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11DataVelorio, AV12Inscricao, AV13Nome, AV16ADVANCED_LABEL_TEMPLATE, AV14Update, AV15Delete, Gx_date, A55IdTransmissao) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11DataVelorio, AV12Inscricao, AV13Nome, AV16ADVANCED_LABEL_TEMPLATE, AV14Update, AV15Delete, Gx_date, A55IdTransmissao) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11DataVelorio, AV12Inscricao, AV13Nome, AV16ADVANCED_LABEL_TEMPLATE, AV14Update, AV15Delete, Gx_date, A55IdTransmissao) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11DataVelorio = context.localUtil.CToD( GridState.FilterValues("Datavelorio"), 2);
            AssignAttri("", false, "AV11DataVelorio", context.localUtil.Format(AV11DataVelorio, "99/99/99"));
            AV12Inscricao = (int)(Math.Round(NumberUtil.Val( GridState.FilterValues("Inscricao"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12Inscricao", StringUtil.LTrimStr( (decimal)(AV12Inscricao), 9, 0));
            AV13Nome = GridState.FilterValues("Nome");
            AssignAttri("", false, "AV13Nome", AV13Nome);
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.ClearFilterValues();
         GridState.AddFilterValue("DataVelorio", context.localUtil.Format(AV11DataVelorio, "99/99/99"));
         GridState.AddFilterValue("Inscricao", StringUtil.Str( (decimal)(AV12Inscricao), 9, 0));
         GridState.AddFilterValue("Nome", AV13Nome);
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV22Pgmname = "Transactions.WWGerenciadorDeTransmissoes";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtInscricao_Enabled = 0;
         edtNome_Enabled = 0;
         edtNascimento_Enabled = 0;
         edtFalecimento_Enabled = 0;
         edtDataVelorio_Enabled = 0;
         edtHoraInicio_Enabled = 0;
         edtHoraFim_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_29 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_29"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavDatavelorio_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data Velorio"}), 1, "vDATAVELORIO");
               GX_FocusControl = edtavDatavelorio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11DataVelorio = DateTime.MinValue;
               AssignAttri("", false, "AV11DataVelorio", context.localUtil.Format(AV11DataVelorio, "99/99/99"));
            }
            else
            {
               AV11DataVelorio = context.localUtil.CToD( cgiGet( edtavDatavelorio_Internalname), 2);
               AssignAttri("", false, "AV11DataVelorio", context.localUtil.Format(AV11DataVelorio, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavInscricao_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavInscricao_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vINSCRICAO");
               GX_FocusControl = edtavInscricao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12Inscricao = 0;
               AssignAttri("", false, "AV12Inscricao", StringUtil.LTrimStr( (decimal)(AV12Inscricao), 9, 0));
            }
            else
            {
               AV12Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavInscricao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Inscricao", StringUtil.LTrimStr( (decimal)(AV12Inscricao), 9, 0));
            }
            AV13Nome = cgiGet( edtavNome_Internalname);
            AssignAttri("", false, "AV13Nome", AV13Nome);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vDATAVELORIO"), 2) ) != DateTimeUtil.ResetTime ( AV11DataVelorio ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vINSCRICAO"), ",", ".") != Convert.ToDecimal( AV12Inscricao )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNOME"), AV13Nome) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E130C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130C2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV22Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV22Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV14Update = "Modifica";
         AssignAttri("", false, edtavUpdate_Internalname, AV14Update);
         AV15Delete = "Eliminar";
         AssignAttri("", false, edtavDelete_Internalname, AV15Delete);
         edtavInscricao_Visible = 0;
         AssignProp("", false, edtavInscricao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavInscricao_Visible), 5, 0), true);
         edtavNome_Visible = 0;
         AssignProp("", false, edtavNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNome_Visible), 5, 0), true);
         Form.Caption = "Gerenciador De Transmissoes";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV16ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV16ADVANCED_LABEL_TEMPLATE", AV16ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "")), context));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E140C2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
         bttBtntoggle_Class = "ww__button-filters--show";
         AssignProp("", false, bttBtntoggle_Internalname, "Class", bttBtntoggle_Class, true);
         if ( (0==AV12Inscricao) )
         {
            lblLblinscricaofilter_Caption = "Inscricao";
            AssignProp("", false, lblLblinscricaofilter_Internalname, "Caption", lblLblinscricaofilter_Caption, true);
         }
         else
         {
            bttBtntoggle_Class = "ww__button-filters--applied";
            AssignProp("", false, bttBtntoggle_Internalname, "Class", bttBtntoggle_Class, true);
            lblLblinscricaofilter_Caption = StringUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "Inscricao", StringUtil.LTrimStr( (decimal)(AV12Inscricao), 9, 0), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblinscricaofilter_Internalname, "Caption", lblLblinscricaofilter_Caption, true);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13Nome)) )
         {
            lblLblnomefilter_Caption = "Nome";
            AssignProp("", false, lblLblnomefilter_Internalname, "Caption", lblLblnomefilter_Caption, true);
         }
         else
         {
            bttBtntoggle_Class = "ww__button-filters--applied";
            AssignProp("", false, bttBtntoggle_Internalname, "Class", bttBtntoggle_Class, true);
            lblLblnomefilter_Caption = StringUtil.Format( AV16ADVANCED_LABEL_TEMPLATE, "Nome", AV13Nome, "", "", "", "", "", "", "");
            AssignProp("", false, lblLblnomefilter_Internalname, "Caption", lblLblnomefilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E150C2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            edtavUpdate_Link = formatLink("transactions.gerenciadordetransmissoes.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A55IdTransmissao,4,0))}, new string[] {"Mode","IdTransmissao"}) ;
            edtavDelete_Link = formatLink("transactions.gerenciadordetransmissoes.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A55IdTransmissao,4,0))}, new string[] {"Mode","IdTransmissao"}) ;
            edtDataVelorio_Link = formatLink("transactions.viewgerenciadordetransmissoes.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A55IdTransmissao,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"IdTransmissao","TabCode"}) ;
            AV20CurrentTime = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            AV21AoVivo = false;
            AssignAttri("", false, chkavAovivo_Internalname, AV21AoVivo);
            AV18HoraInicio = A57HoraInicio;
            AV19HoraFim = A58HoraFim;
            AV11DataVelorio = A56DataVelorio;
            AssignAttri("", false, "AV11DataVelorio", context.localUtil.Format(AV11DataVelorio, "99/99/99"));
            if ( ( AV20CurrentTime > AV18HoraInicio ) && ( AV20CurrentTime < AV19HoraFim ) && ( DateTimeUtil.ResetTime ( AV11DataVelorio ) == DateTimeUtil.ResetTime ( Gx_date ) ) )
            {
               AV21AoVivo = true;
               AssignAttri("", false, chkavAovivo_Internalname, AV21AoVivo);
            }
            else
            {
               AV21AoVivo = false;
               AssignAttri("", false, chkavAovivo_Internalname, AV21AoVivo);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 29;
            }
            sendrow_292( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_29_Refreshing )
         {
            DoAjaxLoad(29, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E120C2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("transactions.gerenciadordetransmissoes.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","IdTransmissao"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV22Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Transactions.GerenciadorDeTransmissoes";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         PA0C2( ) ;
         WS0C2( ) ;
         WE0C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248251941118", true, true);
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
         context.AddJavascriptSource("transactions/wwgerenciadordetransmissoes.js", "?202482519411110", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_292( )
      {
         chkavAovivo_Internalname = "vAOVIVO_"+sGXsfl_29_idx;
         edtInscricao_Internalname = "INSCRICAO_"+sGXsfl_29_idx;
         edtNome_Internalname = "NOME_"+sGXsfl_29_idx;
         edtNascimento_Internalname = "NASCIMENTO_"+sGXsfl_29_idx;
         edtFalecimento_Internalname = "FALECIMENTO_"+sGXsfl_29_idx;
         edtDataVelorio_Internalname = "DATAVELORIO_"+sGXsfl_29_idx;
         edtHoraInicio_Internalname = "HORAINICIO_"+sGXsfl_29_idx;
         edtHoraFim_Internalname = "HORAFIM_"+sGXsfl_29_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_29_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_29_idx;
      }

      protected void SubsflControlProps_fel_292( )
      {
         chkavAovivo_Internalname = "vAOVIVO_"+sGXsfl_29_fel_idx;
         edtInscricao_Internalname = "INSCRICAO_"+sGXsfl_29_fel_idx;
         edtNome_Internalname = "NOME_"+sGXsfl_29_fel_idx;
         edtNascimento_Internalname = "NASCIMENTO_"+sGXsfl_29_fel_idx;
         edtFalecimento_Internalname = "FALECIMENTO_"+sGXsfl_29_fel_idx;
         edtDataVelorio_Internalname = "DATAVELORIO_"+sGXsfl_29_fel_idx;
         edtHoraInicio_Internalname = "HORAINICIO_"+sGXsfl_29_fel_idx;
         edtHoraFim_Internalname = "HORAFIM_"+sGXsfl_29_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_29_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_29_fel_idx;
      }

      protected void sendrow_292( )
      {
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         WB0C0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_29_idx - GRID_nFirstRecordOnPage <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_29_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ww__grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_29_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vAOVIVO_" + sGXsfl_29_idx;
            chkavAovivo.Name = GXCCtl;
            chkavAovivo.WebTags = "";
            chkavAovivo.Caption = "";
            AssignProp("", false, chkavAovivo_Internalname, "TitleCaption", chkavAovivo.Caption, !bGXsfl_29_Refreshing);
            chkavAovivo.CheckedValue = "false";
            AV21AoVivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV21AoVivo));
            AssignAttri("", false, chkavAovivo_Internalname, AV21AoVivo);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavAovivo_Internalname,StringUtil.BoolToStr( AV21AoVivo),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInscricao_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Inscricao), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A1Inscricao), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInscricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNome_Internalname,(string)A2Nome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNascimento_Internalname,context.localUtil.Format(A8Nascimento, "99/99/9999"),context.localUtil.Format( A8Nascimento, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNascimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFalecimento_Internalname,context.localUtil.Format(A9Falecimento, "99/99/9999"),context.localUtil.Format( A9Falecimento, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFalecimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDataVelorio_Internalname,context.localUtil.Format(A56DataVelorio, "99/99/99"),context.localUtil.Format( A56DataVelorio, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtDataVelorio_Link,(string)"",(string)"",(string)"",(string)edtDataVelorio_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHoraInicio_Internalname,context.localUtil.TToC( A57HoraInicio, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A57HoraInicio, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHoraInicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Time",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHoraFim_Internalname,context.localUtil.TToC( A58HoraFim, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A58HoraFim, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHoraFim_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column column-optional",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Time",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV14Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_29_idx + "',29)\"";
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV15Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes0C2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         /* End function sendrow_292 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vAOVIVO_" + sGXsfl_29_idx;
         chkavAovivo.Name = GXCCtl;
         chkavAovivo.WebTags = "";
         chkavAovivo.Caption = "";
         AssignProp("", false, chkavAovivo_Internalname, "TitleCaption", chkavAovivo.Caption, !bGXsfl_29_Refreshing);
         chkavAovivo.CheckedValue = "false";
         AV21AoVivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV21AoVivo));
         AssignAttri("", false, chkavAovivo_Internalname, AV21AoVivo);
         /* End function init_web_controls */
      }

      protected void StartGridControl29( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"29\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ww__grid", 0, "", "", 1, 1, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ao Vivo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Inscrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nascimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Falecimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data Velório") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Inicio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Fim") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV21AoVivo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Inscricao), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2Nome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A8Nascimento, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A9Falecimento, "99/99/9999")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A56DataVelorio, "99/99/99")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtDataVelorio_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A57HoraInicio, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A58HoraFim, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV14Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV15Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         bttBtninsert_Internalname = "BTNINSERT";
         edtavDatavelorio_Internalname = "vDATAVELORIO";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         divTabletop_Internalname = "TABLETOP";
         chkavAovivo_Internalname = "vAOVIVO";
         edtInscricao_Internalname = "INSCRICAO";
         edtNome_Internalname = "NOME";
         edtNascimento_Internalname = "NASCIMENTO";
         edtFalecimento_Internalname = "FALECIMENTO";
         edtDataVelorio_Internalname = "DATAVELORIO";
         edtHoraInicio_Internalname = "HORAINICIO";
         edtHoraFim_Internalname = "HORAFIM";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         bttBtntoggleontable_Internalname = "BTNTOGGLEONTABLE";
         lblLblinscricaofilter_Internalname = "LBLINSCRICAOFILTER";
         edtavInscricao_Internalname = "vINSCRICAO";
         divInscricaofiltercontainer_Internalname = "INSCRICAOFILTERCONTAINER";
         lblLblnomefilter_Internalname = "LBLNOMEFILTER";
         edtavNome_Internalname = "vNOME";
         divNomefiltercontainer_Internalname = "NOMEFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtHoraFim_Jsonclick = "";
         edtHoraInicio_Jsonclick = "";
         edtDataVelorio_Jsonclick = "";
         edtDataVelorio_Link = "";
         edtFalecimento_Jsonclick = "";
         edtNascimento_Jsonclick = "";
         edtNome_Jsonclick = "";
         edtInscricao_Jsonclick = "";
         chkavAovivo.Caption = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtHoraFim_Enabled = 0;
         edtHoraInicio_Enabled = 0;
         edtDataVelorio_Enabled = 0;
         edtFalecimento_Enabled = 0;
         edtNascimento_Enabled = 0;
         edtNome_Enabled = 0;
         edtInscricao_Enabled = 0;
         edtavNome_Jsonclick = "";
         edtavNome_Enabled = 1;
         edtavNome_Visible = 1;
         lblLblnomefilter_Caption = "Nome";
         edtavInscricao_Jsonclick = "";
         edtavInscricao_Enabled = 1;
         edtavInscricao_Visible = 1;
         lblLblinscricaofilter_Caption = "Inscrição";
         bttBtntoggle_Class = "ww__button-filters--hide";
         bttBtntoggle_Tooltiptext = "Show Filters";
         edtavDatavelorio_Jsonclick = "";
         edtavDatavelorio_Enabled = 1;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 ww__grid-cell--expanded";
         divNomefiltercontainer_Class = "filters-container__item";
         divInscricaofiltercontainer_Class = "filters-container__item";
         divFilterscontainer_Class = "filters-container";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Work With Gerenciador De Transmissões | Velório Gold";
         subGrid_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO"},{"av":"AV14Update","fld":"vUPDATE"},{"av":"AV15Delete","fld":"vDELETE"},{"av":"AV12Inscricao","fld":"vINSCRICAO","pic":"ZZZZZZZZ9"},{"av":"AV13Nome","fld":"vNOME"},{"av":"AV16ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("REFRESH",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblinscricaofilter_Caption","ctrl":"LBLINSCRICAOFILTER","prop":"Caption"},{"av":"lblLblnomefilter_Caption","ctrl":"LBLNOMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E110C1","iparms":[{"av":"divFilterscontainer_Class","ctrl":"FILTERSCONTAINER","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divFilterscontainer_Class","ctrl":"FILTERSCONTAINER","prop":"Class"},{"av":"divGridcell_Class","ctrl":"GRIDCELL","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Tooltiptext"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E150C2","iparms":[{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9","hsh":true},{"av":"A57HoraInicio","fld":"HORAINICIO","pic":"99:99"},{"av":"A58HoraFim","fld":"HORAFIM","pic":"99:99"},{"av":"A56DataVelorio","fld":"DATAVELORIO"},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtavUpdate_Link","ctrl":"vUPDATE","prop":"Link"},{"av":"edtavDelete_Link","ctrl":"vDELETE","prop":"Link"},{"av":"edtDataVelorio_Link","ctrl":"DATAVELORIO","prop":"Link"},{"av":"AV21AoVivo","fld":"vAOVIVO"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO"}]}""");
         setEventMetadata("'DOINSERT'","""{"handler":"E120C2","iparms":[{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO"},{"av":"AV14Update","fld":"vUPDATE"},{"av":"AV15Delete","fld":"vDELETE"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9","hsh":true},{"av":"AV12Inscricao","fld":"vINSCRICAO","pic":"ZZZZZZZZ9"},{"av":"AV16ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true},{"av":"AV13Nome","fld":"vNOME"}]""");
         setEventMetadata("GRID_FIRSTPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblinscricaofilter_Caption","ctrl":"LBLINSCRICAOFILTER","prop":"Caption"},{"av":"lblLblnomefilter_Caption","ctrl":"LBLNOMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO"},{"av":"AV14Update","fld":"vUPDATE"},{"av":"AV15Delete","fld":"vDELETE"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9","hsh":true},{"av":"AV12Inscricao","fld":"vINSCRICAO","pic":"ZZZZZZZZ9"},{"av":"AV16ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true},{"av":"AV13Nome","fld":"vNOME"}]""");
         setEventMetadata("GRID_PREVPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblinscricaofilter_Caption","ctrl":"LBLINSCRICAOFILTER","prop":"Caption"},{"av":"lblLblnomefilter_Caption","ctrl":"LBLNOMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO"},{"av":"AV14Update","fld":"vUPDATE"},{"av":"AV15Delete","fld":"vDELETE"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9","hsh":true},{"av":"AV12Inscricao","fld":"vINSCRICAO","pic":"ZZZZZZZZ9"},{"av":"AV16ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true},{"av":"AV13Nome","fld":"vNOME"}]""");
         setEventMetadata("GRID_NEXTPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblinscricaofilter_Caption","ctrl":"LBLINSCRICAOFILTER","prop":"Caption"},{"av":"lblLblnomefilter_Caption","ctrl":"LBLNOMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage"},{"av":"GRID_nEOF"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO"},{"av":"AV14Update","fld":"vUPDATE"},{"av":"AV15Delete","fld":"vDELETE"},{"av":"Gx_date","fld":"vTODAY","hsh":true},{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9","hsh":true},{"av":"AV12Inscricao","fld":"vINSCRICAO","pic":"ZZZZZZZZ9"},{"av":"AV16ADVANCED_LABEL_TEMPLATE","fld":"vADVANCED_LABEL_TEMPLATE","hsh":true},{"av":"AV13Nome","fld":"vNOME"}]""");
         setEventMetadata("GRID_LASTPAGE",""","oparms":[{"ctrl":"BTNTOGGLE","prop":"Class"},{"av":"lblLblinscricaofilter_Caption","ctrl":"LBLINSCRICAOFILTER","prop":"Caption"},{"av":"lblLblnomefilter_Caption","ctrl":"LBLNOMEFILTER","prop":"Caption"}]}""");
         setEventMetadata("VALIDV_DATAVELORIO","""{"handler":"Validv_Datavelorio","iparms":[]}""");
         setEventMetadata("VALID_INSCRICAO","""{"handler":"Valid_Inscricao","iparms":[]}""");
         setEventMetadata("VALID_NOME","""{"handler":"Valid_Nome","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Delete","iparms":[]}""");
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
         AV14Update = "";
         AV15Delete = "";
         AV11DataVelorio = DateTime.MinValue;
         AV13Nome = "";
         AV16ADVANCED_LABEL_TEMPLATE = "";
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtntoggleontable_Jsonclick = "";
         lblLblinscricaofilter_Jsonclick = "";
         lblLblnomefilter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A2Nome = "";
         A8Nascimento = DateTime.MinValue;
         A9Falecimento = DateTime.MinValue;
         A56DataVelorio = DateTime.MinValue;
         A57HoraInicio = (DateTime)(DateTime.MinValue);
         A58HoraFim = (DateTime)(DateTime.MinValue);
         GXCCtl = "";
         AV22Pgmname = "";
         lV13Nome = "";
         H000C2_A55IdTransmissao = new short[1] ;
         H000C2_A58HoraFim = new DateTime[] {DateTime.MinValue} ;
         H000C2_A57HoraInicio = new DateTime[] {DateTime.MinValue} ;
         H000C2_A56DataVelorio = new DateTime[] {DateTime.MinValue} ;
         H000C2_A2Nome = new string[] {""} ;
         H000C2_A1Inscricao = new int[1] ;
         H000C3_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         H000C3_n9Falecimento = new bool[] {false} ;
         H000C3_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         H000C3_n8Nascimento = new bool[] {false} ;
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         H000C4_A55IdTransmissao = new short[1] ;
         H000C4_A58HoraFim = new DateTime[] {DateTime.MinValue} ;
         H000C4_A57HoraInicio = new DateTime[] {DateTime.MinValue} ;
         H000C4_A56DataVelorio = new DateTime[] {DateTime.MinValue} ;
         H000C4_A2Nome = new string[] {""} ;
         H000C4_A1Inscricao = new int[1] ;
         H000C5_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         H000C5_n9Falecimento = new bool[] {false} ;
         H000C5_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         H000C5_n8Nascimento = new bool[] {false} ;
         AV20CurrentTime = (DateTime)(DateTime.MinValue);
         AV18HoraInicio = (DateTime)(DateTime.MinValue);
         AV19HoraFim = (DateTime)(DateTime.MinValue);
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.transactions.wwgerenciadordetransmissoes__datastore1(),
            new Object[][] {
                new Object[] {
               H000C3_A9Falecimento, H000C3_n9Falecimento, H000C3_A8Nascimento, H000C3_n8Nascimento
               }
               , new Object[] {
               H000C5_A9Falecimento, H000C5_n9Falecimento, H000C5_A8Nascimento, H000C5_n8Nascimento
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.transactions.wwgerenciadordetransmissoes__default(),
            new Object[][] {
                new Object[] {
               H000C2_A55IdTransmissao, H000C2_A58HoraFim, H000C2_A57HoraInicio, H000C2_A56DataVelorio, H000C2_A2Nome, H000C2_A1Inscricao
               }
               , new Object[] {
               H000C4_A55IdTransmissao, H000C4_A58HoraFim, H000C4_A57HoraInicio, H000C4_A56DataVelorio, H000C4_A2Nome, H000C4_A1Inscricao
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV22Pgmname = "Transactions.WWGerenciadorDeTransmissoes";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV22Pgmname = "Transactions.WWGerenciadorDeTransmissoes";
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short A55IdTransmissao ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_29 ;
      private int subGrid_Rows ;
      private int nGXsfl_29_idx=1 ;
      private int AV12Inscricao ;
      private int edtavDatavelorio_Enabled ;
      private int edtavInscricao_Enabled ;
      private int edtavInscricao_Visible ;
      private int edtavNome_Visible ;
      private int edtavNome_Enabled ;
      private int A1Inscricao ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GridPageCount ;
      private int edtInscricao_Enabled ;
      private int edtNome_Enabled ;
      private int edtNascimento_Enabled ;
      private int edtFalecimento_Enabled ;
      private int edtDataVelorio_Enabled ;
      private int edtHoraInicio_Enabled ;
      private int edtHoraFim_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string divFilterscontainer_Class ;
      private string divInscricaofiltercontainer_Class ;
      private string divNomefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_29_idx="0001" ;
      private string AV14Update ;
      private string AV15Delete ;
      private string AV16ADVANCED_LABEL_TEMPLATE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavDatavelorio_Internalname ;
      private string edtavDatavelorio_Jsonclick ;
      private string bttBtntoggle_Class ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divFilterscontainer_Internalname ;
      private string bttBtntoggleontable_Internalname ;
      private string bttBtntoggleontable_Jsonclick ;
      private string divInscricaofiltercontainer_Internalname ;
      private string lblLblinscricaofilter_Internalname ;
      private string lblLblinscricaofilter_Caption ;
      private string lblLblinscricaofilter_Jsonclick ;
      private string edtavInscricao_Internalname ;
      private string edtavInscricao_Jsonclick ;
      private string divNomefiltercontainer_Internalname ;
      private string lblLblnomefilter_Internalname ;
      private string lblLblnomefilter_Caption ;
      private string lblLblnomefilter_Jsonclick ;
      private string edtavNome_Internalname ;
      private string edtavNome_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavAovivo_Internalname ;
      private string edtInscricao_Internalname ;
      private string edtNome_Internalname ;
      private string edtNascimento_Internalname ;
      private string edtFalecimento_Internalname ;
      private string edtDataVelorio_Internalname ;
      private string edtHoraInicio_Internalname ;
      private string edtHoraFim_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string GXCCtl ;
      private string AV22Pgmname ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtDataVelorio_Link ;
      private string sGXsfl_29_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtInscricao_Jsonclick ;
      private string edtNome_Jsonclick ;
      private string edtNascimento_Jsonclick ;
      private string edtFalecimento_Jsonclick ;
      private string edtDataVelorio_Jsonclick ;
      private string edtHoraInicio_Jsonclick ;
      private string edtHoraFim_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A57HoraInicio ;
      private DateTime A58HoraFim ;
      private DateTime AV20CurrentTime ;
      private DateTime AV18HoraInicio ;
      private DateTime AV19HoraFim ;
      private DateTime AV11DataVelorio ;
      private DateTime Gx_date ;
      private DateTime A8Nascimento ;
      private DateTime A9Falecimento ;
      private DateTime A56DataVelorio ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV21AoVivo ;
      private bool n8Nascimento ;
      private bool n9Falecimento ;
      private bool bGXsfl_29_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV13Nome ;
      private string A2Nome ;
      private string lV13Nome ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAovivo ;
      private IDataStoreProvider pr_default ;
      private short[] H000C2_A55IdTransmissao ;
      private DateTime[] H000C2_A58HoraFim ;
      private DateTime[] H000C2_A57HoraInicio ;
      private DateTime[] H000C2_A56DataVelorio ;
      private string[] H000C2_A2Nome ;
      private int[] H000C2_A1Inscricao ;
      private IDataStoreProvider pr_datastore1 ;
      private DateTime[] H000C3_A9Falecimento ;
      private bool[] H000C3_n9Falecimento ;
      private DateTime[] H000C3_A8Nascimento ;
      private bool[] H000C3_n8Nascimento ;
      private short[] H000C4_A55IdTransmissao ;
      private DateTime[] H000C4_A58HoraFim ;
      private DateTime[] H000C4_A57HoraInicio ;
      private DateTime[] H000C4_A56DataVelorio ;
      private string[] H000C4_A2Nome ;
      private int[] H000C4_A1Inscricao ;
      private DateTime[] H000C5_A9Falecimento ;
      private bool[] H000C5_n9Falecimento ;
      private DateTime[] H000C5_A8Nascimento ;
      private bool[] H000C5_n8Nascimento ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class wwgerenciadordetransmissoes__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000C3;
          prmH000C3 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmH000C5;
          prmH000C5 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000C3", "SELECT [Falecimento], [Nascimento] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000C5", "SELECT [Falecimento], [Nascimento] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C5,1, GxCacheFrequency.OFF ,true,false )
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
             case 1 :
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

 public class wwgerenciadordetransmissoes__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_H000C2( IGxContext context ,
                                           DateTime AV11DataVelorio ,
                                           int AV12Inscricao ,
                                           string AV13Nome ,
                                           DateTime A56DataVelorio ,
                                           int A1Inscricao ,
                                           string A2Nome )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[3];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT [IdTransmissao], [HoraFim], [HoraInicio], [DataVelorio], [Nome], [Inscricao] FROM [GerenciadorDeTransmissoes]";
       if ( ! (DateTime.MinValue==AV11DataVelorio) )
       {
          AddWhere(sWhereString, "([DataVelorio] >= @AV11DataVelorio)");
       }
       else
       {
          GXv_int1[0] = 1;
       }
       if ( ! (0==AV12Inscricao) )
       {
          AddWhere(sWhereString, "([Inscricao] >= @AV12Inscricao)");
       }
       else
       {
          GXv_int1[1] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Nome)) )
       {
          AddWhere(sWhereString, "([Nome] like @lV13Nome)");
       }
       else
       {
          GXv_int1[2] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [DataVelorio]";
       scmdbuf += " OPTION (FAST 11)";
       GXv_Object2[0] = scmdbuf;
       GXv_Object2[1] = GXv_int1;
       return GXv_Object2 ;
    }

    protected Object[] conditional_H000C4( IGxContext context ,
                                           DateTime AV11DataVelorio ,
                                           int AV12Inscricao ,
                                           string AV13Nome ,
                                           DateTime A56DataVelorio ,
                                           int A1Inscricao ,
                                           string A2Nome )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int3 = new short[3];
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT [IdTransmissao], [HoraFim], [HoraInicio], [DataVelorio], [Nome], [Inscricao] FROM [GerenciadorDeTransmissoes]";
       if ( ! (DateTime.MinValue==AV11DataVelorio) )
       {
          AddWhere(sWhereString, "([DataVelorio] >= @AV11DataVelorio)");
       }
       else
       {
          GXv_int3[0] = 1;
       }
       if ( ! (0==AV12Inscricao) )
       {
          AddWhere(sWhereString, "([Inscricao] >= @AV12Inscricao)");
       }
       else
       {
          GXv_int3[1] = 1;
       }
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13Nome)) )
       {
          AddWhere(sWhereString, "([Nome] like @lV13Nome)");
       }
       else
       {
          GXv_int3[2] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [DataVelorio]";
       scmdbuf += " OPTION (FAST 11)";
       GXv_Object4[0] = scmdbuf;
       GXv_Object4[1] = GXv_int3;
       return GXv_Object4 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_H000C2(context, (DateTime)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] );
             case 1 :
                   return conditional_H000C4(context, (DateTime)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH000C2;
        prmH000C2 = new Object[] {
        new ParDef("@AV11DataVelorio",GXType.Date,8,0) ,
        new ParDef("@AV12Inscricao",GXType.Int32,9,0) ,
        new ParDef("@lV13Nome",GXType.NVarChar,50,0)
        };
        Object[] prmH000C4;
        prmH000C4 = new Object[] {
        new ParDef("@AV11DataVelorio",GXType.Date,8,0) ,
        new ParDef("@AV12Inscricao",GXType.Int32,9,0) ,
        new ParDef("@lV13Nome",GXType.NVarChar,50,0)
        };
        def= new CursorDef[] {
            new CursorDef("H000C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C2,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H000C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C4,11, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
     }
  }

}

}
