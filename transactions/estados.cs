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
namespace GeneXus.Programs.transactions {
   public class estados : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridestados_id") == 0 )
         {
            gxnrGridestados_id_newrow_invoke( ) ;
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
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7IdEstado = (short)(Math.Round(NumberUtil.Val( GetPar( "IdEstado"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7IdEstado", StringUtil.LTrimStr( (decimal)(AV7IdEstado), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDESTADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IdEstado), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Estados", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNomeEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridestados_id_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         A63EstadoLL = (short)(Math.Round(NumberUtil.Val( GetPar( "EstadoLL"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridestados_id_newrow( ) ;
         /* End function gxnrGridestados_id_newrow_invoke */
      }

      public estados( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Design.GoldLegacy", true);
      }

      public estados( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_IdEstado )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IdEstado = aP1_IdEstado;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Estados", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Transactions/Estados.htm");
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
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIdEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIdEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIdEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61IdEstado), 4, 0, ",", "")), StringUtil.LTrim( ((edtIdEstado_Enabled!=0) ? context.localUtil.Format( (decimal)(A61IdEstado), "ZZZ9") : context.localUtil.Format( (decimal)(A61IdEstado), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIdEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIdEstado_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Transactions\\Id", "end", false, "", "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNomeEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNomeEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNomeEstado_Internalname, StringUtil.RTrim( A62NomeEstado), StringUtil.RTrim( context.localUtil.Format( A62NomeEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNomeEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNomeEstado_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstadoLL_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoLL_Internalname, "LL", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoLL_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A63EstadoLL), 4, 0, ",", "")), StringUtil.LTrim( ((edtEstadoLL_Enabled!=0) ? context.localUtil.Format( (decimal)(A63EstadoLL), "ZZZ9") : context.localUtil.Format( (decimal)(A63EstadoLL), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoLL_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstadoLL_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divIdtable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleid_Internalname, "Id", "", "", lblTitleid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridestados_id( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/Estados.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridestados_id( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount4 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_4 = 1;
               ScanStart034( ) ;
               while ( RcdFound4 != 0 )
               {
                  init_level_properties4( ) ;
                  getByPrimaryKey034( ) ;
                  AddRow034( ) ;
                  ScanNext034( ) ;
               }
               ScanEnd034( ) ;
               nBlankRcdCount4 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B63EstadoLL = A63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            standaloneNotModal034( ) ;
            standaloneModal034( ) ;
            sMode4 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow034( ) ;
               edtIdCidade_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "IDCIDADE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtNomeCidade_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NOMECIDADE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNomeCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNomeCidade_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_4 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal034( ) ;
               }
               SendRow034( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A63EstadoLL = B63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount4 = 5;
            nRcdExists_4 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart034( ) ;
               while ( RcdFound4 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_534( ) ;
                  init_level_properties4( ) ;
                  standaloneNotModal034( ) ;
                  getByPrimaryKey034( ) ;
                  standaloneModal034( ) ;
                  AddRow034( ) ;
                  ScanNext034( ) ;
               }
               ScanEnd034( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode4 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
            SubsflControlProps_534( ) ;
            InitAll034( ) ;
            init_level_properties4( ) ;
            B63EstadoLL = A63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            nRcdExists_4 = 0;
            nIsMod_4 = 0;
            nRcdDeleted_4 = 0;
            nBlankRcdCount4 = (short)(nBlankRcdUsr4+nBlankRcdCount4);
            fRowAdded = 0;
            while ( nBlankRcdCount4 > 0 )
            {
               standaloneNotModal034( ) ;
               standaloneModal034( ) ;
               AddRow034( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtIdCidade_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount4 = (short)(nBlankRcdCount4-1);
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A63EstadoLL = B63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridestados_idContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridestados_id", Gridestados_idContainer, subGridestados_id_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridestados_idContainerData", Gridestados_idContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridestados_idContainerData"+"V", Gridestados_idContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridestados_idContainerData"+"V"+"\" value='"+Gridestados_idContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z61IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z61IdEstado"), ",", "."), 18, MidpointRounding.ToEven));
               Z62NomeEstado = cgiGet( "Z62NomeEstado");
               Z63EstadoLL = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z63EstadoLL"), ",", "."), 18, MidpointRounding.ToEven));
               O63EstadoLL = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O63EstadoLL"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ",", "."), 18, MidpointRounding.ToEven));
               AV7IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vIDESTADO"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A61IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtIdEstado_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
               A62NomeEstado = cgiGet( edtNomeEstado_Internalname);
               AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
               A63EstadoLL = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEstadoLL_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Estados");
               A61IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtIdEstado_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
               forbiddenHiddens.Add("IdEstado", context.localUtil.Format( (decimal)(A61IdEstado), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A61IdEstado != Z61IdEstado ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("transactions\\estados:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A61IdEstado = (short)(Math.Round(NumberUtil.Val( GetPar( "IdEstado"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "IDESTADO");
                        AnyError = 1;
                        GX_FocusControl = edtIdEstado_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes033( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode3 = Gx_mode;
            CONFIRM_034( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode3;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_034( )
      {
         s63EstadoLL = O63EstadoLL;
         AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow034( ) ;
            if ( ( nRcdExists_4 != 0 ) || ( nIsMod_4 != 0 ) )
            {
               GetKey034( ) ;
               if ( ( nRcdExists_4 == 0 ) && ( nRcdDeleted_4 == 0 ) )
               {
                  if ( RcdFound4 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate034( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable034( ) ;
                        CloseExtendedTableCursors034( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O63EstadoLL = A63EstadoLL;
                        AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "IDCIDADE_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtIdCidade_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound4 != 0 )
                  {
                     if ( nRcdDeleted_4 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey034( ) ;
                        Load034( ) ;
                        BeforeValidate034( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls034( ) ;
                           O63EstadoLL = A63EstadoLL;
                           AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_4 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate034( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable034( ) ;
                              CloseExtendedTableCursors034( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O63EstadoLL = A63EstadoLL;
                              AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_4 == 0 )
                     {
                        GXCCtl = "IDCIDADE_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIdCidade_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtIdCidade_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64IdCidade), 4, 0, ",", ""))) ;
            ChangePostValue( edtNomeCidade_Internalname, StringUtil.RTrim( A65NomeCidade)) ;
            ChangePostValue( "ZT_"+"Z64IdCidade_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64IdCidade), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z65NomeCidade_"+sGXsfl_53_idx, StringUtil.RTrim( Z65NomeCidade)) ;
            ChangePostValue( "nRcdDeleted_4_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_4_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_4_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, ",", ""))) ;
            if ( nIsMod_4 != 0 )
            {
               ChangePostValue( "IDCIDADE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIdCidade_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NOMECIDADE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNomeCidade_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O63EstadoLL = s63EstadoLL;
         AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("transactions.wwestados.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z62NomeEstado = T00035_A62NomeEstado[0];
               Z63EstadoLL = T00035_A63EstadoLL[0];
            }
            else
            {
               Z62NomeEstado = A62NomeEstado;
               Z63EstadoLL = A63EstadoLL;
            }
         }
         if ( GX_JID == -7 )
         {
            Z61IdEstado = A61IdEstado;
            Z62NomeEstado = A62NomeEstado;
            Z63EstadoLL = A63EstadoLL;
         }
      }

      protected void standaloneNotModal( )
      {
         edtIdEstado_Enabled = 0;
         AssignProp("", false, edtIdEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdEstado_Enabled), 5, 0), true);
         edtEstadoLL_Enabled = 0;
         AssignProp("", false, edtEstadoLL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoLL_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtIdEstado_Enabled = 0;
         AssignProp("", false, edtIdEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdEstado_Enabled), 5, 0), true);
         edtEstadoLL_Enabled = 0;
         AssignProp("", false, edtEstadoLL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoLL_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IdEstado) )
         {
            A61IdEstado = AV7IdEstado;
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
            A62NomeEstado = T00036_A62NomeEstado[0];
            AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
            A63EstadoLL = T00036_A63EstadoLL[0];
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            ZM033( -7) ;
         }
         pr_default.close(4);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV12Pgmname = "Transactions.Estados";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV12Pgmname = "Transactions.Estados";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM033( 7) ;
            RcdFound3 = 1;
            A61IdEstado = T00035_A61IdEstado[0];
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
            A62NomeEstado = T00035_A62NomeEstado[0];
            AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
            A63EstadoLL = T00035_A63EstadoLL[0];
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            O63EstadoLL = A63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            Z61IdEstado = A61IdEstado;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A61IdEstado[0] < A61IdEstado ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A61IdEstado[0] > A61IdEstado ) ) )
            {
               A61IdEstado = T00038_A61IdEstado[0];
               AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A61IdEstado[0] > A61IdEstado ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A61IdEstado[0] < A61IdEstado ) ) )
            {
               A61IdEstado = T00039_A61IdEstado[0];
               AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A63EstadoLL = O63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            GX_FocusControl = edtNomeEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A61IdEstado != Z61IdEstado )
               {
                  A61IdEstado = Z61IdEstado;
                  AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IDESTADO");
                  AnyError = 1;
                  GX_FocusControl = edtIdEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A63EstadoLL = O63EstadoLL;
                  AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNomeEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A63EstadoLL = O63EstadoLL;
                  AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                  Update033( ) ;
                  GX_FocusControl = edtNomeEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A61IdEstado != Z61IdEstado )
               {
                  /* Insert record */
                  A63EstadoLL = O63EstadoLL;
                  AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                  GX_FocusControl = edtNomeEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IDESTADO");
                     AnyError = 1;
                     GX_FocusControl = edtIdEstado_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A63EstadoLL = O63EstadoLL;
                     AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                     GX_FocusControl = edtNomeEstado_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A61IdEstado != Z61IdEstado )
         {
            A61IdEstado = Z61IdEstado;
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IDESTADO");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A63EstadoLL = O63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNomeEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A61IdEstado});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estados"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z62NomeEstado, T00034_A62NomeEstado[0]) != 0 ) || ( Z63EstadoLL != T00034_A63EstadoLL[0] ) )
            {
               if ( StringUtil.StrCmp(Z62NomeEstado, T00034_A62NomeEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("transactions.estados:[seudo value changed for attri]"+"NomeEstado");
                  GXUtil.WriteLogRaw("Old: ",Z62NomeEstado);
                  GXUtil.WriteLogRaw("Current: ",T00034_A62NomeEstado[0]);
               }
               if ( Z63EstadoLL != T00034_A63EstadoLL[0] )
               {
                  GXUtil.WriteLog("transactions.estados:[seudo value changed for attri]"+"EstadoLL");
                  GXUtil.WriteLogRaw("Old: ",Z63EstadoLL);
                  GXUtil.WriteLogRaw("Current: ",T00034_A63EstadoLL[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Estados"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A62NomeEstado, A63EstadoLL});
                     A61IdEstado = T000310_A61IdEstado[0];
                     AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Estados");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption030( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A62NomeEstado, A63EstadoLL, A61IdEstado});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Estados");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estados"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  A63EstadoLL = O63EstadoLL;
                  AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                  ScanStart034( ) ;
                  while ( RcdFound4 != 0 )
                  {
                     getByPrimaryKey034( ) ;
                     Delete034( ) ;
                     ScanNext034( ) ;
                     O63EstadoLL = A63EstadoLL;
                     AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
                  }
                  ScanEnd034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000312 */
                     pr_default.execute(10, new Object[] {A61IdEstado});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Estados");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Transactions.Estados";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000313 */
            pr_default.execute(11, new Object[] {A61IdEstado});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Gerenciador De Transmissoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel034( )
      {
         s63EstadoLL = O63EstadoLL;
         AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow034( ) ;
            if ( ( nRcdExists_4 != 0 ) || ( nIsMod_4 != 0 ) )
            {
               standaloneNotModal034( ) ;
               GetKey034( ) ;
               if ( ( nRcdExists_4 == 0 ) && ( nRcdDeleted_4 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert034( ) ;
               }
               else
               {
                  if ( RcdFound4 != 0 )
                  {
                     if ( ( nRcdDeleted_4 != 0 ) && ( nRcdExists_4 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete034( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_4 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update034( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_4 == 0 )
                     {
                        GXCCtl = "IDCIDADE_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtIdCidade_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O63EstadoLL = A63EstadoLL;
               AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
            }
            ChangePostValue( edtIdCidade_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64IdCidade), 4, 0, ",", ""))) ;
            ChangePostValue( edtNomeCidade_Internalname, StringUtil.RTrim( A65NomeCidade)) ;
            ChangePostValue( "ZT_"+"Z64IdCidade_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64IdCidade), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z65NomeCidade_"+sGXsfl_53_idx, StringUtil.RTrim( Z65NomeCidade)) ;
            ChangePostValue( "nRcdDeleted_4_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_4_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_4_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, ",", ""))) ;
            if ( nIsMod_4 != 0 )
            {
               ChangePostValue( "IDCIDADE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIdCidade_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NOMECIDADE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNomeCidade_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll034( ) ;
         if ( AnyError != 0 )
         {
            O63EstadoLL = s63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         }
         nRcdExists_4 = 0;
         nIsMod_4 = 0;
         nRcdDeleted_4 = 0;
      }

      protected void ProcessLevel033( )
      {
         /* Save parent mode. */
         sMode3 = Gx_mode;
         ProcessNestedLevel034( ) ;
         if ( AnyError != 0 )
         {
            O63EstadoLL = s63EstadoLL;
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000314 */
         pr_default.execute(12, new Object[] {A63EstadoLL, A61IdEstado});
         pr_default.close(12);
         pr_default.SmartCacheProvider.SetUpdated("Estados");
      }

      protected void EndLevel033( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("transactions.estados",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("transactions.estados",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000315 */
         pr_default.execute(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A61IdEstado = T000315_A61IdEstado[0];
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A61IdEstado = T000315_A61IdEstado[0];
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtIdEstado_Enabled = 0;
         AssignProp("", false, edtIdEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdEstado_Enabled), 5, 0), true);
         edtNomeEstado_Enabled = 0;
         AssignProp("", false, edtNomeEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNomeEstado_Enabled), 5, 0), true);
         edtEstadoLL_Enabled = 0;
         AssignProp("", false, edtEstadoLL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoLL_Enabled), 5, 0), true);
      }

      protected void ZM034( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z65NomeCidade = T00033_A65NomeCidade[0];
            }
            else
            {
               Z65NomeCidade = A65NomeCidade;
            }
         }
         if ( GX_JID == -8 )
         {
            Z61IdEstado = A61IdEstado;
            Z64IdCidade = A64IdCidade;
            Z65NomeCidade = A65NomeCidade;
         }
      }

      protected void standaloneNotModal034( )
      {
         edtEstadoLL_Enabled = 0;
         AssignProp("", false, edtEstadoLL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoLL_Enabled), 5, 0), true);
         edtEstadoLL_Enabled = 0;
         AssignProp("", false, edtEstadoLL_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoLL_Enabled), 5, 0), true);
      }

      protected void standaloneModal034( )
      {
         if ( IsIns( )  )
         {
            A63EstadoLL = (short)(O63EstadoLL+1);
            AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A64IdCidade = A63EstadoLL;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtIdCidade_Enabled = 0;
            AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtIdCidade_Enabled = 1;
            AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load034( )
      {
         /* Using cursor T000316 */
         pr_default.execute(14, new Object[] {A61IdEstado, A64IdCidade});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A65NomeCidade = T000316_A65NomeCidade[0];
            ZM034( -8) ;
         }
         pr_default.close(14);
         OnLoadActions034( ) ;
      }

      protected void OnLoadActions034( )
      {
      }

      protected void CheckExtendedTable034( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal034( ) ;
      }

      protected void CloseExtendedTableCursors034( )
      {
      }

      protected void enableDisable034( )
      {
      }

      protected void GetKey034( )
      {
         /* Using cursor T000317 */
         pr_default.execute(15, new Object[] {A61IdEstado, A64IdCidade});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey034( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A61IdEstado, A64IdCidade});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM034( 8) ;
            RcdFound4 = 1;
            InitializeNonKey034( ) ;
            A64IdCidade = T00033_A64IdCidade[0];
            A65NomeCidade = T00033_A65NomeCidade[0];
            Z61IdEstado = A61IdEstado;
            Z64IdCidade = A64IdCidade;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load034( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey034( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal034( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes034( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency034( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A61IdEstado, A64IdCidade});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadosId"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z65NomeCidade, T00032_A65NomeCidade[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z65NomeCidade, T00032_A65NomeCidade[0]) != 0 )
               {
                  GXUtil.WriteLog("transactions.estados:[seudo value changed for attri]"+"NomeCidade");
                  GXUtil.WriteLogRaw("Old: ",Z65NomeCidade);
                  GXUtil.WriteLogRaw("Current: ",T00032_A65NomeCidade[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EstadosId"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM034( 0) ;
            CheckOptimisticConcurrency034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000318 */
                     pr_default.execute(16, new Object[] {A61IdEstado, A64IdCidade, A65NomeCidade});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("EstadosId");
                     if ( (pr_default.getStatus(16) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load034( ) ;
            }
            EndLevel034( ) ;
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void Update034( )
      {
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable034( ) ;
         }
         if ( ( nIsMod_4 != 0 ) || ( nIsDirty_4 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency034( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm034( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate034( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000319 */
                        pr_default.execute(17, new Object[] {A65NomeCidade, A61IdEstado, A64IdCidade});
                        pr_default.close(17);
                        pr_default.SmartCacheProvider.SetUpdated("EstadosId");
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadosId"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate034( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey034( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel034( ) ;
            }
         }
         CloseExtendedTableCursors034( ) ;
      }

      protected void DeferredUpdate034( )
      {
      }

      protected void Delete034( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate034( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency034( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls034( ) ;
            AfterConfirm034( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete034( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000320 */
                  pr_default.execute(18, new Object[] {A61IdEstado, A64IdCidade});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("EstadosId");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel034( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls034( )
      {
         standaloneModal034( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000321 */
            pr_default.execute(19, new Object[] {A61IdEstado, A64IdCidade});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Gerenciador De Transmissoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel034( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart034( )
      {
         /* Scan By routine */
         /* Using cursor T000322 */
         pr_default.execute(20, new Object[] {A61IdEstado});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound4 = 1;
            A64IdCidade = T000322_A64IdCidade[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext034( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound4 = 1;
            A64IdCidade = T000322_A64IdCidade[0];
         }
      }

      protected void ScanEnd034( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm034( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert034( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate034( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete034( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete034( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate034( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes034( )
      {
         edtIdCidade_Enabled = 0;
         AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtNomeCidade_Enabled = 0;
         AssignProp("", false, edtNomeCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNomeCidade_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes034( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void SubsflControlProps_534( )
      {
         edtIdCidade_Internalname = "IDCIDADE_"+sGXsfl_53_idx;
         edtNomeCidade_Internalname = "NOMECIDADE_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_534( )
      {
         edtIdCidade_Internalname = "IDCIDADE_"+sGXsfl_53_fel_idx;
         edtNomeCidade_Internalname = "NOMECIDADE_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow034( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_534( ) ;
         SendRow034( ) ;
      }

      protected void SendRow034( )
      {
         Gridestados_idRow = GXWebRow.GetNew(context);
         if ( subGridestados_id_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridestados_id_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridestados_id_Class, "") != 0 )
            {
               subGridestados_id_Linesclass = subGridestados_id_Class+"Odd";
            }
         }
         else if ( subGridestados_id_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridestados_id_Backstyle = 0;
            subGridestados_id_Backcolor = subGridestados_id_Allbackcolor;
            if ( StringUtil.StrCmp(subGridestados_id_Class, "") != 0 )
            {
               subGridestados_id_Linesclass = subGridestados_id_Class+"Uniform";
            }
         }
         else if ( subGridestados_id_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridestados_id_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridestados_id_Class, "") != 0 )
            {
               subGridestados_id_Linesclass = subGridestados_id_Class+"Odd";
            }
            subGridestados_id_Backcolor = (int)(0x0);
         }
         else if ( subGridestados_id_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridestados_id_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridestados_id_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridestados_id_Class, "") != 0 )
               {
                  subGridestados_id_Linesclass = subGridestados_id_Class+"Even";
               }
            }
            else
            {
               subGridestados_id_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridestados_id_Class, "") != 0 )
               {
                  subGridestados_id_Linesclass = subGridestados_id_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridestados_idRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIdCidade_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A64IdCidade), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A64IdCidade), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIdCidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtIdCidade_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"Transactions\\Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_4_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridestados_idRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNomeCidade_Internalname,StringUtil.RTrim( A65NomeCidade),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNomeCidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtNomeCidade_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)true,(string)"Transactions\\Nome",(string)"start",(bool)true,(string)""});
         ajax_sending_grid_row(Gridestados_idRow);
         send_integrity_lvl_hashes034( ) ;
         GXCCtl = "Z64IdCidade_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64IdCidade), 4, 0, ",", "")));
         GXCCtl = "Z65NomeCidade_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z65NomeCidade));
         GXCCtl = "nRcdDeleted_4_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_4), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_4_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_4), 4, 0, ",", "")));
         GXCCtl = "nIsMod_4_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_4), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_53_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vIDESTADO_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IdEstado), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IDCIDADE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIdCidade_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NOMECIDADE_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNomeCidade_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridestados_idContainer.AddRow(Gridestados_idRow);
      }

      protected void ReadRow034( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_534( ) ;
         edtIdCidade_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "IDCIDADE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtNomeCidade_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NOMECIDADE_"+sGXsfl_53_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtIdCidade_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIdCidade_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "IDCIDADE_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtIdCidade_Internalname;
            wbErr = true;
            A64IdCidade = 0;
         }
         else
         {
            A64IdCidade = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtIdCidade_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A65NomeCidade = cgiGet( edtNomeCidade_Internalname);
         GXCCtl = "Z64IdCidade_" + sGXsfl_53_idx;
         Z64IdCidade = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z65NomeCidade_" + sGXsfl_53_idx;
         Z65NomeCidade = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_4_" + sGXsfl_53_idx;
         nRcdDeleted_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_4_" + sGXsfl_53_idx;
         nRcdExists_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_4_" + sGXsfl_53_idx;
         nIsMod_4 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtIdCidade_Enabled = edtIdCidade_Enabled;
      }

      protected void ConfirmValues030( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_534( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_534( ) ;
            ChangePostValue( "Z64IdCidade_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z64IdCidade_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z64IdCidade_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z65NomeCidade_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z65NomeCidade_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z65NomeCidade_"+sGXsfl_53_idx) ;
         }
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
         MasterPageObj.master_styles();
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("transactions.estados.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IdEstado,4,0))}, new string[] {"Gx_mode","IdEstado"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Estados");
         forbiddenHiddens.Add("IdEstado", context.localUtil.Format( (decimal)(A61IdEstado), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("transactions\\estados:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z61IdEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61IdEstado), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z62NomeEstado", StringUtil.RTrim( Z62NomeEstado));
         GxWebStd.gx_hidden_field( context, "Z63EstadoLL", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z63EstadoLL), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O63EstadoLL", StringUtil.LTrim( StringUtil.NToC( (decimal)(O63EstadoLL), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vIDESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IdEstado), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDESTADO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IdEstado), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("transactions.estados.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IdEstado,4,0))}, new string[] {"Gx_mode","IdEstado"})  ;
      }

      public override string GetPgmname( )
      {
         return "Transactions.Estados" ;
      }

      public override string GetPgmdesc( )
      {
         return "Estados" ;
      }

      protected void InitializeNonKey033( )
      {
         A62NomeEstado = "";
         AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
         A63EstadoLL = 0;
         AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         O63EstadoLL = A63EstadoLL;
         AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
         Z62NomeEstado = "";
         Z63EstadoLL = 0;
      }

      protected void InitAll033( )
      {
         A61IdEstado = 0;
         AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey034( )
      {
         A65NomeCidade = "";
         Z65NomeCidade = "";
      }

      protected void InitAll034( )
      {
         A64IdCidade = 0;
         InitializeNonKey034( ) ;
      }

      protected void StandaloneModalInsert034( )
      {
         A63EstadoLL = i63EstadoLL;
         AssignAttri("", false, "A63EstadoLL", StringUtil.LTrimStr( (decimal)(A63EstadoLL), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248251941771", true, true);
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
         context.AddJavascriptSource("transactions/estados.js", "?20248251941771", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties4( )
      {
         edtIdCidade_Enabled = defedtIdCidade_Enabled;
         AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridestados_idContainer.AddObjectProperty("GridName", "Gridestados_id");
         Gridestados_idContainer.AddObjectProperty("Header", subGridestados_id_Header);
         Gridestados_idContainer.AddObjectProperty("Class", "Grid");
         Gridestados_idContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Backcolorstyle), 1, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("CmpContext", "");
         Gridestados_idContainer.AddObjectProperty("InMasterPage", "false");
         Gridestados_idColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridestados_idColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A64IdCidade), 4, 0, ".", ""))));
         Gridestados_idColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIdCidade_Enabled), 5, 0, ".", "")));
         Gridestados_idContainer.AddColumnProperties(Gridestados_idColumn);
         Gridestados_idColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridestados_idColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A65NomeCidade)));
         Gridestados_idColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNomeCidade_Enabled), 5, 0, ".", "")));
         Gridestados_idContainer.AddColumnProperties(Gridestados_idColumn);
         Gridestados_idContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Selectedindex), 4, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Allowselection), 1, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Selectioncolor), 9, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Allowhovering), 1, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Hoveringcolor), 9, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Allowcollapsing), 1, 0, ".", "")));
         Gridestados_idContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridestados_id_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtIdEstado_Internalname = "IDESTADO";
         edtNomeEstado_Internalname = "NOMEESTADO";
         edtEstadoLL_Internalname = "ESTADOLL";
         lblTitleid_Internalname = "TITLEID";
         edtIdCidade_Internalname = "IDCIDADE";
         edtNomeCidade_Internalname = "NOMECIDADE";
         divIdtable_Internalname = "IDTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridestados_id_Internalname = "GRIDESTADOS_ID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridestados_id_Allowcollapsing = 0;
         subGridestados_id_Allowselection = 0;
         subGridestados_id_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Estados";
         edtNomeCidade_Jsonclick = "";
         edtIdCidade_Jsonclick = "";
         subGridestados_id_Class = "Grid";
         subGridestados_id_Backcolorstyle = 0;
         edtNomeCidade_Enabled = 1;
         edtIdCidade_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtEstadoLL_Jsonclick = "";
         edtEstadoLL_Enabled = 0;
         edtNomeEstado_Jsonclick = "";
         edtNomeEstado_Enabled = 1;
         edtIdEstado_Jsonclick = "";
         edtIdEstado_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridestados_id_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_534( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal034( ) ;
            standaloneModal034( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow034( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_534( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridestados_idContainer)) ;
         /* End function gxnrGridestados_id_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7IdEstado","fld":"vIDESTADO","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7IdEstado","fld":"vIDESTADO","pic":"ZZZ9","hsh":true},{"av":"A61IdEstado","fld":"IDESTADO","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12032","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_IDESTADO","""{"handler":"Valid_Idestado","iparms":[]}""");
         setEventMetadata("VALID_ESTADOLL","""{"handler":"Valid_Estadoll","iparms":[]}""");
         setEventMetadata("VALID_IDCIDADE","""{"handler":"Valid_Idcidade","iparms":[]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Nomecidade","iparms":[]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z62NomeEstado = "";
         Z65NomeCidade = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A62NomeEstado = "";
         lblTitleid_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridestados_idContainer = new GXWebGrid( context);
         sMode4 = "";
         sStyleString = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A65NomeCidade = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00036_A61IdEstado = new short[1] ;
         T00036_A62NomeEstado = new string[] {""} ;
         T00036_A63EstadoLL = new short[1] ;
         T00037_A61IdEstado = new short[1] ;
         T00035_A61IdEstado = new short[1] ;
         T00035_A62NomeEstado = new string[] {""} ;
         T00035_A63EstadoLL = new short[1] ;
         T00038_A61IdEstado = new short[1] ;
         T00039_A61IdEstado = new short[1] ;
         T00034_A61IdEstado = new short[1] ;
         T00034_A62NomeEstado = new string[] {""} ;
         T00034_A63EstadoLL = new short[1] ;
         T000310_A61IdEstado = new short[1] ;
         T000313_A55IdTransmissao = new short[1] ;
         T000315_A61IdEstado = new short[1] ;
         T000316_A61IdEstado = new short[1] ;
         T000316_A64IdCidade = new short[1] ;
         T000316_A65NomeCidade = new string[] {""} ;
         T000317_A61IdEstado = new short[1] ;
         T000317_A64IdCidade = new short[1] ;
         T00033_A61IdEstado = new short[1] ;
         T00033_A64IdCidade = new short[1] ;
         T00033_A65NomeCidade = new string[] {""} ;
         T00032_A61IdEstado = new short[1] ;
         T00032_A64IdCidade = new short[1] ;
         T00032_A65NomeCidade = new string[] {""} ;
         T000321_A55IdTransmissao = new short[1] ;
         T000322_A61IdEstado = new short[1] ;
         T000322_A64IdCidade = new short[1] ;
         Gridestados_idRow = new GXWebRow();
         subGridestados_id_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridestados_idColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.transactions.estados__gam(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.transactions.estados__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.transactions.estados__default(),
            new Object[][] {
                new Object[] {
               T00032_A61IdEstado, T00032_A64IdCidade, T00032_A65NomeCidade
               }
               , new Object[] {
               T00033_A61IdEstado, T00033_A64IdCidade, T00033_A65NomeCidade
               }
               , new Object[] {
               T00034_A61IdEstado, T00034_A62NomeEstado, T00034_A63EstadoLL
               }
               , new Object[] {
               T00035_A61IdEstado, T00035_A62NomeEstado, T00035_A63EstadoLL
               }
               , new Object[] {
               T00036_A61IdEstado, T00036_A62NomeEstado, T00036_A63EstadoLL
               }
               , new Object[] {
               T00037_A61IdEstado
               }
               , new Object[] {
               T00038_A61IdEstado
               }
               , new Object[] {
               T00039_A61IdEstado
               }
               , new Object[] {
               T000310_A61IdEstado
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000313_A55IdTransmissao
               }
               , new Object[] {
               }
               , new Object[] {
               T000315_A61IdEstado
               }
               , new Object[] {
               T000316_A61IdEstado, T000316_A64IdCidade, T000316_A65NomeCidade
               }
               , new Object[] {
               T000317_A61IdEstado, T000317_A64IdCidade
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000321_A55IdTransmissao
               }
               , new Object[] {
               T000322_A61IdEstado, T000322_A64IdCidade
               }
            }
         );
         AV12Pgmname = "Transactions.Estados";
      }

      private short wcpOAV7IdEstado ;
      private short Z61IdEstado ;
      private short Z63EstadoLL ;
      private short O63EstadoLL ;
      private short Z64IdCidade ;
      private short nRcdDeleted_4 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short GxWebError ;
      private short AV7IdEstado ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A63EstadoLL ;
      private short Gx_BScreen ;
      private short A61IdEstado ;
      private short nBlankRcdCount4 ;
      private short RcdFound4 ;
      private short B63EstadoLL ;
      private short nBlankRcdUsr4 ;
      private short RcdFound3 ;
      private short s63EstadoLL ;
      private short A64IdCidade ;
      private short nIsDirty_4 ;
      private short subGridestados_id_Backcolorstyle ;
      private short subGridestados_id_Backstyle ;
      private short gxajaxcallmode ;
      private short i63EstadoLL ;
      private short subGridestados_id_Allowselection ;
      private short subGridestados_id_Allowhovering ;
      private short subGridestados_id_Allowcollapsing ;
      private short subGridestados_id_Collapsed ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtIdEstado_Enabled ;
      private int edtNomeEstado_Enabled ;
      private int edtEstadoLL_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtIdCidade_Enabled ;
      private int edtNomeCidade_Enabled ;
      private int fRowAdded ;
      private int subGridestados_id_Backcolor ;
      private int subGridestados_id_Allbackcolor ;
      private int defedtIdCidade_Enabled ;
      private int idxLst ;
      private int subGridestados_id_Selectedindex ;
      private int subGridestados_id_Selectioncolor ;
      private int subGridestados_id_Hoveringcolor ;
      private long GRIDESTADOS_ID_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z62NomeEstado ;
      private string Z65NomeCidade ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNomeEstado_Internalname ;
      private string sGXsfl_53_idx="0001" ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtIdEstado_Internalname ;
      private string edtIdEstado_Jsonclick ;
      private string A62NomeEstado ;
      private string edtNomeEstado_Jsonclick ;
      private string edtEstadoLL_Internalname ;
      private string edtEstadoLL_Jsonclick ;
      private string divIdtable_Internalname ;
      private string lblTitleid_Internalname ;
      private string lblTitleid_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode4 ;
      private string edtIdCidade_Internalname ;
      private string edtNomeCidade_Internalname ;
      private string sStyleString ;
      private string subGridestados_id_Internalname ;
      private string AV12Pgmname ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string A65NomeCidade ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridestados_id_Class ;
      private string subGridestados_id_Linesclass ;
      private string ROClassString ;
      private string edtIdCidade_Jsonclick ;
      private string edtNomeCidade_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridestados_id_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool returnInSub ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridestados_idContainer ;
      private GXWebRow Gridestados_idRow ;
      private GXWebColumn Gridestados_idColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T00036_A61IdEstado ;
      private string[] T00036_A62NomeEstado ;
      private short[] T00036_A63EstadoLL ;
      private short[] T00037_A61IdEstado ;
      private short[] T00035_A61IdEstado ;
      private string[] T00035_A62NomeEstado ;
      private short[] T00035_A63EstadoLL ;
      private short[] T00038_A61IdEstado ;
      private short[] T00039_A61IdEstado ;
      private short[] T00034_A61IdEstado ;
      private string[] T00034_A62NomeEstado ;
      private short[] T00034_A63EstadoLL ;
      private short[] T000310_A61IdEstado ;
      private short[] T000313_A55IdTransmissao ;
      private short[] T000315_A61IdEstado ;
      private short[] T000316_A61IdEstado ;
      private short[] T000316_A64IdCidade ;
      private string[] T000316_A65NomeCidade ;
      private short[] T000317_A61IdEstado ;
      private short[] T000317_A64IdCidade ;
      private short[] T00033_A61IdEstado ;
      private short[] T00033_A64IdCidade ;
      private string[] T00033_A65NomeCidade ;
      private short[] T00032_A61IdEstado ;
      private short[] T00032_A64IdCidade ;
      private string[] T00032_A65NomeCidade ;
      private short[] T000321_A55IdTransmissao ;
      private short[] T000322_A61IdEstado ;
      private short[] T000322_A64IdCidade ;
      private IDataStoreProvider pr_gam ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class estados__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class estados__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

public class estados__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new UpdateCursor(def[17])
      ,new UpdateCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00032;
       prmT00032 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT00033;
       prmT00033 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT00034;
       prmT00034 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT00035;
       prmT00035 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT00036;
       prmT00036 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT00037;
       prmT00037 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT00038;
       prmT00038 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT00039;
       prmT00039 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT000310;
       prmT000310 = new Object[] {
       new ParDef("@NomeEstado",GXType.NChar,2,0) ,
       new ParDef("@EstadoLL",GXType.Int16,4,0)
       };
       Object[] prmT000311;
       prmT000311 = new Object[] {
       new ParDef("@NomeEstado",GXType.NChar,2,0) ,
       new ParDef("@EstadoLL",GXType.Int16,4,0) ,
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT000312;
       prmT000312 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT000313;
       prmT000313 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT000314;
       prmT000314 = new Object[] {
       new ParDef("@EstadoLL",GXType.Int16,4,0) ,
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT000315;
       prmT000315 = new Object[] {
       };
       Object[] prmT000316;
       prmT000316 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000317;
       prmT000317 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000318;
       prmT000318 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0) ,
       new ParDef("@NomeCidade",GXType.NChar,40,0)
       };
       Object[] prmT000319;
       prmT000319 = new Object[] {
       new ParDef("@NomeCidade",GXType.NChar,40,0) ,
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000320;
       prmT000320 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000321;
       prmT000321 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000322;
       prmT000322 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00032", "SELECT [IdEstado], [IdCidade], [NomeCidade] FROM [EstadosId] WITH (UPDLOCK) WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00033", "SELECT [IdEstado], [IdCidade], [NomeCidade] FROM [EstadosId] WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00034", "SELECT [IdEstado], [NomeEstado], [EstadoLL] FROM [Estados] WITH (UPDLOCK) WHERE [IdEstado] = @IdEstado ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00035", "SELECT [IdEstado], [NomeEstado], [EstadoLL] FROM [Estados] WHERE [IdEstado] = @IdEstado ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00036", "SELECT TM1.[IdEstado], TM1.[NomeEstado], TM1.[EstadoLL] FROM [Estados] TM1 WHERE TM1.[IdEstado] = @IdEstado ORDER BY TM1.[IdEstado]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00037", "SELECT [IdEstado] FROM [Estados] WHERE [IdEstado] = @IdEstado  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00038", "SELECT TOP 1 [IdEstado] FROM [Estados] WHERE ( [IdEstado] > @IdEstado) ORDER BY [IdEstado]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00039", "SELECT TOP 1 [IdEstado] FROM [Estados] WHERE ( [IdEstado] < @IdEstado) ORDER BY [IdEstado] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000310", "INSERT INTO [Estados]([NomeEstado], [EstadoLL]) VALUES(@NomeEstado, @EstadoLL); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000311", "UPDATE [Estados] SET [NomeEstado]=@NomeEstado, [EstadoLL]=@EstadoLL  WHERE [IdEstado] = @IdEstado", GxErrorMask.GX_NOMASK,prmT000311)
          ,new CursorDef("T000312", "DELETE FROM [Estados]  WHERE [IdEstado] = @IdEstado", GxErrorMask.GX_NOMASK,prmT000312)
          ,new CursorDef("T000313", "SELECT TOP 1 [IdTransmissao] FROM [GerenciadorDeTransmissoes] WHERE [IdEstado] = @IdEstado ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000314", "UPDATE [Estados] SET [EstadoLL]=@EstadoLL  WHERE [IdEstado] = @IdEstado", GxErrorMask.GX_NOMASK,prmT000314)
          ,new CursorDef("T000315", "SELECT [IdEstado] FROM [Estados] ORDER BY [IdEstado]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000316", "SELECT [IdEstado], [IdCidade], [NomeCidade] FROM [EstadosId] WHERE [IdEstado] = @IdEstado and [IdCidade] = @IdCidade ORDER BY [IdEstado], [IdCidade] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000317", "SELECT [IdEstado], [IdCidade] FROM [EstadosId] WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000318", "INSERT INTO [EstadosId]([IdEstado], [IdCidade], [NomeCidade]) VALUES(@IdEstado, @IdCidade, @NomeCidade)", GxErrorMask.GX_NOMASK,prmT000318)
          ,new CursorDef("T000319", "UPDATE [EstadosId] SET [NomeCidade]=@NomeCidade  WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade", GxErrorMask.GX_NOMASK,prmT000319)
          ,new CursorDef("T000320", "DELETE FROM [EstadosId]  WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade", GxErrorMask.GX_NOMASK,prmT000320)
          ,new CursorDef("T000321", "SELECT TOP 1 [IdTransmissao] FROM [GerenciadorDeTransmissoes] WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000322", "SELECT [IdEstado], [IdCidade] FROM [EstadosId] WHERE [IdEstado] = @IdEstado ORDER BY [IdEstado], [IdCidade] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000322,11, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 40);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 40);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 4 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getString(2, 2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             return;
          case 5 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 6 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 7 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 8 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 11 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 13 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 14 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 40);
             return;
          case 15 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 19 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 20 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
    }
 }

}

}
