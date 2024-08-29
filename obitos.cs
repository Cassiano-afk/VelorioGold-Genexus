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
   public class obitos : GXDataArea
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
               AV7Inscricao = (int)(Math.Round(NumberUtil.Val( GetPar( "Inscricao"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7Inscricao", StringUtil.LTrimStr( (decimal)(AV7Inscricao), 9, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINSCRICAO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Inscricao), "ZZZZZZZZ9"), context));
               AV8Nome = GetPar( "Nome");
               AssignAttri("", false, "AV8Nome", AV8Nome);
               GxWebStd.gx_hidden_field( context, "gxhash_vNOME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8Nome, "")), context));
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
         Form.Meta.addItem("description", "Óbitos | Velório Gold", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtInscricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("GoldLegacy", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public obitos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("GoldLegacy", true);
      }

      public obitos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_Inscricao ,
                           string aP2_Nome )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Inscricao = aP1_Inscricao;
         this.AV8Nome = aP2_Nome;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Obitos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Obitos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Obitos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInscricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInscricao_Internalname, "Inscrição", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInscricao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Inscricao), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1Inscricao), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInscricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInscricao_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
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
         GxWebStd.gx_label_element( context, edtNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNome_Internalname, A2Nome, StringUtil.RTrim( context.localUtil.Format( A2Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNome_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGrupo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGrupo_Internalname, "Grupo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGrupo_Internalname, StringUtil.RTrim( A3Grupo), StringUtil.RTrim( context.localUtil.Format( A3Grupo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGrupo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGrupo_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReferencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReferencia_Internalname, "Referêcia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReferencia_Internalname, StringUtil.RTrim( A4Referencia), StringUtil.RTrim( context.localUtil.Format( A4Referencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReferencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReferencia_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNumero_Internalname, "Número", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNumero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5Numero), 9, 0, ",", "")), StringUtil.LTrim( ((edtNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A5Numero), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A5Numero), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNumero_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtValor_Internalname, "Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A6Valor, 18, 4, ",", "")), StringUtil.LTrim( ((edtValor_Enabled!=0) ? context.localUtil.Format( A6Valor, "ZZZZZZZZZZZZ9.9999") : context.localUtil.Format( A6Valor, "ZZZZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVencimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVencimento_Internalname, "Data Vencimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVencimento_Internalname, context.localUtil.TToC( A7Vencimento, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A7Vencimento, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVencimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVencimento_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_bitmap( context, edtVencimento_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Obitos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNascimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNascimento_Internalname, "Data Nascimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNascimento_Internalname, context.localUtil.TToC( A8Nascimento, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A8Nascimento, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNascimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNascimento_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_bitmap( context, edtNascimento_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Obitos.htm");
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
         GxWebStd.gx_label_element( context, edtFalecimento_Internalname, "Data Falecimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFalecimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFalecimento_Internalname, context.localUtil.TToC( A9Falecimento, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A9Falecimento, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFalecimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFalecimento_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_bitmap( context, edtFalecimento_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFalecimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Obitos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNumeroObito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNumeroObito_Internalname, "Número Óbito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNumeroObito_Internalname, A10NumeroObito, StringUtil.RTrim( context.localUtil.Format( A10NumeroObito, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNumeroObito_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNumeroObito_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNFNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNFNumero_Internalname, "NFNumero", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNFNumero_Internalname, A11NFNumero, StringUtil.RTrim( context.localUtil.Format( A11NFNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNFNumero_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNFNumero_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNFValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNFValor_Internalname, "NFValor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNFValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A12NFValor, 18, 4, ",", "")), StringUtil.LTrim( ((edtNFValor_Enabled!=0) ? context.localUtil.Format( A12NFValor, "ZZZZZZZZZZZZ9.9999") : context.localUtil.Format( A12NFValor, "ZZZZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNFValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNFValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFuneraria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFuneraria_Internalname, "Funerária", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFuneraria_Internalname, StringUtil.RTrim( A13Funeraria), StringUtil.RTrim( context.localUtil.Format( A13Funeraria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFuneraria_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFuneraria_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtObservacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObservacao_Internalname, "Observação", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObservacao_Internalname, A14Observacao, StringUtil.RTrim( context.localUtil.Format( A14Observacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObservacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObservacao_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParentesco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParentesco_Internalname, "Parentesco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParentesco_Internalname, StringUtil.RTrim( A15Parentesco), StringUtil.RTrim( context.localUtil.Format( A15Parentesco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParentesco_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParentesco_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCemiterio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCemiterio_Internalname, "Cemitério", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCemiterio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16Cemiterio), 9, 0, ",", "")), StringUtil.LTrim( ((edtCemiterio_Enabled!=0) ? context.localUtil.Format( (decimal)(A16Cemiterio), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A16Cemiterio), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCemiterio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCemiterio_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtJazigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtJazigo_Internalname, "Jazigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtJazigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17Jazigo), 9, 0, ",", "")), StringUtil.LTrim( ((edtJazigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A17Jazigo), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A17Jazigo), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtJazigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtJazigo_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtQuadra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtQuadra_Internalname, "Quadra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtQuadra_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18Quadra), 9, 0, ",", "")), StringUtil.LTrim( ((edtQuadra_Enabled!=0) ? context.localUtil.Format( (decimal)(A18Quadra), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A18Quadra), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtQuadra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtQuadra_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLote_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLote_Internalname, "Lote", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLote_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19Lote), 9, 0, ",", "")), StringUtil.LTrim( ((edtLote_Enabled!=0) ? context.localUtil.Format( (decimal)(A19Lote), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A19Lote), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLote_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLote_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSeqDependente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSeqDependente_Internalname, "Seq Dependente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSeqDependente_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SeqDependente), 9, 0, ",", "")), StringUtil.LTrim( ((edtSeqDependente_Enabled!=0) ? context.localUtil.Format( (decimal)(A20SeqDependente), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A20SeqDependente), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSeqDependente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSeqDependente_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCapela_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCapela_Internalname, "Capela", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCapela_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21Capela), 9, 0, ",", "")), StringUtil.LTrim( ((edtCapela_Enabled!=0) ? context.localUtil.Format( (decimal)(A21Capela), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A21Capela), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,134);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCapela_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCapela_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnderecoFalecido_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnderecoFalecido_Internalname, "Endereco Falecido", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnderecoFalecido_Internalname, A22EnderecoFalecido, StringUtil.RTrim( context.localUtil.Format( A22EnderecoFalecido, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnderecoFalecido_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEnderecoFalecido_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edthorafalecimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edthorafalecimento_Internalname, "Hora Falecimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edthorafalecimento_Internalname, A23horafalecimento, StringUtil.RTrim( context.localUtil.Format( A23horafalecimento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,144);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edthorafalecimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edthorafalecimento_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCidadeFalecimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCidadeFalecimento_Internalname, "Cidade Falecimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCidadeFalecimento_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24CidadeFalecimento), 9, 0, ",", "")), StringUtil.LTrim( ((edtCidadeFalecimento_Enabled!=0) ? context.localUtil.Format( (decimal)(A24CidadeFalecimento), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A24CidadeFalecimento), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,149);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCidadeFalecimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCidadeFalecimento_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLocalFalecimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLocalFalecimento_Internalname, "Local Falecimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLocalFalecimento_Internalname, A25LocalFalecimento, StringUtil.RTrim( context.localUtil.Format( A25LocalFalecimento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLocalFalecimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLocalFalecimento_Enabled, 0, "text", "", 45, "chr", 1, "row", 45, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtHoraSepultamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHoraSepultamento_Internalname, "Hora Sepultamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHoraSepultamento_Internalname, A26HoraSepultamento, StringUtil.RTrim( context.localUtil.Format( A26HoraSepultamento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,159);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHoraSepultamento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHoraSepultamento_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDatasolicitacaoAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDatasolicitacaoAux_Internalname, "Datasolicitacao Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDatasolicitacaoAux_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDatasolicitacaoAux_Internalname, context.localUtil.TToC( A27DatasolicitacaoAux, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A27DatasolicitacaoAux, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,164);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDatasolicitacaoAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDatasolicitacaoAux_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_bitmap( context, edtDatasolicitacaoAux_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDatasolicitacaoAux_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Obitos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNomeContratanteAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNomeContratanteAux_Internalname, "Nome Contratante Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNomeContratanteAux_Internalname, A28NomeContratanteAux, StringUtil.RTrim( context.localUtil.Format( A28NomeContratanteAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNomeContratanteAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNomeContratanteAux_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEndContratanteAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEndContratanteAux_Internalname, "End Contratante Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEndContratanteAux_Internalname, A29EndContratanteAux, StringUtil.RTrim( context.localUtil.Format( A29EndContratanteAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,174);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEndContratanteAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEndContratanteAux_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCidadeContratanteAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCidadeContratanteAux_Internalname, "Cidade Contratante Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCidadeContratanteAux_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CidadeContratanteAux), 9, 0, ",", "")), StringUtil.LTrim( ((edtCidadeContratanteAux_Enabled!=0) ? context.localUtil.Format( (decimal)(A30CidadeContratanteAux), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A30CidadeContratanteAux), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCidadeContratanteAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCidadeContratanteAux_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRGContratanteAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRGContratanteAux_Internalname, "RGContratante Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 184,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRGContratanteAux_Internalname, A31RGContratanteAux, StringUtil.RTrim( context.localUtil.Format( A31RGContratanteAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,184);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRGContratanteAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRGContratanteAux_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCPFContratanteAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCPFContratanteAux_Internalname, "CPFContratante Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPFContratanteAux_Internalname, A32CPFContratanteAux, StringUtil.RTrim( context.localUtil.Format( A32CPFContratanteAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,189);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPFContratanteAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPFContratanteAux_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEstCivilContratanteAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstCivilContratanteAux_Internalname, "Est Civil Contratante Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstCivilContratanteAux_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33EstCivilContratanteAux), 9, 0, ",", "")), StringUtil.LTrim( ((edtEstCivilContratanteAux_Enabled!=0) ? context.localUtil.Format( (decimal)(A33EstCivilContratanteAux), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A33EstCivilContratanteAux), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,194);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstCivilContratanteAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEstCivilContratanteAux_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDataInsert_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDataInsert_Internalname, "Data Insert", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDataInsert_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDataInsert_Internalname, context.localUtil.TToC( A34DataInsert, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A34DataInsert, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,199);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataInsert_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDataInsert_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_bitmap( context, edtDataInsert_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataInsert_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Obitos.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuInsert_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuInsert_Internalname, "Usu Insert", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuInsert_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35UsuInsert), 9, 0, ",", "")), StringUtil.LTrim( ((edtUsuInsert_Enabled!=0) ? context.localUtil.Format( (decimal)(A35UsuInsert), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A35UsuInsert), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,204);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuInsert_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuInsert_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDataUpdate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDataUpdate_Internalname, "Data Update", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDataUpdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDataUpdate_Internalname, context.localUtil.TToC( A36DataUpdate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A36DataUpdate, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,209);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataUpdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDataUpdate_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_bitmap( context, edtDataUpdate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataUpdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Obitos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuUpdate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuUpdate_Internalname, "Usu Update", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuUpdate_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37UsuUpdate), 9, 0, ",", "")), StringUtil.LTrim( ((edtUsuUpdate_Enabled!=0) ? context.localUtil.Format( (decimal)(A37UsuUpdate), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A37UsuUpdate), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,214);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuUpdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuUpdate_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNumControleAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNumControleAux_Internalname, "Num Controle Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 219,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNumControleAux_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38NumControleAux), 9, 0, ",", "")), StringUtil.LTrim( ((edtNumControleAux_Enabled!=0) ? context.localUtil.Format( (decimal)(A38NumControleAux), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A38NumControleAux), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,219);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNumControleAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNumControleAux_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtValorAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtValorAux_Internalname, "Valor Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtValorAux_Internalname, StringUtil.LTrim( StringUtil.NToC( A39ValorAux, 18, 4, ",", "")), StringUtil.LTrim( ((edtValorAux_Enabled!=0) ? context.localUtil.Format( A39ValorAux, "ZZZZZZZZZZZZ9.9999") : context.localUtil.Format( A39ValorAux, "ZZZZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,224);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtValorAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtValorAux_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDataPagtoAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDataPagtoAux_Internalname, "Data Pagto Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 229,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDataPagtoAux_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDataPagtoAux_Internalname, context.localUtil.TToC( A40DataPagtoAux, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A40DataPagtoAux, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,229);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataPagtoAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDataPagtoAux_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_bitmap( context, edtDataPagtoAux_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataPagtoAux_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Obitos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtObservacaoAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObservacaoAux_Internalname, "Observacao Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 234,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtObservacaoAux_Internalname, A41ObservacaoAux, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,234);\"", 0, 1, edtObservacaoAux_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEmCarencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmCarencia_Internalname, "Em Carencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 239,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmCarencia_Internalname, StringUtil.RTrim( A42EmCarencia), StringUtil.RTrim( context.localUtil.Format( A42EmCarencia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,239);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmCarencia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmCarencia_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPercentualCobertura_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPercentualCobertura_Internalname, "Percentual Cobertura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 244,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPercentualCobertura_Internalname, StringUtil.LTrim( StringUtil.NToC( A43PercentualCobertura, 18, 4, ",", "")), StringUtil.LTrim( ((edtPercentualCobertura_Enabled!=0) ? context.localUtil.Format( A43PercentualCobertura, "ZZZZZZZZZZZZ9.9999") : context.localUtil.Format( A43PercentualCobertura, "ZZZZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,244);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPercentualCobertura_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPercentualCobertura_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPacienteUnesp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPacienteUnesp_Internalname, "Paciente Unesp", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 249,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPacienteUnesp_Internalname, StringUtil.RTrim( A44PacienteUnesp), StringUtil.RTrim( context.localUtil.Format( A44PacienteUnesp, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,249);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPacienteUnesp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPacienteUnesp_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRegistroUnesp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRegistroUnesp_Internalname, "Registro Unesp", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 254,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRegistroUnesp_Internalname, A45RegistroUnesp, StringUtil.RTrim( context.localUtil.Format( A45RegistroUnesp, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,254);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRegistroUnesp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRegistroUnesp_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRelatoObito_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRelatoObito_Internalname, "Relato Obito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 259,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRelatoObito_Internalname, A46RelatoObito, A46RelatoObito, TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,259);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRelatoObito_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRelatoObito_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, 0, -1, true, "", "start", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtViciosHabituais_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtViciosHabituais_Internalname, "Vicios Habituais", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 264,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtViciosHabituais_Internalname, StringUtil.RTrim( A47ViciosHabituais), StringUtil.RTrim( context.localUtil.Format( A47ViciosHabituais, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,264);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtViciosHabituais_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtViciosHabituais_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtViciosEspecificar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtViciosEspecificar_Internalname, "Vicios Especificar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 269,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtViciosEspecificar_Internalname, A48ViciosEspecificar, StringUtil.RTrim( context.localUtil.Format( A48ViciosEspecificar, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,269);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtViciosEspecificar_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtViciosEspecificar_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDoencasConhecidas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDoencasConhecidas_Internalname, "Doencas Conhecidas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDoencasConhecidas_Internalname, A49DoencasConhecidas, StringUtil.RTrim( context.localUtil.Format( A49DoencasConhecidas, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,274);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDoencasConhecidas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDoencasConhecidas_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTaxaCapelaAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxaCapelaAux_Internalname, "Taxa Capela Aux", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 279,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxaCapelaAux_Internalname, StringUtil.LTrim( StringUtil.NToC( A50TaxaCapelaAux, 18, 4, ",", "")), StringUtil.LTrim( ((edtTaxaCapelaAux_Enabled!=0) ? context.localUtil.Format( A50TaxaCapelaAux, "ZZZZZZZZZZZZ9.9999") : context.localUtil.Format( A50TaxaCapelaAux, "ZZZZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,279);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxaCapelaAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTaxaCapelaAux_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTaxaSepultamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTaxaSepultamento_Internalname, "Taxa Sepultamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTaxaSepultamento_Internalname, StringUtil.LTrim( StringUtil.NToC( A51TaxaSepultamento, 18, 4, ",", "")), StringUtil.LTrim( ((edtTaxaSepultamento_Enabled!=0) ? context.localUtil.Format( A51TaxaSepultamento, "ZZZZZZZZZZZZ9.9999") : context.localUtil.Format( A51TaxaSepultamento, "ZZZZZZZZZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,284);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTaxaSepultamento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTaxaSepultamento_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMatricula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMatricula_Internalname, "Matricula", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 289,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMatricula_Internalname, A52Matricula, StringUtil.RTrim( context.localUtil.Format( A52Matricula, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,289);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMatricula_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMatricula_Enabled, 0, "text", "", 38, "chr", 1, "row", 38, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsouCremacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsouCremacao_Internalname, "Usou Cremacao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 294,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsouCremacao_Internalname, StringUtil.RTrim( A53UsouCremacao), StringUtil.RTrim( context.localUtil.Format( A53UsouCremacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,294);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsouCremacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsouCremacao_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSeq_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSeq_Internalname, "Seq", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 299,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A54Seq), 9, 0, ",", "")), StringUtil.LTrim( ((edtSeq_Enabled!=0) ? context.localUtil.Format( (decimal)(A54Seq), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A54Seq), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,299);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSeq_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSeq_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Obitos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 304,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 306,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 308,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Obitos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1Inscricao"), ",", "."), 18, MidpointRounding.ToEven));
               Z2Nome = cgiGet( "Z2Nome");
               Z3Grupo = cgiGet( "Z3Grupo");
               n3Grupo = (String.IsNullOrEmpty(StringUtil.RTrim( A3Grupo)) ? true : false);
               Z4Referencia = cgiGet( "Z4Referencia");
               n4Referencia = (String.IsNullOrEmpty(StringUtil.RTrim( A4Referencia)) ? true : false);
               Z5Numero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z5Numero"), ",", "."), 18, MidpointRounding.ToEven));
               n5Numero = ((0==A5Numero) ? true : false);
               Z6Valor = context.localUtil.CToN( cgiGet( "Z6Valor"), ",", ".");
               n6Valor = ((Convert.ToDecimal(0)==A6Valor) ? true : false);
               Z7Vencimento = context.localUtil.CToT( cgiGet( "Z7Vencimento"), 0);
               n7Vencimento = ((DateTime.MinValue==A7Vencimento) ? true : false);
               Z8Nascimento = context.localUtil.CToT( cgiGet( "Z8Nascimento"), 0);
               n8Nascimento = ((DateTime.MinValue==A8Nascimento) ? true : false);
               Z9Falecimento = context.localUtil.CToT( cgiGet( "Z9Falecimento"), 0);
               n9Falecimento = ((DateTime.MinValue==A9Falecimento) ? true : false);
               Z10NumeroObito = cgiGet( "Z10NumeroObito");
               n10NumeroObito = (String.IsNullOrEmpty(StringUtil.RTrim( A10NumeroObito)) ? true : false);
               Z11NFNumero = cgiGet( "Z11NFNumero");
               n11NFNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A11NFNumero)) ? true : false);
               Z12NFValor = context.localUtil.CToN( cgiGet( "Z12NFValor"), ",", ".");
               n12NFValor = ((Convert.ToDecimal(0)==A12NFValor) ? true : false);
               Z13Funeraria = cgiGet( "Z13Funeraria");
               n13Funeraria = (String.IsNullOrEmpty(StringUtil.RTrim( A13Funeraria)) ? true : false);
               Z14Observacao = cgiGet( "Z14Observacao");
               n14Observacao = (String.IsNullOrEmpty(StringUtil.RTrim( A14Observacao)) ? true : false);
               Z15Parentesco = cgiGet( "Z15Parentesco");
               n15Parentesco = (String.IsNullOrEmpty(StringUtil.RTrim( A15Parentesco)) ? true : false);
               Z16Cemiterio = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z16Cemiterio"), ",", "."), 18, MidpointRounding.ToEven));
               n16Cemiterio = ((0==A16Cemiterio) ? true : false);
               Z17Jazigo = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z17Jazigo"), ",", "."), 18, MidpointRounding.ToEven));
               n17Jazigo = ((0==A17Jazigo) ? true : false);
               Z18Quadra = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z18Quadra"), ",", "."), 18, MidpointRounding.ToEven));
               n18Quadra = ((0==A18Quadra) ? true : false);
               Z19Lote = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z19Lote"), ",", "."), 18, MidpointRounding.ToEven));
               n19Lote = ((0==A19Lote) ? true : false);
               Z20SeqDependente = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z20SeqDependente"), ",", "."), 18, MidpointRounding.ToEven));
               n20SeqDependente = ((0==A20SeqDependente) ? true : false);
               Z21Capela = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z21Capela"), ",", "."), 18, MidpointRounding.ToEven));
               n21Capela = ((0==A21Capela) ? true : false);
               Z22EnderecoFalecido = cgiGet( "Z22EnderecoFalecido");
               n22EnderecoFalecido = (String.IsNullOrEmpty(StringUtil.RTrim( A22EnderecoFalecido)) ? true : false);
               Z23horafalecimento = cgiGet( "Z23horafalecimento");
               n23horafalecimento = (String.IsNullOrEmpty(StringUtil.RTrim( A23horafalecimento)) ? true : false);
               Z24CidadeFalecimento = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z24CidadeFalecimento"), ",", "."), 18, MidpointRounding.ToEven));
               n24CidadeFalecimento = ((0==A24CidadeFalecimento) ? true : false);
               Z25LocalFalecimento = cgiGet( "Z25LocalFalecimento");
               n25LocalFalecimento = (String.IsNullOrEmpty(StringUtil.RTrim( A25LocalFalecimento)) ? true : false);
               Z26HoraSepultamento = cgiGet( "Z26HoraSepultamento");
               n26HoraSepultamento = (String.IsNullOrEmpty(StringUtil.RTrim( A26HoraSepultamento)) ? true : false);
               Z27DatasolicitacaoAux = context.localUtil.CToT( cgiGet( "Z27DatasolicitacaoAux"), 0);
               n27DatasolicitacaoAux = ((DateTime.MinValue==A27DatasolicitacaoAux) ? true : false);
               Z28NomeContratanteAux = cgiGet( "Z28NomeContratanteAux");
               n28NomeContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A28NomeContratanteAux)) ? true : false);
               Z29EndContratanteAux = cgiGet( "Z29EndContratanteAux");
               n29EndContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A29EndContratanteAux)) ? true : false);
               Z30CidadeContratanteAux = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z30CidadeContratanteAux"), ",", "."), 18, MidpointRounding.ToEven));
               n30CidadeContratanteAux = ((0==A30CidadeContratanteAux) ? true : false);
               Z31RGContratanteAux = cgiGet( "Z31RGContratanteAux");
               n31RGContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A31RGContratanteAux)) ? true : false);
               Z32CPFContratanteAux = cgiGet( "Z32CPFContratanteAux");
               n32CPFContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A32CPFContratanteAux)) ? true : false);
               Z33EstCivilContratanteAux = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z33EstCivilContratanteAux"), ",", "."), 18, MidpointRounding.ToEven));
               n33EstCivilContratanteAux = ((0==A33EstCivilContratanteAux) ? true : false);
               Z34DataInsert = context.localUtil.CToT( cgiGet( "Z34DataInsert"), 0);
               n34DataInsert = ((DateTime.MinValue==A34DataInsert) ? true : false);
               Z35UsuInsert = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z35UsuInsert"), ",", "."), 18, MidpointRounding.ToEven));
               n35UsuInsert = ((0==A35UsuInsert) ? true : false);
               Z36DataUpdate = context.localUtil.CToT( cgiGet( "Z36DataUpdate"), 0);
               n36DataUpdate = ((DateTime.MinValue==A36DataUpdate) ? true : false);
               Z37UsuUpdate = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z37UsuUpdate"), ",", "."), 18, MidpointRounding.ToEven));
               n37UsuUpdate = ((0==A37UsuUpdate) ? true : false);
               Z38NumControleAux = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z38NumControleAux"), ",", "."), 18, MidpointRounding.ToEven));
               n38NumControleAux = ((0==A38NumControleAux) ? true : false);
               Z39ValorAux = context.localUtil.CToN( cgiGet( "Z39ValorAux"), ",", ".");
               n39ValorAux = ((Convert.ToDecimal(0)==A39ValorAux) ? true : false);
               Z40DataPagtoAux = context.localUtil.CToT( cgiGet( "Z40DataPagtoAux"), 0);
               n40DataPagtoAux = ((DateTime.MinValue==A40DataPagtoAux) ? true : false);
               Z41ObservacaoAux = cgiGet( "Z41ObservacaoAux");
               n41ObservacaoAux = (String.IsNullOrEmpty(StringUtil.RTrim( A41ObservacaoAux)) ? true : false);
               Z42EmCarencia = cgiGet( "Z42EmCarencia");
               n42EmCarencia = (String.IsNullOrEmpty(StringUtil.RTrim( A42EmCarencia)) ? true : false);
               Z43PercentualCobertura = context.localUtil.CToN( cgiGet( "Z43PercentualCobertura"), ",", ".");
               n43PercentualCobertura = ((Convert.ToDecimal(0)==A43PercentualCobertura) ? true : false);
               Z44PacienteUnesp = cgiGet( "Z44PacienteUnesp");
               n44PacienteUnesp = (String.IsNullOrEmpty(StringUtil.RTrim( A44PacienteUnesp)) ? true : false);
               Z45RegistroUnesp = cgiGet( "Z45RegistroUnesp");
               n45RegistroUnesp = (String.IsNullOrEmpty(StringUtil.RTrim( A45RegistroUnesp)) ? true : false);
               Z47ViciosHabituais = cgiGet( "Z47ViciosHabituais");
               n47ViciosHabituais = (String.IsNullOrEmpty(StringUtil.RTrim( A47ViciosHabituais)) ? true : false);
               Z48ViciosEspecificar = cgiGet( "Z48ViciosEspecificar");
               n48ViciosEspecificar = (String.IsNullOrEmpty(StringUtil.RTrim( A48ViciosEspecificar)) ? true : false);
               Z49DoencasConhecidas = cgiGet( "Z49DoencasConhecidas");
               n49DoencasConhecidas = (String.IsNullOrEmpty(StringUtil.RTrim( A49DoencasConhecidas)) ? true : false);
               Z50TaxaCapelaAux = context.localUtil.CToN( cgiGet( "Z50TaxaCapelaAux"), ",", ".");
               n50TaxaCapelaAux = ((Convert.ToDecimal(0)==A50TaxaCapelaAux) ? true : false);
               Z51TaxaSepultamento = context.localUtil.CToN( cgiGet( "Z51TaxaSepultamento"), ",", ".");
               n51TaxaSepultamento = ((Convert.ToDecimal(0)==A51TaxaSepultamento) ? true : false);
               Z52Matricula = cgiGet( "Z52Matricula");
               n52Matricula = (String.IsNullOrEmpty(StringUtil.RTrim( A52Matricula)) ? true : false);
               Z53UsouCremacao = cgiGet( "Z53UsouCremacao");
               n53UsouCremacao = (String.IsNullOrEmpty(StringUtil.RTrim( A53UsouCremacao)) ? true : false);
               Z54Seq = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z54Seq"), ",", "."), 18, MidpointRounding.ToEven));
               n54Seq = ((0==A54Seq) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSCRICAO"), ",", "."), 18, MidpointRounding.ToEven));
               AV8Nome = cgiGet( "vNOME");
               AV12Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtInscricao_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInscricao_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INSCRICAO");
                  AnyError = 1;
                  GX_FocusControl = edtInscricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1Inscricao = 0;
                  AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
               }
               else
               {
                  A1Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInscricao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
               }
               A2Nome = cgiGet( edtNome_Internalname);
               AssignAttri("", false, "A2Nome", A2Nome);
               A3Grupo = cgiGet( edtGrupo_Internalname);
               n3Grupo = false;
               AssignAttri("", false, "A3Grupo", A3Grupo);
               n3Grupo = (String.IsNullOrEmpty(StringUtil.RTrim( A3Grupo)) ? true : false);
               A4Referencia = cgiGet( edtReferencia_Internalname);
               n4Referencia = false;
               AssignAttri("", false, "A4Referencia", A4Referencia);
               n4Referencia = (String.IsNullOrEmpty(StringUtil.RTrim( A4Referencia)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A5Numero = 0;
                  n5Numero = false;
                  AssignAttri("", false, "A5Numero", StringUtil.LTrimStr( (decimal)(A5Numero), 9, 0));
               }
               else
               {
                  A5Numero = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n5Numero = false;
                  AssignAttri("", false, "A5Numero", StringUtil.LTrimStr( (decimal)(A5Numero), 9, 0));
               }
               n5Numero = ((0==A5Numero) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtValor_Internalname), ",", ".") > 9999999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VALOR");
                  AnyError = 1;
                  GX_FocusControl = edtValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6Valor = 0;
                  n6Valor = false;
                  AssignAttri("", false, "A6Valor", StringUtil.LTrimStr( A6Valor, 18, 4));
               }
               else
               {
                  A6Valor = context.localUtil.CToN( cgiGet( edtValor_Internalname), ",", ".");
                  n6Valor = false;
                  AssignAttri("", false, "A6Valor", StringUtil.LTrimStr( A6Valor, 18, 4));
               }
               n6Valor = ((Convert.ToDecimal(0)==A6Valor) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtVencimento_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Vencimento"}), 1, "VENCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtVencimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7Vencimento = (DateTime)(DateTime.MinValue);
                  n7Vencimento = false;
                  AssignAttri("", false, "A7Vencimento", context.localUtil.TToC( A7Vencimento, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A7Vencimento = context.localUtil.CToT( cgiGet( edtVencimento_Internalname));
                  n7Vencimento = false;
                  AssignAttri("", false, "A7Vencimento", context.localUtil.TToC( A7Vencimento, 10, 8, 0, 3, "/", ":", " "));
               }
               n7Vencimento = ((DateTime.MinValue==A7Vencimento) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtNascimento_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Nascimento"}), 1, "NASCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtNascimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8Nascimento = (DateTime)(DateTime.MinValue);
                  n8Nascimento = false;
                  AssignAttri("", false, "A8Nascimento", context.localUtil.TToC( A8Nascimento, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A8Nascimento = context.localUtil.CToT( cgiGet( edtNascimento_Internalname));
                  n8Nascimento = false;
                  AssignAttri("", false, "A8Nascimento", context.localUtil.TToC( A8Nascimento, 10, 8, 0, 3, "/", ":", " "));
               }
               n8Nascimento = ((DateTime.MinValue==A8Nascimento) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtFalecimento_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Falecimento"}), 1, "FALECIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtFalecimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9Falecimento = (DateTime)(DateTime.MinValue);
                  n9Falecimento = false;
                  AssignAttri("", false, "A9Falecimento", context.localUtil.TToC( A9Falecimento, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A9Falecimento = context.localUtil.CToT( cgiGet( edtFalecimento_Internalname));
                  n9Falecimento = false;
                  AssignAttri("", false, "A9Falecimento", context.localUtil.TToC( A9Falecimento, 10, 8, 0, 3, "/", ":", " "));
               }
               n9Falecimento = ((DateTime.MinValue==A9Falecimento) ? true : false);
               A10NumeroObito = cgiGet( edtNumeroObito_Internalname);
               n10NumeroObito = false;
               AssignAttri("", false, "A10NumeroObito", A10NumeroObito);
               n10NumeroObito = (String.IsNullOrEmpty(StringUtil.RTrim( A10NumeroObito)) ? true : false);
               A11NFNumero = cgiGet( edtNFNumero_Internalname);
               n11NFNumero = false;
               AssignAttri("", false, "A11NFNumero", A11NFNumero);
               n11NFNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A11NFNumero)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNFValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNFValor_Internalname), ",", ".") > 9999999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NFVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtNFValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12NFValor = 0;
                  n12NFValor = false;
                  AssignAttri("", false, "A12NFValor", StringUtil.LTrimStr( A12NFValor, 18, 4));
               }
               else
               {
                  A12NFValor = context.localUtil.CToN( cgiGet( edtNFValor_Internalname), ",", ".");
                  n12NFValor = false;
                  AssignAttri("", false, "A12NFValor", StringUtil.LTrimStr( A12NFValor, 18, 4));
               }
               n12NFValor = ((Convert.ToDecimal(0)==A12NFValor) ? true : false);
               A13Funeraria = cgiGet( edtFuneraria_Internalname);
               n13Funeraria = false;
               AssignAttri("", false, "A13Funeraria", A13Funeraria);
               n13Funeraria = (String.IsNullOrEmpty(StringUtil.RTrim( A13Funeraria)) ? true : false);
               A14Observacao = cgiGet( edtObservacao_Internalname);
               n14Observacao = false;
               AssignAttri("", false, "A14Observacao", A14Observacao);
               n14Observacao = (String.IsNullOrEmpty(StringUtil.RTrim( A14Observacao)) ? true : false);
               A15Parentesco = cgiGet( edtParentesco_Internalname);
               n15Parentesco = false;
               AssignAttri("", false, "A15Parentesco", A15Parentesco);
               n15Parentesco = (String.IsNullOrEmpty(StringUtil.RTrim( A15Parentesco)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCemiterio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCemiterio_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CEMITERIO");
                  AnyError = 1;
                  GX_FocusControl = edtCemiterio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16Cemiterio = 0;
                  n16Cemiterio = false;
                  AssignAttri("", false, "A16Cemiterio", StringUtil.LTrimStr( (decimal)(A16Cemiterio), 9, 0));
               }
               else
               {
                  A16Cemiterio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCemiterio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n16Cemiterio = false;
                  AssignAttri("", false, "A16Cemiterio", StringUtil.LTrimStr( (decimal)(A16Cemiterio), 9, 0));
               }
               n16Cemiterio = ((0==A16Cemiterio) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtJazigo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtJazigo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "JAZIGO");
                  AnyError = 1;
                  GX_FocusControl = edtJazigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17Jazigo = 0;
                  n17Jazigo = false;
                  AssignAttri("", false, "A17Jazigo", StringUtil.LTrimStr( (decimal)(A17Jazigo), 9, 0));
               }
               else
               {
                  A17Jazigo = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtJazigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n17Jazigo = false;
                  AssignAttri("", false, "A17Jazigo", StringUtil.LTrimStr( (decimal)(A17Jazigo), 9, 0));
               }
               n17Jazigo = ((0==A17Jazigo) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtQuadra_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtQuadra_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "QUADRA");
                  AnyError = 1;
                  GX_FocusControl = edtQuadra_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A18Quadra = 0;
                  n18Quadra = false;
                  AssignAttri("", false, "A18Quadra", StringUtil.LTrimStr( (decimal)(A18Quadra), 9, 0));
               }
               else
               {
                  A18Quadra = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtQuadra_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n18Quadra = false;
                  AssignAttri("", false, "A18Quadra", StringUtil.LTrimStr( (decimal)(A18Quadra), 9, 0));
               }
               n18Quadra = ((0==A18Quadra) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLote_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLote_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOTE");
                  AnyError = 1;
                  GX_FocusControl = edtLote_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A19Lote = 0;
                  n19Lote = false;
                  AssignAttri("", false, "A19Lote", StringUtil.LTrimStr( (decimal)(A19Lote), 9, 0));
               }
               else
               {
                  A19Lote = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtLote_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n19Lote = false;
                  AssignAttri("", false, "A19Lote", StringUtil.LTrimStr( (decimal)(A19Lote), 9, 0));
               }
               n19Lote = ((0==A19Lote) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSeqDependente_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSeqDependente_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SEQDEPENDENTE");
                  AnyError = 1;
                  GX_FocusControl = edtSeqDependente_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A20SeqDependente = 0;
                  n20SeqDependente = false;
                  AssignAttri("", false, "A20SeqDependente", StringUtil.LTrimStr( (decimal)(A20SeqDependente), 9, 0));
               }
               else
               {
                  A20SeqDependente = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSeqDependente_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n20SeqDependente = false;
                  AssignAttri("", false, "A20SeqDependente", StringUtil.LTrimStr( (decimal)(A20SeqDependente), 9, 0));
               }
               n20SeqDependente = ((0==A20SeqDependente) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCapela_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCapela_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAPELA");
                  AnyError = 1;
                  GX_FocusControl = edtCapela_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A21Capela = 0;
                  n21Capela = false;
                  AssignAttri("", false, "A21Capela", StringUtil.LTrimStr( (decimal)(A21Capela), 9, 0));
               }
               else
               {
                  A21Capela = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCapela_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n21Capela = false;
                  AssignAttri("", false, "A21Capela", StringUtil.LTrimStr( (decimal)(A21Capela), 9, 0));
               }
               n21Capela = ((0==A21Capela) ? true : false);
               A22EnderecoFalecido = cgiGet( edtEnderecoFalecido_Internalname);
               n22EnderecoFalecido = false;
               AssignAttri("", false, "A22EnderecoFalecido", A22EnderecoFalecido);
               n22EnderecoFalecido = (String.IsNullOrEmpty(StringUtil.RTrim( A22EnderecoFalecido)) ? true : false);
               A23horafalecimento = cgiGet( edthorafalecimento_Internalname);
               n23horafalecimento = false;
               AssignAttri("", false, "A23horafalecimento", A23horafalecimento);
               n23horafalecimento = (String.IsNullOrEmpty(StringUtil.RTrim( A23horafalecimento)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCidadeFalecimento_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCidadeFalecimento_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CIDADEFALECIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtCidadeFalecimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A24CidadeFalecimento = 0;
                  n24CidadeFalecimento = false;
                  AssignAttri("", false, "A24CidadeFalecimento", StringUtil.LTrimStr( (decimal)(A24CidadeFalecimento), 9, 0));
               }
               else
               {
                  A24CidadeFalecimento = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCidadeFalecimento_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n24CidadeFalecimento = false;
                  AssignAttri("", false, "A24CidadeFalecimento", StringUtil.LTrimStr( (decimal)(A24CidadeFalecimento), 9, 0));
               }
               n24CidadeFalecimento = ((0==A24CidadeFalecimento) ? true : false);
               A25LocalFalecimento = cgiGet( edtLocalFalecimento_Internalname);
               n25LocalFalecimento = false;
               AssignAttri("", false, "A25LocalFalecimento", A25LocalFalecimento);
               n25LocalFalecimento = (String.IsNullOrEmpty(StringUtil.RTrim( A25LocalFalecimento)) ? true : false);
               A26HoraSepultamento = cgiGet( edtHoraSepultamento_Internalname);
               n26HoraSepultamento = false;
               AssignAttri("", false, "A26HoraSepultamento", A26HoraSepultamento);
               n26HoraSepultamento = (String.IsNullOrEmpty(StringUtil.RTrim( A26HoraSepultamento)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtDatasolicitacaoAux_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Datasolicitacao Aux"}), 1, "DATASOLICITACAOAUX");
                  AnyError = 1;
                  GX_FocusControl = edtDatasolicitacaoAux_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A27DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
                  n27DatasolicitacaoAux = false;
                  AssignAttri("", false, "A27DatasolicitacaoAux", context.localUtil.TToC( A27DatasolicitacaoAux, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A27DatasolicitacaoAux = context.localUtil.CToT( cgiGet( edtDatasolicitacaoAux_Internalname));
                  n27DatasolicitacaoAux = false;
                  AssignAttri("", false, "A27DatasolicitacaoAux", context.localUtil.TToC( A27DatasolicitacaoAux, 10, 8, 0, 3, "/", ":", " "));
               }
               n27DatasolicitacaoAux = ((DateTime.MinValue==A27DatasolicitacaoAux) ? true : false);
               A28NomeContratanteAux = cgiGet( edtNomeContratanteAux_Internalname);
               n28NomeContratanteAux = false;
               AssignAttri("", false, "A28NomeContratanteAux", A28NomeContratanteAux);
               n28NomeContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A28NomeContratanteAux)) ? true : false);
               A29EndContratanteAux = cgiGet( edtEndContratanteAux_Internalname);
               n29EndContratanteAux = false;
               AssignAttri("", false, "A29EndContratanteAux", A29EndContratanteAux);
               n29EndContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A29EndContratanteAux)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCidadeContratanteAux_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCidadeContratanteAux_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CIDADECONTRATANTEAUX");
                  AnyError = 1;
                  GX_FocusControl = edtCidadeContratanteAux_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A30CidadeContratanteAux = 0;
                  n30CidadeContratanteAux = false;
                  AssignAttri("", false, "A30CidadeContratanteAux", StringUtil.LTrimStr( (decimal)(A30CidadeContratanteAux), 9, 0));
               }
               else
               {
                  A30CidadeContratanteAux = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCidadeContratanteAux_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n30CidadeContratanteAux = false;
                  AssignAttri("", false, "A30CidadeContratanteAux", StringUtil.LTrimStr( (decimal)(A30CidadeContratanteAux), 9, 0));
               }
               n30CidadeContratanteAux = ((0==A30CidadeContratanteAux) ? true : false);
               A31RGContratanteAux = cgiGet( edtRGContratanteAux_Internalname);
               n31RGContratanteAux = false;
               AssignAttri("", false, "A31RGContratanteAux", A31RGContratanteAux);
               n31RGContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A31RGContratanteAux)) ? true : false);
               A32CPFContratanteAux = cgiGet( edtCPFContratanteAux_Internalname);
               n32CPFContratanteAux = false;
               AssignAttri("", false, "A32CPFContratanteAux", A32CPFContratanteAux);
               n32CPFContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A32CPFContratanteAux)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstCivilContratanteAux_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstCivilContratanteAux_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTCIVILCONTRATANTEAUX");
                  AnyError = 1;
                  GX_FocusControl = edtEstCivilContratanteAux_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A33EstCivilContratanteAux = 0;
                  n33EstCivilContratanteAux = false;
                  AssignAttri("", false, "A33EstCivilContratanteAux", StringUtil.LTrimStr( (decimal)(A33EstCivilContratanteAux), 9, 0));
               }
               else
               {
                  A33EstCivilContratanteAux = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEstCivilContratanteAux_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n33EstCivilContratanteAux = false;
                  AssignAttri("", false, "A33EstCivilContratanteAux", StringUtil.LTrimStr( (decimal)(A33EstCivilContratanteAux), 9, 0));
               }
               n33EstCivilContratanteAux = ((0==A33EstCivilContratanteAux) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtDataInsert_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Insert"}), 1, "DATAINSERT");
                  AnyError = 1;
                  GX_FocusControl = edtDataInsert_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A34DataInsert = (DateTime)(DateTime.MinValue);
                  n34DataInsert = false;
                  AssignAttri("", false, "A34DataInsert", context.localUtil.TToC( A34DataInsert, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A34DataInsert = context.localUtil.CToT( cgiGet( edtDataInsert_Internalname));
                  n34DataInsert = false;
                  AssignAttri("", false, "A34DataInsert", context.localUtil.TToC( A34DataInsert, 10, 8, 0, 3, "/", ":", " "));
               }
               n34DataInsert = ((DateTime.MinValue==A34DataInsert) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuInsert_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuInsert_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUINSERT");
                  AnyError = 1;
                  GX_FocusControl = edtUsuInsert_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A35UsuInsert = 0;
                  n35UsuInsert = false;
                  AssignAttri("", false, "A35UsuInsert", StringUtil.LTrimStr( (decimal)(A35UsuInsert), 9, 0));
               }
               else
               {
                  A35UsuInsert = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuInsert_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n35UsuInsert = false;
                  AssignAttri("", false, "A35UsuInsert", StringUtil.LTrimStr( (decimal)(A35UsuInsert), 9, 0));
               }
               n35UsuInsert = ((0==A35UsuInsert) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtDataUpdate_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Update"}), 1, "DATAUPDATE");
                  AnyError = 1;
                  GX_FocusControl = edtDataUpdate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A36DataUpdate = (DateTime)(DateTime.MinValue);
                  n36DataUpdate = false;
                  AssignAttri("", false, "A36DataUpdate", context.localUtil.TToC( A36DataUpdate, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A36DataUpdate = context.localUtil.CToT( cgiGet( edtDataUpdate_Internalname));
                  n36DataUpdate = false;
                  AssignAttri("", false, "A36DataUpdate", context.localUtil.TToC( A36DataUpdate, 10, 8, 0, 3, "/", ":", " "));
               }
               n36DataUpdate = ((DateTime.MinValue==A36DataUpdate) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuUpdate_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuUpdate_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUUPDATE");
                  AnyError = 1;
                  GX_FocusControl = edtUsuUpdate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A37UsuUpdate = 0;
                  n37UsuUpdate = false;
                  AssignAttri("", false, "A37UsuUpdate", StringUtil.LTrimStr( (decimal)(A37UsuUpdate), 9, 0));
               }
               else
               {
                  A37UsuUpdate = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuUpdate_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n37UsuUpdate = false;
                  AssignAttri("", false, "A37UsuUpdate", StringUtil.LTrimStr( (decimal)(A37UsuUpdate), 9, 0));
               }
               n37UsuUpdate = ((0==A37UsuUpdate) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNumControleAux_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNumControleAux_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NUMCONTROLEAUX");
                  AnyError = 1;
                  GX_FocusControl = edtNumControleAux_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A38NumControleAux = 0;
                  n38NumControleAux = false;
                  AssignAttri("", false, "A38NumControleAux", StringUtil.LTrimStr( (decimal)(A38NumControleAux), 9, 0));
               }
               else
               {
                  A38NumControleAux = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNumControleAux_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n38NumControleAux = false;
                  AssignAttri("", false, "A38NumControleAux", StringUtil.LTrimStr( (decimal)(A38NumControleAux), 9, 0));
               }
               n38NumControleAux = ((0==A38NumControleAux) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtValorAux_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtValorAux_Internalname), ",", ".") > 9999999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VALORAUX");
                  AnyError = 1;
                  GX_FocusControl = edtValorAux_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A39ValorAux = 0;
                  n39ValorAux = false;
                  AssignAttri("", false, "A39ValorAux", StringUtil.LTrimStr( A39ValorAux, 18, 4));
               }
               else
               {
                  A39ValorAux = context.localUtil.CToN( cgiGet( edtValorAux_Internalname), ",", ".");
                  n39ValorAux = false;
                  AssignAttri("", false, "A39ValorAux", StringUtil.LTrimStr( A39ValorAux, 18, 4));
               }
               n39ValorAux = ((Convert.ToDecimal(0)==A39ValorAux) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtDataPagtoAux_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data Pagto Aux"}), 1, "DATAPAGTOAUX");
                  AnyError = 1;
                  GX_FocusControl = edtDataPagtoAux_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A40DataPagtoAux = (DateTime)(DateTime.MinValue);
                  n40DataPagtoAux = false;
                  AssignAttri("", false, "A40DataPagtoAux", context.localUtil.TToC( A40DataPagtoAux, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A40DataPagtoAux = context.localUtil.CToT( cgiGet( edtDataPagtoAux_Internalname));
                  n40DataPagtoAux = false;
                  AssignAttri("", false, "A40DataPagtoAux", context.localUtil.TToC( A40DataPagtoAux, 10, 8, 0, 3, "/", ":", " "));
               }
               n40DataPagtoAux = ((DateTime.MinValue==A40DataPagtoAux) ? true : false);
               A41ObservacaoAux = cgiGet( edtObservacaoAux_Internalname);
               n41ObservacaoAux = false;
               AssignAttri("", false, "A41ObservacaoAux", A41ObservacaoAux);
               n41ObservacaoAux = (String.IsNullOrEmpty(StringUtil.RTrim( A41ObservacaoAux)) ? true : false);
               A42EmCarencia = cgiGet( edtEmCarencia_Internalname);
               n42EmCarencia = false;
               AssignAttri("", false, "A42EmCarencia", A42EmCarencia);
               n42EmCarencia = (String.IsNullOrEmpty(StringUtil.RTrim( A42EmCarencia)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPercentualCobertura_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPercentualCobertura_Internalname), ",", ".") > 9999999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PERCENTUALCOBERTURA");
                  AnyError = 1;
                  GX_FocusControl = edtPercentualCobertura_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A43PercentualCobertura = 0;
                  n43PercentualCobertura = false;
                  AssignAttri("", false, "A43PercentualCobertura", StringUtil.LTrimStr( A43PercentualCobertura, 18, 4));
               }
               else
               {
                  A43PercentualCobertura = context.localUtil.CToN( cgiGet( edtPercentualCobertura_Internalname), ",", ".");
                  n43PercentualCobertura = false;
                  AssignAttri("", false, "A43PercentualCobertura", StringUtil.LTrimStr( A43PercentualCobertura, 18, 4));
               }
               n43PercentualCobertura = ((Convert.ToDecimal(0)==A43PercentualCobertura) ? true : false);
               A44PacienteUnesp = cgiGet( edtPacienteUnesp_Internalname);
               n44PacienteUnesp = false;
               AssignAttri("", false, "A44PacienteUnesp", A44PacienteUnesp);
               n44PacienteUnesp = (String.IsNullOrEmpty(StringUtil.RTrim( A44PacienteUnesp)) ? true : false);
               A45RegistroUnesp = cgiGet( edtRegistroUnesp_Internalname);
               n45RegistroUnesp = false;
               AssignAttri("", false, "A45RegistroUnesp", A45RegistroUnesp);
               n45RegistroUnesp = (String.IsNullOrEmpty(StringUtil.RTrim( A45RegistroUnesp)) ? true : false);
               A46RelatoObito = cgiGet( edtRelatoObito_Internalname);
               n46RelatoObito = false;
               AssignAttri("", false, "A46RelatoObito", A46RelatoObito);
               n46RelatoObito = (String.IsNullOrEmpty(StringUtil.RTrim( A46RelatoObito)) ? true : false);
               A47ViciosHabituais = cgiGet( edtViciosHabituais_Internalname);
               n47ViciosHabituais = false;
               AssignAttri("", false, "A47ViciosHabituais", A47ViciosHabituais);
               n47ViciosHabituais = (String.IsNullOrEmpty(StringUtil.RTrim( A47ViciosHabituais)) ? true : false);
               A48ViciosEspecificar = cgiGet( edtViciosEspecificar_Internalname);
               n48ViciosEspecificar = false;
               AssignAttri("", false, "A48ViciosEspecificar", A48ViciosEspecificar);
               n48ViciosEspecificar = (String.IsNullOrEmpty(StringUtil.RTrim( A48ViciosEspecificar)) ? true : false);
               A49DoencasConhecidas = cgiGet( edtDoencasConhecidas_Internalname);
               n49DoencasConhecidas = false;
               AssignAttri("", false, "A49DoencasConhecidas", A49DoencasConhecidas);
               n49DoencasConhecidas = (String.IsNullOrEmpty(StringUtil.RTrim( A49DoencasConhecidas)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTaxaCapelaAux_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTaxaCapelaAux_Internalname), ",", ".") > 9999999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAXACAPELAAUX");
                  AnyError = 1;
                  GX_FocusControl = edtTaxaCapelaAux_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A50TaxaCapelaAux = 0;
                  n50TaxaCapelaAux = false;
                  AssignAttri("", false, "A50TaxaCapelaAux", StringUtil.LTrimStr( A50TaxaCapelaAux, 18, 4));
               }
               else
               {
                  A50TaxaCapelaAux = context.localUtil.CToN( cgiGet( edtTaxaCapelaAux_Internalname), ",", ".");
                  n50TaxaCapelaAux = false;
                  AssignAttri("", false, "A50TaxaCapelaAux", StringUtil.LTrimStr( A50TaxaCapelaAux, 18, 4));
               }
               n50TaxaCapelaAux = ((Convert.ToDecimal(0)==A50TaxaCapelaAux) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTaxaSepultamento_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTaxaSepultamento_Internalname), ",", ".") > 9999999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TAXASEPULTAMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtTaxaSepultamento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A51TaxaSepultamento = 0;
                  n51TaxaSepultamento = false;
                  AssignAttri("", false, "A51TaxaSepultamento", StringUtil.LTrimStr( A51TaxaSepultamento, 18, 4));
               }
               else
               {
                  A51TaxaSepultamento = context.localUtil.CToN( cgiGet( edtTaxaSepultamento_Internalname), ",", ".");
                  n51TaxaSepultamento = false;
                  AssignAttri("", false, "A51TaxaSepultamento", StringUtil.LTrimStr( A51TaxaSepultamento, 18, 4));
               }
               n51TaxaSepultamento = ((Convert.ToDecimal(0)==A51TaxaSepultamento) ? true : false);
               A52Matricula = cgiGet( edtMatricula_Internalname);
               n52Matricula = false;
               AssignAttri("", false, "A52Matricula", A52Matricula);
               n52Matricula = (String.IsNullOrEmpty(StringUtil.RTrim( A52Matricula)) ? true : false);
               A53UsouCremacao = cgiGet( edtUsouCremacao_Internalname);
               n53UsouCremacao = false;
               AssignAttri("", false, "A53UsouCremacao", A53UsouCremacao);
               n53UsouCremacao = (String.IsNullOrEmpty(StringUtil.RTrim( A53UsouCremacao)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSeq_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSeq_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SEQ");
                  AnyError = 1;
                  GX_FocusControl = edtSeq_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A54Seq = 0;
                  n54Seq = false;
                  AssignAttri("", false, "A54Seq", StringUtil.LTrimStr( (decimal)(A54Seq), 9, 0));
               }
               else
               {
                  A54Seq = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n54Seq = false;
                  AssignAttri("", false, "A54Seq", StringUtil.LTrimStr( (decimal)(A54Seq), 9, 0));
               }
               n54Seq = ((0==A54Seq) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Obitos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1Inscricao != Z1Inscricao ) || ( StringUtil.StrCmp(A2Nome, Z2Nome) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("obitos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1Inscricao = (int)(Math.Round(NumberUtil.Val( GetPar( "Inscricao"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
                  A2Nome = GetPar( "Nome");
                  AssignAttri("", false, "A2Nome", A2Nome);
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "INSCRICAO");
                        AnyError = 1;
                        GX_FocusControl = edtInscricao_Internalname;
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
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwobitos.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z3Grupo = T00013_A3Grupo[0];
               Z4Referencia = T00013_A4Referencia[0];
               Z5Numero = T00013_A5Numero[0];
               Z6Valor = T00013_A6Valor[0];
               Z7Vencimento = T00013_A7Vencimento[0];
               Z8Nascimento = T00013_A8Nascimento[0];
               Z9Falecimento = T00013_A9Falecimento[0];
               Z10NumeroObito = T00013_A10NumeroObito[0];
               Z11NFNumero = T00013_A11NFNumero[0];
               Z12NFValor = T00013_A12NFValor[0];
               Z13Funeraria = T00013_A13Funeraria[0];
               Z14Observacao = T00013_A14Observacao[0];
               Z15Parentesco = T00013_A15Parentesco[0];
               Z16Cemiterio = T00013_A16Cemiterio[0];
               Z17Jazigo = T00013_A17Jazigo[0];
               Z18Quadra = T00013_A18Quadra[0];
               Z19Lote = T00013_A19Lote[0];
               Z20SeqDependente = T00013_A20SeqDependente[0];
               Z21Capela = T00013_A21Capela[0];
               Z22EnderecoFalecido = T00013_A22EnderecoFalecido[0];
               Z23horafalecimento = T00013_A23horafalecimento[0];
               Z24CidadeFalecimento = T00013_A24CidadeFalecimento[0];
               Z25LocalFalecimento = T00013_A25LocalFalecimento[0];
               Z26HoraSepultamento = T00013_A26HoraSepultamento[0];
               Z27DatasolicitacaoAux = T00013_A27DatasolicitacaoAux[0];
               Z28NomeContratanteAux = T00013_A28NomeContratanteAux[0];
               Z29EndContratanteAux = T00013_A29EndContratanteAux[0];
               Z30CidadeContratanteAux = T00013_A30CidadeContratanteAux[0];
               Z31RGContratanteAux = T00013_A31RGContratanteAux[0];
               Z32CPFContratanteAux = T00013_A32CPFContratanteAux[0];
               Z33EstCivilContratanteAux = T00013_A33EstCivilContratanteAux[0];
               Z34DataInsert = T00013_A34DataInsert[0];
               Z35UsuInsert = T00013_A35UsuInsert[0];
               Z36DataUpdate = T00013_A36DataUpdate[0];
               Z37UsuUpdate = T00013_A37UsuUpdate[0];
               Z38NumControleAux = T00013_A38NumControleAux[0];
               Z39ValorAux = T00013_A39ValorAux[0];
               Z40DataPagtoAux = T00013_A40DataPagtoAux[0];
               Z41ObservacaoAux = T00013_A41ObservacaoAux[0];
               Z42EmCarencia = T00013_A42EmCarencia[0];
               Z43PercentualCobertura = T00013_A43PercentualCobertura[0];
               Z44PacienteUnesp = T00013_A44PacienteUnesp[0];
               Z45RegistroUnesp = T00013_A45RegistroUnesp[0];
               Z47ViciosHabituais = T00013_A47ViciosHabituais[0];
               Z48ViciosEspecificar = T00013_A48ViciosEspecificar[0];
               Z49DoencasConhecidas = T00013_A49DoencasConhecidas[0];
               Z50TaxaCapelaAux = T00013_A50TaxaCapelaAux[0];
               Z51TaxaSepultamento = T00013_A51TaxaSepultamento[0];
               Z52Matricula = T00013_A52Matricula[0];
               Z53UsouCremacao = T00013_A53UsouCremacao[0];
               Z54Seq = T00013_A54Seq[0];
            }
            else
            {
               Z3Grupo = A3Grupo;
               Z4Referencia = A4Referencia;
               Z5Numero = A5Numero;
               Z6Valor = A6Valor;
               Z7Vencimento = A7Vencimento;
               Z8Nascimento = A8Nascimento;
               Z9Falecimento = A9Falecimento;
               Z10NumeroObito = A10NumeroObito;
               Z11NFNumero = A11NFNumero;
               Z12NFValor = A12NFValor;
               Z13Funeraria = A13Funeraria;
               Z14Observacao = A14Observacao;
               Z15Parentesco = A15Parentesco;
               Z16Cemiterio = A16Cemiterio;
               Z17Jazigo = A17Jazigo;
               Z18Quadra = A18Quadra;
               Z19Lote = A19Lote;
               Z20SeqDependente = A20SeqDependente;
               Z21Capela = A21Capela;
               Z22EnderecoFalecido = A22EnderecoFalecido;
               Z23horafalecimento = A23horafalecimento;
               Z24CidadeFalecimento = A24CidadeFalecimento;
               Z25LocalFalecimento = A25LocalFalecimento;
               Z26HoraSepultamento = A26HoraSepultamento;
               Z27DatasolicitacaoAux = A27DatasolicitacaoAux;
               Z28NomeContratanteAux = A28NomeContratanteAux;
               Z29EndContratanteAux = A29EndContratanteAux;
               Z30CidadeContratanteAux = A30CidadeContratanteAux;
               Z31RGContratanteAux = A31RGContratanteAux;
               Z32CPFContratanteAux = A32CPFContratanteAux;
               Z33EstCivilContratanteAux = A33EstCivilContratanteAux;
               Z34DataInsert = A34DataInsert;
               Z35UsuInsert = A35UsuInsert;
               Z36DataUpdate = A36DataUpdate;
               Z37UsuUpdate = A37UsuUpdate;
               Z38NumControleAux = A38NumControleAux;
               Z39ValorAux = A39ValorAux;
               Z40DataPagtoAux = A40DataPagtoAux;
               Z41ObservacaoAux = A41ObservacaoAux;
               Z42EmCarencia = A42EmCarencia;
               Z43PercentualCobertura = A43PercentualCobertura;
               Z44PacienteUnesp = A44PacienteUnesp;
               Z45RegistroUnesp = A45RegistroUnesp;
               Z47ViciosHabituais = A47ViciosHabituais;
               Z48ViciosEspecificar = A48ViciosEspecificar;
               Z49DoencasConhecidas = A49DoencasConhecidas;
               Z50TaxaCapelaAux = A50TaxaCapelaAux;
               Z51TaxaSepultamento = A51TaxaSepultamento;
               Z52Matricula = A52Matricula;
               Z53UsouCremacao = A53UsouCremacao;
               Z54Seq = A54Seq;
            }
         }
         if ( GX_JID == -14 )
         {
            Z1Inscricao = A1Inscricao;
            Z2Nome = A2Nome;
            Z3Grupo = A3Grupo;
            Z4Referencia = A4Referencia;
            Z5Numero = A5Numero;
            Z6Valor = A6Valor;
            Z7Vencimento = A7Vencimento;
            Z8Nascimento = A8Nascimento;
            Z9Falecimento = A9Falecimento;
            Z10NumeroObito = A10NumeroObito;
            Z11NFNumero = A11NFNumero;
            Z12NFValor = A12NFValor;
            Z13Funeraria = A13Funeraria;
            Z14Observacao = A14Observacao;
            Z15Parentesco = A15Parentesco;
            Z16Cemiterio = A16Cemiterio;
            Z17Jazigo = A17Jazigo;
            Z18Quadra = A18Quadra;
            Z19Lote = A19Lote;
            Z20SeqDependente = A20SeqDependente;
            Z21Capela = A21Capela;
            Z22EnderecoFalecido = A22EnderecoFalecido;
            Z23horafalecimento = A23horafalecimento;
            Z24CidadeFalecimento = A24CidadeFalecimento;
            Z25LocalFalecimento = A25LocalFalecimento;
            Z26HoraSepultamento = A26HoraSepultamento;
            Z27DatasolicitacaoAux = A27DatasolicitacaoAux;
            Z28NomeContratanteAux = A28NomeContratanteAux;
            Z29EndContratanteAux = A29EndContratanteAux;
            Z30CidadeContratanteAux = A30CidadeContratanteAux;
            Z31RGContratanteAux = A31RGContratanteAux;
            Z32CPFContratanteAux = A32CPFContratanteAux;
            Z33EstCivilContratanteAux = A33EstCivilContratanteAux;
            Z34DataInsert = A34DataInsert;
            Z35UsuInsert = A35UsuInsert;
            Z36DataUpdate = A36DataUpdate;
            Z37UsuUpdate = A37UsuUpdate;
            Z38NumControleAux = A38NumControleAux;
            Z39ValorAux = A39ValorAux;
            Z40DataPagtoAux = A40DataPagtoAux;
            Z41ObservacaoAux = A41ObservacaoAux;
            Z42EmCarencia = A42EmCarencia;
            Z43PercentualCobertura = A43PercentualCobertura;
            Z44PacienteUnesp = A44PacienteUnesp;
            Z45RegistroUnesp = A45RegistroUnesp;
            Z46RelatoObito = A46RelatoObito;
            Z47ViciosHabituais = A47ViciosHabituais;
            Z48ViciosEspecificar = A48ViciosEspecificar;
            Z49DoencasConhecidas = A49DoencasConhecidas;
            Z50TaxaCapelaAux = A50TaxaCapelaAux;
            Z51TaxaSepultamento = A51TaxaSepultamento;
            Z52Matricula = A52Matricula;
            Z53UsouCremacao = A53UsouCremacao;
            Z54Seq = A54Seq;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7Inscricao) )
         {
            A1Inscricao = AV7Inscricao;
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
         }
         if ( ! (0==AV7Inscricao) )
         {
            edtInscricao_Enabled = 0;
            AssignProp("", false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         }
         else
         {
            edtInscricao_Enabled = 1;
            AssignProp("", false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7Inscricao) )
         {
            edtInscricao_Enabled = 0;
            AssignProp("", false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Nome)) )
         {
            A2Nome = AV8Nome;
            AssignAttri("", false, "A2Nome", A2Nome);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Nome)) )
         {
            edtNome_Enabled = 0;
            AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         }
         else
         {
            edtNome_Enabled = 1;
            AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Nome)) )
         {
            edtNome_Enabled = 0;
            AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV12Pgmname = "Obitos";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00014 */
         pr_datastore1.execute(2, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A3Grupo = T00014_A3Grupo[0];
            n3Grupo = T00014_n3Grupo[0];
            AssignAttri("", false, "A3Grupo", A3Grupo);
            A4Referencia = T00014_A4Referencia[0];
            n4Referencia = T00014_n4Referencia[0];
            AssignAttri("", false, "A4Referencia", A4Referencia);
            A5Numero = T00014_A5Numero[0];
            n5Numero = T00014_n5Numero[0];
            AssignAttri("", false, "A5Numero", StringUtil.LTrimStr( (decimal)(A5Numero), 9, 0));
            A6Valor = T00014_A6Valor[0];
            n6Valor = T00014_n6Valor[0];
            AssignAttri("", false, "A6Valor", StringUtil.LTrimStr( A6Valor, 18, 4));
            A7Vencimento = T00014_A7Vencimento[0];
            n7Vencimento = T00014_n7Vencimento[0];
            AssignAttri("", false, "A7Vencimento", context.localUtil.TToC( A7Vencimento, 10, 8, 0, 3, "/", ":", " "));
            A8Nascimento = T00014_A8Nascimento[0];
            n8Nascimento = T00014_n8Nascimento[0];
            AssignAttri("", false, "A8Nascimento", context.localUtil.TToC( A8Nascimento, 10, 8, 0, 3, "/", ":", " "));
            A9Falecimento = T00014_A9Falecimento[0];
            n9Falecimento = T00014_n9Falecimento[0];
            AssignAttri("", false, "A9Falecimento", context.localUtil.TToC( A9Falecimento, 10, 8, 0, 3, "/", ":", " "));
            A10NumeroObito = T00014_A10NumeroObito[0];
            n10NumeroObito = T00014_n10NumeroObito[0];
            AssignAttri("", false, "A10NumeroObito", A10NumeroObito);
            A11NFNumero = T00014_A11NFNumero[0];
            n11NFNumero = T00014_n11NFNumero[0];
            AssignAttri("", false, "A11NFNumero", A11NFNumero);
            A12NFValor = T00014_A12NFValor[0];
            n12NFValor = T00014_n12NFValor[0];
            AssignAttri("", false, "A12NFValor", StringUtil.LTrimStr( A12NFValor, 18, 4));
            A13Funeraria = T00014_A13Funeraria[0];
            n13Funeraria = T00014_n13Funeraria[0];
            AssignAttri("", false, "A13Funeraria", A13Funeraria);
            A14Observacao = T00014_A14Observacao[0];
            n14Observacao = T00014_n14Observacao[0];
            AssignAttri("", false, "A14Observacao", A14Observacao);
            A15Parentesco = T00014_A15Parentesco[0];
            n15Parentesco = T00014_n15Parentesco[0];
            AssignAttri("", false, "A15Parentesco", A15Parentesco);
            A16Cemiterio = T00014_A16Cemiterio[0];
            n16Cemiterio = T00014_n16Cemiterio[0];
            AssignAttri("", false, "A16Cemiterio", StringUtil.LTrimStr( (decimal)(A16Cemiterio), 9, 0));
            A17Jazigo = T00014_A17Jazigo[0];
            n17Jazigo = T00014_n17Jazigo[0];
            AssignAttri("", false, "A17Jazigo", StringUtil.LTrimStr( (decimal)(A17Jazigo), 9, 0));
            A18Quadra = T00014_A18Quadra[0];
            n18Quadra = T00014_n18Quadra[0];
            AssignAttri("", false, "A18Quadra", StringUtil.LTrimStr( (decimal)(A18Quadra), 9, 0));
            A19Lote = T00014_A19Lote[0];
            n19Lote = T00014_n19Lote[0];
            AssignAttri("", false, "A19Lote", StringUtil.LTrimStr( (decimal)(A19Lote), 9, 0));
            A20SeqDependente = T00014_A20SeqDependente[0];
            n20SeqDependente = T00014_n20SeqDependente[0];
            AssignAttri("", false, "A20SeqDependente", StringUtil.LTrimStr( (decimal)(A20SeqDependente), 9, 0));
            A21Capela = T00014_A21Capela[0];
            n21Capela = T00014_n21Capela[0];
            AssignAttri("", false, "A21Capela", StringUtil.LTrimStr( (decimal)(A21Capela), 9, 0));
            A22EnderecoFalecido = T00014_A22EnderecoFalecido[0];
            n22EnderecoFalecido = T00014_n22EnderecoFalecido[0];
            AssignAttri("", false, "A22EnderecoFalecido", A22EnderecoFalecido);
            A23horafalecimento = T00014_A23horafalecimento[0];
            n23horafalecimento = T00014_n23horafalecimento[0];
            AssignAttri("", false, "A23horafalecimento", A23horafalecimento);
            A24CidadeFalecimento = T00014_A24CidadeFalecimento[0];
            n24CidadeFalecimento = T00014_n24CidadeFalecimento[0];
            AssignAttri("", false, "A24CidadeFalecimento", StringUtil.LTrimStr( (decimal)(A24CidadeFalecimento), 9, 0));
            A25LocalFalecimento = T00014_A25LocalFalecimento[0];
            n25LocalFalecimento = T00014_n25LocalFalecimento[0];
            AssignAttri("", false, "A25LocalFalecimento", A25LocalFalecimento);
            A26HoraSepultamento = T00014_A26HoraSepultamento[0];
            n26HoraSepultamento = T00014_n26HoraSepultamento[0];
            AssignAttri("", false, "A26HoraSepultamento", A26HoraSepultamento);
            A27DatasolicitacaoAux = T00014_A27DatasolicitacaoAux[0];
            n27DatasolicitacaoAux = T00014_n27DatasolicitacaoAux[0];
            AssignAttri("", false, "A27DatasolicitacaoAux", context.localUtil.TToC( A27DatasolicitacaoAux, 10, 8, 0, 3, "/", ":", " "));
            A28NomeContratanteAux = T00014_A28NomeContratanteAux[0];
            n28NomeContratanteAux = T00014_n28NomeContratanteAux[0];
            AssignAttri("", false, "A28NomeContratanteAux", A28NomeContratanteAux);
            A29EndContratanteAux = T00014_A29EndContratanteAux[0];
            n29EndContratanteAux = T00014_n29EndContratanteAux[0];
            AssignAttri("", false, "A29EndContratanteAux", A29EndContratanteAux);
            A30CidadeContratanteAux = T00014_A30CidadeContratanteAux[0];
            n30CidadeContratanteAux = T00014_n30CidadeContratanteAux[0];
            AssignAttri("", false, "A30CidadeContratanteAux", StringUtil.LTrimStr( (decimal)(A30CidadeContratanteAux), 9, 0));
            A31RGContratanteAux = T00014_A31RGContratanteAux[0];
            n31RGContratanteAux = T00014_n31RGContratanteAux[0];
            AssignAttri("", false, "A31RGContratanteAux", A31RGContratanteAux);
            A32CPFContratanteAux = T00014_A32CPFContratanteAux[0];
            n32CPFContratanteAux = T00014_n32CPFContratanteAux[0];
            AssignAttri("", false, "A32CPFContratanteAux", A32CPFContratanteAux);
            A33EstCivilContratanteAux = T00014_A33EstCivilContratanteAux[0];
            n33EstCivilContratanteAux = T00014_n33EstCivilContratanteAux[0];
            AssignAttri("", false, "A33EstCivilContratanteAux", StringUtil.LTrimStr( (decimal)(A33EstCivilContratanteAux), 9, 0));
            A34DataInsert = T00014_A34DataInsert[0];
            n34DataInsert = T00014_n34DataInsert[0];
            AssignAttri("", false, "A34DataInsert", context.localUtil.TToC( A34DataInsert, 10, 8, 0, 3, "/", ":", " "));
            A35UsuInsert = T00014_A35UsuInsert[0];
            n35UsuInsert = T00014_n35UsuInsert[0];
            AssignAttri("", false, "A35UsuInsert", StringUtil.LTrimStr( (decimal)(A35UsuInsert), 9, 0));
            A36DataUpdate = T00014_A36DataUpdate[0];
            n36DataUpdate = T00014_n36DataUpdate[0];
            AssignAttri("", false, "A36DataUpdate", context.localUtil.TToC( A36DataUpdate, 10, 8, 0, 3, "/", ":", " "));
            A37UsuUpdate = T00014_A37UsuUpdate[0];
            n37UsuUpdate = T00014_n37UsuUpdate[0];
            AssignAttri("", false, "A37UsuUpdate", StringUtil.LTrimStr( (decimal)(A37UsuUpdate), 9, 0));
            A38NumControleAux = T00014_A38NumControleAux[0];
            n38NumControleAux = T00014_n38NumControleAux[0];
            AssignAttri("", false, "A38NumControleAux", StringUtil.LTrimStr( (decimal)(A38NumControleAux), 9, 0));
            A39ValorAux = T00014_A39ValorAux[0];
            n39ValorAux = T00014_n39ValorAux[0];
            AssignAttri("", false, "A39ValorAux", StringUtil.LTrimStr( A39ValorAux, 18, 4));
            A40DataPagtoAux = T00014_A40DataPagtoAux[0];
            n40DataPagtoAux = T00014_n40DataPagtoAux[0];
            AssignAttri("", false, "A40DataPagtoAux", context.localUtil.TToC( A40DataPagtoAux, 10, 8, 0, 3, "/", ":", " "));
            A41ObservacaoAux = T00014_A41ObservacaoAux[0];
            n41ObservacaoAux = T00014_n41ObservacaoAux[0];
            AssignAttri("", false, "A41ObservacaoAux", A41ObservacaoAux);
            A42EmCarencia = T00014_A42EmCarencia[0];
            n42EmCarencia = T00014_n42EmCarencia[0];
            AssignAttri("", false, "A42EmCarencia", A42EmCarencia);
            A43PercentualCobertura = T00014_A43PercentualCobertura[0];
            n43PercentualCobertura = T00014_n43PercentualCobertura[0];
            AssignAttri("", false, "A43PercentualCobertura", StringUtil.LTrimStr( A43PercentualCobertura, 18, 4));
            A44PacienteUnesp = T00014_A44PacienteUnesp[0];
            n44PacienteUnesp = T00014_n44PacienteUnesp[0];
            AssignAttri("", false, "A44PacienteUnesp", A44PacienteUnesp);
            A45RegistroUnesp = T00014_A45RegistroUnesp[0];
            n45RegistroUnesp = T00014_n45RegistroUnesp[0];
            AssignAttri("", false, "A45RegistroUnesp", A45RegistroUnesp);
            A46RelatoObito = T00014_A46RelatoObito[0];
            n46RelatoObito = T00014_n46RelatoObito[0];
            AssignAttri("", false, "A46RelatoObito", A46RelatoObito);
            A47ViciosHabituais = T00014_A47ViciosHabituais[0];
            n47ViciosHabituais = T00014_n47ViciosHabituais[0];
            AssignAttri("", false, "A47ViciosHabituais", A47ViciosHabituais);
            A48ViciosEspecificar = T00014_A48ViciosEspecificar[0];
            n48ViciosEspecificar = T00014_n48ViciosEspecificar[0];
            AssignAttri("", false, "A48ViciosEspecificar", A48ViciosEspecificar);
            A49DoencasConhecidas = T00014_A49DoencasConhecidas[0];
            n49DoencasConhecidas = T00014_n49DoencasConhecidas[0];
            AssignAttri("", false, "A49DoencasConhecidas", A49DoencasConhecidas);
            A50TaxaCapelaAux = T00014_A50TaxaCapelaAux[0];
            n50TaxaCapelaAux = T00014_n50TaxaCapelaAux[0];
            AssignAttri("", false, "A50TaxaCapelaAux", StringUtil.LTrimStr( A50TaxaCapelaAux, 18, 4));
            A51TaxaSepultamento = T00014_A51TaxaSepultamento[0];
            n51TaxaSepultamento = T00014_n51TaxaSepultamento[0];
            AssignAttri("", false, "A51TaxaSepultamento", StringUtil.LTrimStr( A51TaxaSepultamento, 18, 4));
            A52Matricula = T00014_A52Matricula[0];
            n52Matricula = T00014_n52Matricula[0];
            AssignAttri("", false, "A52Matricula", A52Matricula);
            A53UsouCremacao = T00014_A53UsouCremacao[0];
            n53UsouCremacao = T00014_n53UsouCremacao[0];
            AssignAttri("", false, "A53UsouCremacao", A53UsouCremacao);
            A54Seq = T00014_A54Seq[0];
            n54Seq = T00014_n54Seq[0];
            AssignAttri("", false, "A54Seq", StringUtil.LTrimStr( (decimal)(A54Seq), 9, 0));
            ZM011( -14) ;
         }
         pr_datastore1.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV12Pgmname = "Obitos";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV12Pgmname = "Obitos";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         if ( ! ( (DateTime.MinValue==A7Vencimento) || ( A7Vencimento >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Vencimento fora do intervalo", "OutOfRange", 1, "VENCIMENTO");
            AnyError = 1;
            GX_FocusControl = edtVencimento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A8Nascimento) || ( A8Nascimento >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Nascimento fora do intervalo", "OutOfRange", 1, "NASCIMENTO");
            AnyError = 1;
            GX_FocusControl = edtNascimento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A9Falecimento) || ( A9Falecimento >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Falecimento fora do intervalo", "OutOfRange", 1, "FALECIMENTO");
            AnyError = 1;
            GX_FocusControl = edtFalecimento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A27DatasolicitacaoAux) || ( A27DatasolicitacaoAux >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Datasolicitacao Aux fora do intervalo", "OutOfRange", 1, "DATASOLICITACAOAUX");
            AnyError = 1;
            GX_FocusControl = edtDatasolicitacaoAux_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A34DataInsert) || ( A34DataInsert >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Data Insert fora do intervalo", "OutOfRange", 1, "DATAINSERT");
            AnyError = 1;
            GX_FocusControl = edtDataInsert_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A36DataUpdate) || ( A36DataUpdate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Data Update fora do intervalo", "OutOfRange", 1, "DATAUPDATE");
            AnyError = 1;
            GX_FocusControl = edtDataUpdate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A40DataPagtoAux) || ( A40DataPagtoAux >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Data Pagto Aux fora do intervalo", "OutOfRange", 1, "DATAPAGTOAUX");
            AnyError = 1;
            GX_FocusControl = edtDataPagtoAux_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00015 */
         pr_datastore1.execute(3, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_datastore1.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_datastore1.execute(1, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(1) != 101) )
         {
            ZM011( 14) ;
            RcdFound1 = 1;
            A1Inscricao = T00013_A1Inscricao[0];
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = T00013_A2Nome[0];
            AssignAttri("", false, "A2Nome", A2Nome);
            A3Grupo = T00013_A3Grupo[0];
            n3Grupo = T00013_n3Grupo[0];
            AssignAttri("", false, "A3Grupo", A3Grupo);
            A4Referencia = T00013_A4Referencia[0];
            n4Referencia = T00013_n4Referencia[0];
            AssignAttri("", false, "A4Referencia", A4Referencia);
            A5Numero = T00013_A5Numero[0];
            n5Numero = T00013_n5Numero[0];
            AssignAttri("", false, "A5Numero", StringUtil.LTrimStr( (decimal)(A5Numero), 9, 0));
            A6Valor = T00013_A6Valor[0];
            n6Valor = T00013_n6Valor[0];
            AssignAttri("", false, "A6Valor", StringUtil.LTrimStr( A6Valor, 18, 4));
            A7Vencimento = T00013_A7Vencimento[0];
            n7Vencimento = T00013_n7Vencimento[0];
            AssignAttri("", false, "A7Vencimento", context.localUtil.TToC( A7Vencimento, 10, 8, 0, 3, "/", ":", " "));
            A8Nascimento = T00013_A8Nascimento[0];
            n8Nascimento = T00013_n8Nascimento[0];
            AssignAttri("", false, "A8Nascimento", context.localUtil.TToC( A8Nascimento, 10, 8, 0, 3, "/", ":", " "));
            A9Falecimento = T00013_A9Falecimento[0];
            n9Falecimento = T00013_n9Falecimento[0];
            AssignAttri("", false, "A9Falecimento", context.localUtil.TToC( A9Falecimento, 10, 8, 0, 3, "/", ":", " "));
            A10NumeroObito = T00013_A10NumeroObito[0];
            n10NumeroObito = T00013_n10NumeroObito[0];
            AssignAttri("", false, "A10NumeroObito", A10NumeroObito);
            A11NFNumero = T00013_A11NFNumero[0];
            n11NFNumero = T00013_n11NFNumero[0];
            AssignAttri("", false, "A11NFNumero", A11NFNumero);
            A12NFValor = T00013_A12NFValor[0];
            n12NFValor = T00013_n12NFValor[0];
            AssignAttri("", false, "A12NFValor", StringUtil.LTrimStr( A12NFValor, 18, 4));
            A13Funeraria = T00013_A13Funeraria[0];
            n13Funeraria = T00013_n13Funeraria[0];
            AssignAttri("", false, "A13Funeraria", A13Funeraria);
            A14Observacao = T00013_A14Observacao[0];
            n14Observacao = T00013_n14Observacao[0];
            AssignAttri("", false, "A14Observacao", A14Observacao);
            A15Parentesco = T00013_A15Parentesco[0];
            n15Parentesco = T00013_n15Parentesco[0];
            AssignAttri("", false, "A15Parentesco", A15Parentesco);
            A16Cemiterio = T00013_A16Cemiterio[0];
            n16Cemiterio = T00013_n16Cemiterio[0];
            AssignAttri("", false, "A16Cemiterio", StringUtil.LTrimStr( (decimal)(A16Cemiterio), 9, 0));
            A17Jazigo = T00013_A17Jazigo[0];
            n17Jazigo = T00013_n17Jazigo[0];
            AssignAttri("", false, "A17Jazigo", StringUtil.LTrimStr( (decimal)(A17Jazigo), 9, 0));
            A18Quadra = T00013_A18Quadra[0];
            n18Quadra = T00013_n18Quadra[0];
            AssignAttri("", false, "A18Quadra", StringUtil.LTrimStr( (decimal)(A18Quadra), 9, 0));
            A19Lote = T00013_A19Lote[0];
            n19Lote = T00013_n19Lote[0];
            AssignAttri("", false, "A19Lote", StringUtil.LTrimStr( (decimal)(A19Lote), 9, 0));
            A20SeqDependente = T00013_A20SeqDependente[0];
            n20SeqDependente = T00013_n20SeqDependente[0];
            AssignAttri("", false, "A20SeqDependente", StringUtil.LTrimStr( (decimal)(A20SeqDependente), 9, 0));
            A21Capela = T00013_A21Capela[0];
            n21Capela = T00013_n21Capela[0];
            AssignAttri("", false, "A21Capela", StringUtil.LTrimStr( (decimal)(A21Capela), 9, 0));
            A22EnderecoFalecido = T00013_A22EnderecoFalecido[0];
            n22EnderecoFalecido = T00013_n22EnderecoFalecido[0];
            AssignAttri("", false, "A22EnderecoFalecido", A22EnderecoFalecido);
            A23horafalecimento = T00013_A23horafalecimento[0];
            n23horafalecimento = T00013_n23horafalecimento[0];
            AssignAttri("", false, "A23horafalecimento", A23horafalecimento);
            A24CidadeFalecimento = T00013_A24CidadeFalecimento[0];
            n24CidadeFalecimento = T00013_n24CidadeFalecimento[0];
            AssignAttri("", false, "A24CidadeFalecimento", StringUtil.LTrimStr( (decimal)(A24CidadeFalecimento), 9, 0));
            A25LocalFalecimento = T00013_A25LocalFalecimento[0];
            n25LocalFalecimento = T00013_n25LocalFalecimento[0];
            AssignAttri("", false, "A25LocalFalecimento", A25LocalFalecimento);
            A26HoraSepultamento = T00013_A26HoraSepultamento[0];
            n26HoraSepultamento = T00013_n26HoraSepultamento[0];
            AssignAttri("", false, "A26HoraSepultamento", A26HoraSepultamento);
            A27DatasolicitacaoAux = T00013_A27DatasolicitacaoAux[0];
            n27DatasolicitacaoAux = T00013_n27DatasolicitacaoAux[0];
            AssignAttri("", false, "A27DatasolicitacaoAux", context.localUtil.TToC( A27DatasolicitacaoAux, 10, 8, 0, 3, "/", ":", " "));
            A28NomeContratanteAux = T00013_A28NomeContratanteAux[0];
            n28NomeContratanteAux = T00013_n28NomeContratanteAux[0];
            AssignAttri("", false, "A28NomeContratanteAux", A28NomeContratanteAux);
            A29EndContratanteAux = T00013_A29EndContratanteAux[0];
            n29EndContratanteAux = T00013_n29EndContratanteAux[0];
            AssignAttri("", false, "A29EndContratanteAux", A29EndContratanteAux);
            A30CidadeContratanteAux = T00013_A30CidadeContratanteAux[0];
            n30CidadeContratanteAux = T00013_n30CidadeContratanteAux[0];
            AssignAttri("", false, "A30CidadeContratanteAux", StringUtil.LTrimStr( (decimal)(A30CidadeContratanteAux), 9, 0));
            A31RGContratanteAux = T00013_A31RGContratanteAux[0];
            n31RGContratanteAux = T00013_n31RGContratanteAux[0];
            AssignAttri("", false, "A31RGContratanteAux", A31RGContratanteAux);
            A32CPFContratanteAux = T00013_A32CPFContratanteAux[0];
            n32CPFContratanteAux = T00013_n32CPFContratanteAux[0];
            AssignAttri("", false, "A32CPFContratanteAux", A32CPFContratanteAux);
            A33EstCivilContratanteAux = T00013_A33EstCivilContratanteAux[0];
            n33EstCivilContratanteAux = T00013_n33EstCivilContratanteAux[0];
            AssignAttri("", false, "A33EstCivilContratanteAux", StringUtil.LTrimStr( (decimal)(A33EstCivilContratanteAux), 9, 0));
            A34DataInsert = T00013_A34DataInsert[0];
            n34DataInsert = T00013_n34DataInsert[0];
            AssignAttri("", false, "A34DataInsert", context.localUtil.TToC( A34DataInsert, 10, 8, 0, 3, "/", ":", " "));
            A35UsuInsert = T00013_A35UsuInsert[0];
            n35UsuInsert = T00013_n35UsuInsert[0];
            AssignAttri("", false, "A35UsuInsert", StringUtil.LTrimStr( (decimal)(A35UsuInsert), 9, 0));
            A36DataUpdate = T00013_A36DataUpdate[0];
            n36DataUpdate = T00013_n36DataUpdate[0];
            AssignAttri("", false, "A36DataUpdate", context.localUtil.TToC( A36DataUpdate, 10, 8, 0, 3, "/", ":", " "));
            A37UsuUpdate = T00013_A37UsuUpdate[0];
            n37UsuUpdate = T00013_n37UsuUpdate[0];
            AssignAttri("", false, "A37UsuUpdate", StringUtil.LTrimStr( (decimal)(A37UsuUpdate), 9, 0));
            A38NumControleAux = T00013_A38NumControleAux[0];
            n38NumControleAux = T00013_n38NumControleAux[0];
            AssignAttri("", false, "A38NumControleAux", StringUtil.LTrimStr( (decimal)(A38NumControleAux), 9, 0));
            A39ValorAux = T00013_A39ValorAux[0];
            n39ValorAux = T00013_n39ValorAux[0];
            AssignAttri("", false, "A39ValorAux", StringUtil.LTrimStr( A39ValorAux, 18, 4));
            A40DataPagtoAux = T00013_A40DataPagtoAux[0];
            n40DataPagtoAux = T00013_n40DataPagtoAux[0];
            AssignAttri("", false, "A40DataPagtoAux", context.localUtil.TToC( A40DataPagtoAux, 10, 8, 0, 3, "/", ":", " "));
            A41ObservacaoAux = T00013_A41ObservacaoAux[0];
            n41ObservacaoAux = T00013_n41ObservacaoAux[0];
            AssignAttri("", false, "A41ObservacaoAux", A41ObservacaoAux);
            A42EmCarencia = T00013_A42EmCarencia[0];
            n42EmCarencia = T00013_n42EmCarencia[0];
            AssignAttri("", false, "A42EmCarencia", A42EmCarencia);
            A43PercentualCobertura = T00013_A43PercentualCobertura[0];
            n43PercentualCobertura = T00013_n43PercentualCobertura[0];
            AssignAttri("", false, "A43PercentualCobertura", StringUtil.LTrimStr( A43PercentualCobertura, 18, 4));
            A44PacienteUnesp = T00013_A44PacienteUnesp[0];
            n44PacienteUnesp = T00013_n44PacienteUnesp[0];
            AssignAttri("", false, "A44PacienteUnesp", A44PacienteUnesp);
            A45RegistroUnesp = T00013_A45RegistroUnesp[0];
            n45RegistroUnesp = T00013_n45RegistroUnesp[0];
            AssignAttri("", false, "A45RegistroUnesp", A45RegistroUnesp);
            A46RelatoObito = T00013_A46RelatoObito[0];
            n46RelatoObito = T00013_n46RelatoObito[0];
            AssignAttri("", false, "A46RelatoObito", A46RelatoObito);
            A47ViciosHabituais = T00013_A47ViciosHabituais[0];
            n47ViciosHabituais = T00013_n47ViciosHabituais[0];
            AssignAttri("", false, "A47ViciosHabituais", A47ViciosHabituais);
            A48ViciosEspecificar = T00013_A48ViciosEspecificar[0];
            n48ViciosEspecificar = T00013_n48ViciosEspecificar[0];
            AssignAttri("", false, "A48ViciosEspecificar", A48ViciosEspecificar);
            A49DoencasConhecidas = T00013_A49DoencasConhecidas[0];
            n49DoencasConhecidas = T00013_n49DoencasConhecidas[0];
            AssignAttri("", false, "A49DoencasConhecidas", A49DoencasConhecidas);
            A50TaxaCapelaAux = T00013_A50TaxaCapelaAux[0];
            n50TaxaCapelaAux = T00013_n50TaxaCapelaAux[0];
            AssignAttri("", false, "A50TaxaCapelaAux", StringUtil.LTrimStr( A50TaxaCapelaAux, 18, 4));
            A51TaxaSepultamento = T00013_A51TaxaSepultamento[0];
            n51TaxaSepultamento = T00013_n51TaxaSepultamento[0];
            AssignAttri("", false, "A51TaxaSepultamento", StringUtil.LTrimStr( A51TaxaSepultamento, 18, 4));
            A52Matricula = T00013_A52Matricula[0];
            n52Matricula = T00013_n52Matricula[0];
            AssignAttri("", false, "A52Matricula", A52Matricula);
            A53UsouCremacao = T00013_A53UsouCremacao[0];
            n53UsouCremacao = T00013_n53UsouCremacao[0];
            AssignAttri("", false, "A53UsouCremacao", A53UsouCremacao);
            A54Seq = T00013_A54Seq[0];
            n54Seq = T00013_n54Seq[0];
            AssignAttri("", false, "A54Seq", StringUtil.LTrimStr( (decimal)(A54Seq), 9, 0));
            Z1Inscricao = A1Inscricao;
            Z2Nome = A2Nome;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00016 */
         pr_datastore1.execute(4, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(4) != 101) )
         {
            while ( (pr_datastore1.getStatus(4) != 101) && ( ( T00016_A1Inscricao[0] < A1Inscricao ) || ( T00016_A1Inscricao[0] == A1Inscricao ) && ( StringUtil.StrCmp(T00016_A2Nome[0], A2Nome) < 0 ) ) )
            {
               pr_datastore1.readNext(4);
            }
            if ( (pr_datastore1.getStatus(4) != 101) && ( ( T00016_A1Inscricao[0] > A1Inscricao ) || ( T00016_A1Inscricao[0] == A1Inscricao ) && ( StringUtil.StrCmp(T00016_A2Nome[0], A2Nome) > 0 ) ) )
            {
               A1Inscricao = T00016_A1Inscricao[0];
               AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
               A2Nome = T00016_A2Nome[0];
               AssignAttri("", false, "A2Nome", A2Nome);
               RcdFound1 = 1;
            }
         }
         pr_datastore1.close(4);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00017 */
         pr_datastore1.execute(5, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(5) != 101) )
         {
            while ( (pr_datastore1.getStatus(5) != 101) && ( ( T00017_A1Inscricao[0] > A1Inscricao ) || ( T00017_A1Inscricao[0] == A1Inscricao ) && ( StringUtil.StrCmp(T00017_A2Nome[0], A2Nome) > 0 ) ) )
            {
               pr_datastore1.readNext(5);
            }
            if ( (pr_datastore1.getStatus(5) != 101) && ( ( T00017_A1Inscricao[0] < A1Inscricao ) || ( T00017_A1Inscricao[0] == A1Inscricao ) && ( StringUtil.StrCmp(T00017_A2Nome[0], A2Nome) < 0 ) ) )
            {
               A1Inscricao = T00017_A1Inscricao[0];
               AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
               A2Nome = T00017_A2Nome[0];
               AssignAttri("", false, "A2Nome", A2Nome);
               RcdFound1 = 1;
            }
         }
         pr_datastore1.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtInscricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( ( A1Inscricao != Z1Inscricao ) || ( StringUtil.StrCmp(A2Nome, Z2Nome) != 0 ) )
               {
                  A1Inscricao = Z1Inscricao;
                  AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
                  A2Nome = Z2Nome;
                  AssignAttri("", false, "A2Nome", A2Nome);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INSCRICAO");
                  AnyError = 1;
                  GX_FocusControl = edtInscricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInscricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtInscricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A1Inscricao != Z1Inscricao ) || ( StringUtil.StrCmp(A2Nome, Z2Nome) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtInscricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INSCRICAO");
                     AnyError = 1;
                     GX_FocusControl = edtInscricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtInscricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( ( A1Inscricao != Z1Inscricao ) || ( StringUtil.StrCmp(A2Nome, Z2Nome) != 0 ) )
         {
            A1Inscricao = Z1Inscricao;
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = Z2Nome;
            AssignAttri("", false, "A2Nome", A2Nome);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INSCRICAO");
            AnyError = 1;
            GX_FocusControl = edtInscricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInscricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_datastore1.execute(0, new Object[] {A1Inscricao, A2Nome});
            if ( (pr_datastore1.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Obitos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_datastore1.getStatus(0) == 101) || ( StringUtil.StrCmp(Z3Grupo, T00012_A3Grupo[0]) != 0 ) || ( StringUtil.StrCmp(Z4Referencia, T00012_A4Referencia[0]) != 0 ) || ( Z5Numero != T00012_A5Numero[0] ) || ( Z6Valor != T00012_A6Valor[0] ) || ( Z7Vencimento != T00012_A7Vencimento[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z8Nascimento != T00012_A8Nascimento[0] ) || ( Z9Falecimento != T00012_A9Falecimento[0] ) || ( StringUtil.StrCmp(Z10NumeroObito, T00012_A10NumeroObito[0]) != 0 ) || ( StringUtil.StrCmp(Z11NFNumero, T00012_A11NFNumero[0]) != 0 ) || ( Z12NFValor != T00012_A12NFValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z13Funeraria, T00012_A13Funeraria[0]) != 0 ) || ( StringUtil.StrCmp(Z14Observacao, T00012_A14Observacao[0]) != 0 ) || ( StringUtil.StrCmp(Z15Parentesco, T00012_A15Parentesco[0]) != 0 ) || ( Z16Cemiterio != T00012_A16Cemiterio[0] ) || ( Z17Jazigo != T00012_A17Jazigo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z18Quadra != T00012_A18Quadra[0] ) || ( Z19Lote != T00012_A19Lote[0] ) || ( Z20SeqDependente != T00012_A20SeqDependente[0] ) || ( Z21Capela != T00012_A21Capela[0] ) || ( StringUtil.StrCmp(Z22EnderecoFalecido, T00012_A22EnderecoFalecido[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z23horafalecimento, T00012_A23horafalecimento[0]) != 0 ) || ( Z24CidadeFalecimento != T00012_A24CidadeFalecimento[0] ) || ( StringUtil.StrCmp(Z25LocalFalecimento, T00012_A25LocalFalecimento[0]) != 0 ) || ( StringUtil.StrCmp(Z26HoraSepultamento, T00012_A26HoraSepultamento[0]) != 0 ) || ( Z27DatasolicitacaoAux != T00012_A27DatasolicitacaoAux[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z28NomeContratanteAux, T00012_A28NomeContratanteAux[0]) != 0 ) || ( StringUtil.StrCmp(Z29EndContratanteAux, T00012_A29EndContratanteAux[0]) != 0 ) || ( Z30CidadeContratanteAux != T00012_A30CidadeContratanteAux[0] ) || ( StringUtil.StrCmp(Z31RGContratanteAux, T00012_A31RGContratanteAux[0]) != 0 ) || ( StringUtil.StrCmp(Z32CPFContratanteAux, T00012_A32CPFContratanteAux[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z33EstCivilContratanteAux != T00012_A33EstCivilContratanteAux[0] ) || ( Z34DataInsert != T00012_A34DataInsert[0] ) || ( Z35UsuInsert != T00012_A35UsuInsert[0] ) || ( Z36DataUpdate != T00012_A36DataUpdate[0] ) || ( Z37UsuUpdate != T00012_A37UsuUpdate[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z38NumControleAux != T00012_A38NumControleAux[0] ) || ( Z39ValorAux != T00012_A39ValorAux[0] ) || ( Z40DataPagtoAux != T00012_A40DataPagtoAux[0] ) || ( StringUtil.StrCmp(Z41ObservacaoAux, T00012_A41ObservacaoAux[0]) != 0 ) || ( StringUtil.StrCmp(Z42EmCarencia, T00012_A42EmCarencia[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z43PercentualCobertura != T00012_A43PercentualCobertura[0] ) || ( StringUtil.StrCmp(Z44PacienteUnesp, T00012_A44PacienteUnesp[0]) != 0 ) || ( StringUtil.StrCmp(Z45RegistroUnesp, T00012_A45RegistroUnesp[0]) != 0 ) || ( StringUtil.StrCmp(Z47ViciosHabituais, T00012_A47ViciosHabituais[0]) != 0 ) || ( StringUtil.StrCmp(Z48ViciosEspecificar, T00012_A48ViciosEspecificar[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z49DoencasConhecidas, T00012_A49DoencasConhecidas[0]) != 0 ) || ( Z50TaxaCapelaAux != T00012_A50TaxaCapelaAux[0] ) || ( Z51TaxaSepultamento != T00012_A51TaxaSepultamento[0] ) || ( StringUtil.StrCmp(Z52Matricula, T00012_A52Matricula[0]) != 0 ) || ( StringUtil.StrCmp(Z53UsouCremacao, T00012_A53UsouCremacao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z54Seq != T00012_A54Seq[0] ) )
            {
               if ( StringUtil.StrCmp(Z3Grupo, T00012_A3Grupo[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Grupo");
                  GXUtil.WriteLogRaw("Old: ",Z3Grupo);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3Grupo[0]);
               }
               if ( StringUtil.StrCmp(Z4Referencia, T00012_A4Referencia[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Referencia");
                  GXUtil.WriteLogRaw("Old: ",Z4Referencia);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4Referencia[0]);
               }
               if ( Z5Numero != T00012_A5Numero[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Numero");
                  GXUtil.WriteLogRaw("Old: ",Z5Numero);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5Numero[0]);
               }
               if ( Z6Valor != T00012_A6Valor[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Valor");
                  GXUtil.WriteLogRaw("Old: ",Z6Valor);
                  GXUtil.WriteLogRaw("Current: ",T00012_A6Valor[0]);
               }
               if ( Z7Vencimento != T00012_A7Vencimento[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Vencimento");
                  GXUtil.WriteLogRaw("Old: ",Z7Vencimento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A7Vencimento[0]);
               }
               if ( Z8Nascimento != T00012_A8Nascimento[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Nascimento");
                  GXUtil.WriteLogRaw("Old: ",Z8Nascimento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A8Nascimento[0]);
               }
               if ( Z9Falecimento != T00012_A9Falecimento[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Falecimento");
                  GXUtil.WriteLogRaw("Old: ",Z9Falecimento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A9Falecimento[0]);
               }
               if ( StringUtil.StrCmp(Z10NumeroObito, T00012_A10NumeroObito[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"NumeroObito");
                  GXUtil.WriteLogRaw("Old: ",Z10NumeroObito);
                  GXUtil.WriteLogRaw("Current: ",T00012_A10NumeroObito[0]);
               }
               if ( StringUtil.StrCmp(Z11NFNumero, T00012_A11NFNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"NFNumero");
                  GXUtil.WriteLogRaw("Old: ",Z11NFNumero);
                  GXUtil.WriteLogRaw("Current: ",T00012_A11NFNumero[0]);
               }
               if ( Z12NFValor != T00012_A12NFValor[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"NFValor");
                  GXUtil.WriteLogRaw("Old: ",Z12NFValor);
                  GXUtil.WriteLogRaw("Current: ",T00012_A12NFValor[0]);
               }
               if ( StringUtil.StrCmp(Z13Funeraria, T00012_A13Funeraria[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Funeraria");
                  GXUtil.WriteLogRaw("Old: ",Z13Funeraria);
                  GXUtil.WriteLogRaw("Current: ",T00012_A13Funeraria[0]);
               }
               if ( StringUtil.StrCmp(Z14Observacao, T00012_A14Observacao[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Observacao");
                  GXUtil.WriteLogRaw("Old: ",Z14Observacao);
                  GXUtil.WriteLogRaw("Current: ",T00012_A14Observacao[0]);
               }
               if ( StringUtil.StrCmp(Z15Parentesco, T00012_A15Parentesco[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Parentesco");
                  GXUtil.WriteLogRaw("Old: ",Z15Parentesco);
                  GXUtil.WriteLogRaw("Current: ",T00012_A15Parentesco[0]);
               }
               if ( Z16Cemiterio != T00012_A16Cemiterio[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Cemiterio");
                  GXUtil.WriteLogRaw("Old: ",Z16Cemiterio);
                  GXUtil.WriteLogRaw("Current: ",T00012_A16Cemiterio[0]);
               }
               if ( Z17Jazigo != T00012_A17Jazigo[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Jazigo");
                  GXUtil.WriteLogRaw("Old: ",Z17Jazigo);
                  GXUtil.WriteLogRaw("Current: ",T00012_A17Jazigo[0]);
               }
               if ( Z18Quadra != T00012_A18Quadra[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Quadra");
                  GXUtil.WriteLogRaw("Old: ",Z18Quadra);
                  GXUtil.WriteLogRaw("Current: ",T00012_A18Quadra[0]);
               }
               if ( Z19Lote != T00012_A19Lote[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Lote");
                  GXUtil.WriteLogRaw("Old: ",Z19Lote);
                  GXUtil.WriteLogRaw("Current: ",T00012_A19Lote[0]);
               }
               if ( Z20SeqDependente != T00012_A20SeqDependente[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"SeqDependente");
                  GXUtil.WriteLogRaw("Old: ",Z20SeqDependente);
                  GXUtil.WriteLogRaw("Current: ",T00012_A20SeqDependente[0]);
               }
               if ( Z21Capela != T00012_A21Capela[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Capela");
                  GXUtil.WriteLogRaw("Old: ",Z21Capela);
                  GXUtil.WriteLogRaw("Current: ",T00012_A21Capela[0]);
               }
               if ( StringUtil.StrCmp(Z22EnderecoFalecido, T00012_A22EnderecoFalecido[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"EnderecoFalecido");
                  GXUtil.WriteLogRaw("Old: ",Z22EnderecoFalecido);
                  GXUtil.WriteLogRaw("Current: ",T00012_A22EnderecoFalecido[0]);
               }
               if ( StringUtil.StrCmp(Z23horafalecimento, T00012_A23horafalecimento[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"horafalecimento");
                  GXUtil.WriteLogRaw("Old: ",Z23horafalecimento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A23horafalecimento[0]);
               }
               if ( Z24CidadeFalecimento != T00012_A24CidadeFalecimento[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"CidadeFalecimento");
                  GXUtil.WriteLogRaw("Old: ",Z24CidadeFalecimento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A24CidadeFalecimento[0]);
               }
               if ( StringUtil.StrCmp(Z25LocalFalecimento, T00012_A25LocalFalecimento[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"LocalFalecimento");
                  GXUtil.WriteLogRaw("Old: ",Z25LocalFalecimento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A25LocalFalecimento[0]);
               }
               if ( StringUtil.StrCmp(Z26HoraSepultamento, T00012_A26HoraSepultamento[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"HoraSepultamento");
                  GXUtil.WriteLogRaw("Old: ",Z26HoraSepultamento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A26HoraSepultamento[0]);
               }
               if ( Z27DatasolicitacaoAux != T00012_A27DatasolicitacaoAux[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"DatasolicitacaoAux");
                  GXUtil.WriteLogRaw("Old: ",Z27DatasolicitacaoAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A27DatasolicitacaoAux[0]);
               }
               if ( StringUtil.StrCmp(Z28NomeContratanteAux, T00012_A28NomeContratanteAux[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"NomeContratanteAux");
                  GXUtil.WriteLogRaw("Old: ",Z28NomeContratanteAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A28NomeContratanteAux[0]);
               }
               if ( StringUtil.StrCmp(Z29EndContratanteAux, T00012_A29EndContratanteAux[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"EndContratanteAux");
                  GXUtil.WriteLogRaw("Old: ",Z29EndContratanteAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A29EndContratanteAux[0]);
               }
               if ( Z30CidadeContratanteAux != T00012_A30CidadeContratanteAux[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"CidadeContratanteAux");
                  GXUtil.WriteLogRaw("Old: ",Z30CidadeContratanteAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A30CidadeContratanteAux[0]);
               }
               if ( StringUtil.StrCmp(Z31RGContratanteAux, T00012_A31RGContratanteAux[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"RGContratanteAux");
                  GXUtil.WriteLogRaw("Old: ",Z31RGContratanteAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A31RGContratanteAux[0]);
               }
               if ( StringUtil.StrCmp(Z32CPFContratanteAux, T00012_A32CPFContratanteAux[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"CPFContratanteAux");
                  GXUtil.WriteLogRaw("Old: ",Z32CPFContratanteAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A32CPFContratanteAux[0]);
               }
               if ( Z33EstCivilContratanteAux != T00012_A33EstCivilContratanteAux[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"EstCivilContratanteAux");
                  GXUtil.WriteLogRaw("Old: ",Z33EstCivilContratanteAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A33EstCivilContratanteAux[0]);
               }
               if ( Z34DataInsert != T00012_A34DataInsert[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"DataInsert");
                  GXUtil.WriteLogRaw("Old: ",Z34DataInsert);
                  GXUtil.WriteLogRaw("Current: ",T00012_A34DataInsert[0]);
               }
               if ( Z35UsuInsert != T00012_A35UsuInsert[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"UsuInsert");
                  GXUtil.WriteLogRaw("Old: ",Z35UsuInsert);
                  GXUtil.WriteLogRaw("Current: ",T00012_A35UsuInsert[0]);
               }
               if ( Z36DataUpdate != T00012_A36DataUpdate[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"DataUpdate");
                  GXUtil.WriteLogRaw("Old: ",Z36DataUpdate);
                  GXUtil.WriteLogRaw("Current: ",T00012_A36DataUpdate[0]);
               }
               if ( Z37UsuUpdate != T00012_A37UsuUpdate[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"UsuUpdate");
                  GXUtil.WriteLogRaw("Old: ",Z37UsuUpdate);
                  GXUtil.WriteLogRaw("Current: ",T00012_A37UsuUpdate[0]);
               }
               if ( Z38NumControleAux != T00012_A38NumControleAux[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"NumControleAux");
                  GXUtil.WriteLogRaw("Old: ",Z38NumControleAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A38NumControleAux[0]);
               }
               if ( Z39ValorAux != T00012_A39ValorAux[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"ValorAux");
                  GXUtil.WriteLogRaw("Old: ",Z39ValorAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A39ValorAux[0]);
               }
               if ( Z40DataPagtoAux != T00012_A40DataPagtoAux[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"DataPagtoAux");
                  GXUtil.WriteLogRaw("Old: ",Z40DataPagtoAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A40DataPagtoAux[0]);
               }
               if ( StringUtil.StrCmp(Z41ObservacaoAux, T00012_A41ObservacaoAux[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"ObservacaoAux");
                  GXUtil.WriteLogRaw("Old: ",Z41ObservacaoAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A41ObservacaoAux[0]);
               }
               if ( StringUtil.StrCmp(Z42EmCarencia, T00012_A42EmCarencia[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"EmCarencia");
                  GXUtil.WriteLogRaw("Old: ",Z42EmCarencia);
                  GXUtil.WriteLogRaw("Current: ",T00012_A42EmCarencia[0]);
               }
               if ( Z43PercentualCobertura != T00012_A43PercentualCobertura[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"PercentualCobertura");
                  GXUtil.WriteLogRaw("Old: ",Z43PercentualCobertura);
                  GXUtil.WriteLogRaw("Current: ",T00012_A43PercentualCobertura[0]);
               }
               if ( StringUtil.StrCmp(Z44PacienteUnesp, T00012_A44PacienteUnesp[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"PacienteUnesp");
                  GXUtil.WriteLogRaw("Old: ",Z44PacienteUnesp);
                  GXUtil.WriteLogRaw("Current: ",T00012_A44PacienteUnesp[0]);
               }
               if ( StringUtil.StrCmp(Z45RegistroUnesp, T00012_A45RegistroUnesp[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"RegistroUnesp");
                  GXUtil.WriteLogRaw("Old: ",Z45RegistroUnesp);
                  GXUtil.WriteLogRaw("Current: ",T00012_A45RegistroUnesp[0]);
               }
               if ( StringUtil.StrCmp(Z47ViciosHabituais, T00012_A47ViciosHabituais[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"ViciosHabituais");
                  GXUtil.WriteLogRaw("Old: ",Z47ViciosHabituais);
                  GXUtil.WriteLogRaw("Current: ",T00012_A47ViciosHabituais[0]);
               }
               if ( StringUtil.StrCmp(Z48ViciosEspecificar, T00012_A48ViciosEspecificar[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"ViciosEspecificar");
                  GXUtil.WriteLogRaw("Old: ",Z48ViciosEspecificar);
                  GXUtil.WriteLogRaw("Current: ",T00012_A48ViciosEspecificar[0]);
               }
               if ( StringUtil.StrCmp(Z49DoencasConhecidas, T00012_A49DoencasConhecidas[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"DoencasConhecidas");
                  GXUtil.WriteLogRaw("Old: ",Z49DoencasConhecidas);
                  GXUtil.WriteLogRaw("Current: ",T00012_A49DoencasConhecidas[0]);
               }
               if ( Z50TaxaCapelaAux != T00012_A50TaxaCapelaAux[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"TaxaCapelaAux");
                  GXUtil.WriteLogRaw("Old: ",Z50TaxaCapelaAux);
                  GXUtil.WriteLogRaw("Current: ",T00012_A50TaxaCapelaAux[0]);
               }
               if ( Z51TaxaSepultamento != T00012_A51TaxaSepultamento[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"TaxaSepultamento");
                  GXUtil.WriteLogRaw("Old: ",Z51TaxaSepultamento);
                  GXUtil.WriteLogRaw("Current: ",T00012_A51TaxaSepultamento[0]);
               }
               if ( StringUtil.StrCmp(Z52Matricula, T00012_A52Matricula[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Matricula");
                  GXUtil.WriteLogRaw("Old: ",Z52Matricula);
                  GXUtil.WriteLogRaw("Current: ",T00012_A52Matricula[0]);
               }
               if ( StringUtil.StrCmp(Z53UsouCremacao, T00012_A53UsouCremacao[0]) != 0 )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"UsouCremacao");
                  GXUtil.WriteLogRaw("Old: ",Z53UsouCremacao);
                  GXUtil.WriteLogRaw("Current: ",T00012_A53UsouCremacao[0]);
               }
               if ( Z54Seq != T00012_A54Seq[0] )
               {
                  GXUtil.WriteLog("obitos:[seudo value changed for attri]"+"Seq");
                  GXUtil.WriteLogRaw("Old: ",Z54Seq);
                  GXUtil.WriteLogRaw("Current: ",T00012_A54Seq[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Obitos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00018 */
                     pr_datastore1.execute(6, new Object[] {A1Inscricao, A2Nome, n3Grupo, A3Grupo, n4Referencia, A4Referencia, n5Numero, A5Numero, n6Valor, A6Valor, n7Vencimento, A7Vencimento, n8Nascimento, A8Nascimento, n9Falecimento, A9Falecimento, n10NumeroObito, A10NumeroObito, n11NFNumero, A11NFNumero, n12NFValor, A12NFValor, n13Funeraria, A13Funeraria, n14Observacao, A14Observacao, n15Parentesco, A15Parentesco, n16Cemiterio, A16Cemiterio, n17Jazigo, A17Jazigo, n18Quadra, A18Quadra, n19Lote, A19Lote, n20SeqDependente, A20SeqDependente, n21Capela, A21Capela, n22EnderecoFalecido, A22EnderecoFalecido, n23horafalecimento, A23horafalecimento, n24CidadeFalecimento, A24CidadeFalecimento, n25LocalFalecimento, A25LocalFalecimento, n26HoraSepultamento, A26HoraSepultamento, n27DatasolicitacaoAux, A27DatasolicitacaoAux, n28NomeContratanteAux, A28NomeContratanteAux, n29EndContratanteAux, A29EndContratanteAux, n30CidadeContratanteAux, A30CidadeContratanteAux, n31RGContratanteAux, A31RGContratanteAux, n32CPFContratanteAux, A32CPFContratanteAux, n33EstCivilContratanteAux, A33EstCivilContratanteAux, n34DataInsert, A34DataInsert, n35UsuInsert, A35UsuInsert, n36DataUpdate, A36DataUpdate, n37UsuUpdate, A37UsuUpdate, n38NumControleAux, A38NumControleAux, n39ValorAux, A39ValorAux, n40DataPagtoAux, A40DataPagtoAux, n41ObservacaoAux, A41ObservacaoAux, n42EmCarencia, A42EmCarencia, n43PercentualCobertura, A43PercentualCobertura, n44PacienteUnesp, A44PacienteUnesp, n45RegistroUnesp, A45RegistroUnesp, n46RelatoObito, A46RelatoObito, n47ViciosHabituais, A47ViciosHabituais, n48ViciosEspecificar, A48ViciosEspecificar, n49DoencasConhecidas, A49DoencasConhecidas, n50TaxaCapelaAux, A50TaxaCapelaAux, n51TaxaSepultamento, A51TaxaSepultamento, n52Matricula, A52Matricula, n53UsouCremacao, A53UsouCremacao, n54Seq, A54Seq});
                     pr_datastore1.close(6);
                     pr_datastore1.SmartCacheProvider.SetUpdated("Obitos");
                     if ( (pr_datastore1.getStatus(6) == 1) )
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
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00019 */
                     pr_datastore1.execute(7, new Object[] {n3Grupo, A3Grupo, n4Referencia, A4Referencia, n5Numero, A5Numero, n6Valor, A6Valor, n7Vencimento, A7Vencimento, n8Nascimento, A8Nascimento, n9Falecimento, A9Falecimento, n10NumeroObito, A10NumeroObito, n11NFNumero, A11NFNumero, n12NFValor, A12NFValor, n13Funeraria, A13Funeraria, n14Observacao, A14Observacao, n15Parentesco, A15Parentesco, n16Cemiterio, A16Cemiterio, n17Jazigo, A17Jazigo, n18Quadra, A18Quadra, n19Lote, A19Lote, n20SeqDependente, A20SeqDependente, n21Capela, A21Capela, n22EnderecoFalecido, A22EnderecoFalecido, n23horafalecimento, A23horafalecimento, n24CidadeFalecimento, A24CidadeFalecimento, n25LocalFalecimento, A25LocalFalecimento, n26HoraSepultamento, A26HoraSepultamento, n27DatasolicitacaoAux, A27DatasolicitacaoAux, n28NomeContratanteAux, A28NomeContratanteAux, n29EndContratanteAux, A29EndContratanteAux, n30CidadeContratanteAux, A30CidadeContratanteAux, n31RGContratanteAux, A31RGContratanteAux, n32CPFContratanteAux, A32CPFContratanteAux, n33EstCivilContratanteAux, A33EstCivilContratanteAux, n34DataInsert, A34DataInsert, n35UsuInsert, A35UsuInsert, n36DataUpdate, A36DataUpdate, n37UsuUpdate, A37UsuUpdate, n38NumControleAux, A38NumControleAux, n39ValorAux, A39ValorAux, n40DataPagtoAux, A40DataPagtoAux, n41ObservacaoAux, A41ObservacaoAux, n42EmCarencia, A42EmCarencia, n43PercentualCobertura, A43PercentualCobertura, n44PacienteUnesp, A44PacienteUnesp, n45RegistroUnesp, A45RegistroUnesp, n46RelatoObito, A46RelatoObito, n47ViciosHabituais, A47ViciosHabituais, n48ViciosEspecificar, A48ViciosEspecificar, n49DoencasConhecidas, A49DoencasConhecidas, n50TaxaCapelaAux, A50TaxaCapelaAux, n51TaxaSepultamento, A51TaxaSepultamento, n52Matricula, A52Matricula, n53UsouCremacao, A53UsouCremacao, n54Seq, A54Seq, A1Inscricao, A2Nome});
                     pr_datastore1.close(7);
                     pr_datastore1.SmartCacheProvider.SetUpdated("Obitos");
                     if ( (pr_datastore1.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Obitos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000110 */
                  pr_datastore1.execute(8, new Object[] {A1Inscricao, A2Nome});
                  pr_datastore1.close(8);
                  pr_datastore1.SmartCacheProvider.SetUpdated("Obitos");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "Obitos";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore1.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_datastore1.close(1);
            context.CommitDataStores("obitos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_datastore1.close(1);
            context.RollbackDataStores("obitos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000111 */
         pr_datastore1.execute(9);
         RcdFound1 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1Inscricao = T000111_A1Inscricao[0];
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = T000111_A2Nome[0];
            AssignAttri("", false, "A2Nome", A2Nome);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_datastore1.readNext(9);
         RcdFound1 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A1Inscricao = T000111_A1Inscricao[0];
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = T000111_A2Nome[0];
            AssignAttri("", false, "A2Nome", A2Nome);
         }
      }

      protected void ScanEnd011( )
      {
         pr_datastore1.close(9);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtInscricao_Enabled = 0;
         AssignProp("", false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         edtNome_Enabled = 0;
         AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         edtGrupo_Enabled = 0;
         AssignProp("", false, edtGrupo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGrupo_Enabled), 5, 0), true);
         edtReferencia_Enabled = 0;
         AssignProp("", false, edtReferencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReferencia_Enabled), 5, 0), true);
         edtNumero_Enabled = 0;
         AssignProp("", false, edtNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNumero_Enabled), 5, 0), true);
         edtValor_Enabled = 0;
         AssignProp("", false, edtValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtValor_Enabled), 5, 0), true);
         edtVencimento_Enabled = 0;
         AssignProp("", false, edtVencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVencimento_Enabled), 5, 0), true);
         edtNascimento_Enabled = 0;
         AssignProp("", false, edtNascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNascimento_Enabled), 5, 0), true);
         edtFalecimento_Enabled = 0;
         AssignProp("", false, edtFalecimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFalecimento_Enabled), 5, 0), true);
         edtNumeroObito_Enabled = 0;
         AssignProp("", false, edtNumeroObito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNumeroObito_Enabled), 5, 0), true);
         edtNFNumero_Enabled = 0;
         AssignProp("", false, edtNFNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNFNumero_Enabled), 5, 0), true);
         edtNFValor_Enabled = 0;
         AssignProp("", false, edtNFValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNFValor_Enabled), 5, 0), true);
         edtFuneraria_Enabled = 0;
         AssignProp("", false, edtFuneraria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuneraria_Enabled), 5, 0), true);
         edtObservacao_Enabled = 0;
         AssignProp("", false, edtObservacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObservacao_Enabled), 5, 0), true);
         edtParentesco_Enabled = 0;
         AssignProp("", false, edtParentesco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParentesco_Enabled), 5, 0), true);
         edtCemiterio_Enabled = 0;
         AssignProp("", false, edtCemiterio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCemiterio_Enabled), 5, 0), true);
         edtJazigo_Enabled = 0;
         AssignProp("", false, edtJazigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtJazigo_Enabled), 5, 0), true);
         edtQuadra_Enabled = 0;
         AssignProp("", false, edtQuadra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtQuadra_Enabled), 5, 0), true);
         edtLote_Enabled = 0;
         AssignProp("", false, edtLote_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLote_Enabled), 5, 0), true);
         edtSeqDependente_Enabled = 0;
         AssignProp("", false, edtSeqDependente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSeqDependente_Enabled), 5, 0), true);
         edtCapela_Enabled = 0;
         AssignProp("", false, edtCapela_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCapela_Enabled), 5, 0), true);
         edtEnderecoFalecido_Enabled = 0;
         AssignProp("", false, edtEnderecoFalecido_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnderecoFalecido_Enabled), 5, 0), true);
         edthorafalecimento_Enabled = 0;
         AssignProp("", false, edthorafalecimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edthorafalecimento_Enabled), 5, 0), true);
         edtCidadeFalecimento_Enabled = 0;
         AssignProp("", false, edtCidadeFalecimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCidadeFalecimento_Enabled), 5, 0), true);
         edtLocalFalecimento_Enabled = 0;
         AssignProp("", false, edtLocalFalecimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLocalFalecimento_Enabled), 5, 0), true);
         edtHoraSepultamento_Enabled = 0;
         AssignProp("", false, edtHoraSepultamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHoraSepultamento_Enabled), 5, 0), true);
         edtDatasolicitacaoAux_Enabled = 0;
         AssignProp("", false, edtDatasolicitacaoAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDatasolicitacaoAux_Enabled), 5, 0), true);
         edtNomeContratanteAux_Enabled = 0;
         AssignProp("", false, edtNomeContratanteAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNomeContratanteAux_Enabled), 5, 0), true);
         edtEndContratanteAux_Enabled = 0;
         AssignProp("", false, edtEndContratanteAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEndContratanteAux_Enabled), 5, 0), true);
         edtCidadeContratanteAux_Enabled = 0;
         AssignProp("", false, edtCidadeContratanteAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCidadeContratanteAux_Enabled), 5, 0), true);
         edtRGContratanteAux_Enabled = 0;
         AssignProp("", false, edtRGContratanteAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRGContratanteAux_Enabled), 5, 0), true);
         edtCPFContratanteAux_Enabled = 0;
         AssignProp("", false, edtCPFContratanteAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPFContratanteAux_Enabled), 5, 0), true);
         edtEstCivilContratanteAux_Enabled = 0;
         AssignProp("", false, edtEstCivilContratanteAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstCivilContratanteAux_Enabled), 5, 0), true);
         edtDataInsert_Enabled = 0;
         AssignProp("", false, edtDataInsert_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataInsert_Enabled), 5, 0), true);
         edtUsuInsert_Enabled = 0;
         AssignProp("", false, edtUsuInsert_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuInsert_Enabled), 5, 0), true);
         edtDataUpdate_Enabled = 0;
         AssignProp("", false, edtDataUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataUpdate_Enabled), 5, 0), true);
         edtUsuUpdate_Enabled = 0;
         AssignProp("", false, edtUsuUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuUpdate_Enabled), 5, 0), true);
         edtNumControleAux_Enabled = 0;
         AssignProp("", false, edtNumControleAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNumControleAux_Enabled), 5, 0), true);
         edtValorAux_Enabled = 0;
         AssignProp("", false, edtValorAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtValorAux_Enabled), 5, 0), true);
         edtDataPagtoAux_Enabled = 0;
         AssignProp("", false, edtDataPagtoAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataPagtoAux_Enabled), 5, 0), true);
         edtObservacaoAux_Enabled = 0;
         AssignProp("", false, edtObservacaoAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObservacaoAux_Enabled), 5, 0), true);
         edtEmCarencia_Enabled = 0;
         AssignProp("", false, edtEmCarencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmCarencia_Enabled), 5, 0), true);
         edtPercentualCobertura_Enabled = 0;
         AssignProp("", false, edtPercentualCobertura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPercentualCobertura_Enabled), 5, 0), true);
         edtPacienteUnesp_Enabled = 0;
         AssignProp("", false, edtPacienteUnesp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPacienteUnesp_Enabled), 5, 0), true);
         edtRegistroUnesp_Enabled = 0;
         AssignProp("", false, edtRegistroUnesp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRegistroUnesp_Enabled), 5, 0), true);
         edtRelatoObito_Enabled = 0;
         AssignProp("", false, edtRelatoObito_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelatoObito_Enabled), 5, 0), true);
         edtViciosHabituais_Enabled = 0;
         AssignProp("", false, edtViciosHabituais_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtViciosHabituais_Enabled), 5, 0), true);
         edtViciosEspecificar_Enabled = 0;
         AssignProp("", false, edtViciosEspecificar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtViciosEspecificar_Enabled), 5, 0), true);
         edtDoencasConhecidas_Enabled = 0;
         AssignProp("", false, edtDoencasConhecidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDoencasConhecidas_Enabled), 5, 0), true);
         edtTaxaCapelaAux_Enabled = 0;
         AssignProp("", false, edtTaxaCapelaAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxaCapelaAux_Enabled), 5, 0), true);
         edtTaxaSepultamento_Enabled = 0;
         AssignProp("", false, edtTaxaSepultamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTaxaSepultamento_Enabled), 5, 0), true);
         edtMatricula_Enabled = 0;
         AssignProp("", false, edtMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMatricula_Enabled), 5, 0), true);
         edtUsouCremacao_Enabled = 0;
         AssignProp("", false, edtUsouCremacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsouCremacao_Enabled), 5, 0), true);
         edtSeq_Enabled = 0;
         AssignProp("", false, edtSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSeq_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
      {
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 1318140), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("obitos.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7Inscricao,9,0)),UrlEncode(StringUtil.RTrim(AV8Nome))}, new string[] {"Gx_mode","Inscricao","Nome"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Obitos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("obitos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1Inscricao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1Inscricao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2Nome", Z2Nome);
         GxWebStd.gx_hidden_field( context, "Z3Grupo", StringUtil.RTrim( Z3Grupo));
         GxWebStd.gx_hidden_field( context, "Z4Referencia", StringUtil.RTrim( Z4Referencia));
         GxWebStd.gx_hidden_field( context, "Z5Numero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5Numero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z6Valor", StringUtil.LTrim( StringUtil.NToC( Z6Valor, 18, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z7Vencimento", context.localUtil.TToC( Z7Vencimento, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z8Nascimento", context.localUtil.TToC( Z8Nascimento, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z9Falecimento", context.localUtil.TToC( Z9Falecimento, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z10NumeroObito", Z10NumeroObito);
         GxWebStd.gx_hidden_field( context, "Z11NFNumero", Z11NFNumero);
         GxWebStd.gx_hidden_field( context, "Z12NFValor", StringUtil.LTrim( StringUtil.NToC( Z12NFValor, 18, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13Funeraria", StringUtil.RTrim( Z13Funeraria));
         GxWebStd.gx_hidden_field( context, "Z14Observacao", Z14Observacao);
         GxWebStd.gx_hidden_field( context, "Z15Parentesco", StringUtil.RTrim( Z15Parentesco));
         GxWebStd.gx_hidden_field( context, "Z16Cemiterio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16Cemiterio), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z17Jazigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17Jazigo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z18Quadra", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18Quadra), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z19Lote", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19Lote), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z20SeqDependente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20SeqDependente), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z21Capela", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21Capela), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z22EnderecoFalecido", Z22EnderecoFalecido);
         GxWebStd.gx_hidden_field( context, "Z23horafalecimento", Z23horafalecimento);
         GxWebStd.gx_hidden_field( context, "Z24CidadeFalecimento", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24CidadeFalecimento), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z25LocalFalecimento", Z25LocalFalecimento);
         GxWebStd.gx_hidden_field( context, "Z26HoraSepultamento", Z26HoraSepultamento);
         GxWebStd.gx_hidden_field( context, "Z27DatasolicitacaoAux", context.localUtil.TToC( Z27DatasolicitacaoAux, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z28NomeContratanteAux", Z28NomeContratanteAux);
         GxWebStd.gx_hidden_field( context, "Z29EndContratanteAux", Z29EndContratanteAux);
         GxWebStd.gx_hidden_field( context, "Z30CidadeContratanteAux", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30CidadeContratanteAux), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z31RGContratanteAux", Z31RGContratanteAux);
         GxWebStd.gx_hidden_field( context, "Z32CPFContratanteAux", Z32CPFContratanteAux);
         GxWebStd.gx_hidden_field( context, "Z33EstCivilContratanteAux", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33EstCivilContratanteAux), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z34DataInsert", context.localUtil.TToC( Z34DataInsert, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z35UsuInsert", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35UsuInsert), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z36DataUpdate", context.localUtil.TToC( Z36DataUpdate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z37UsuUpdate", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37UsuUpdate), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z38NumControleAux", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z38NumControleAux), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z39ValorAux", StringUtil.LTrim( StringUtil.NToC( Z39ValorAux, 18, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z40DataPagtoAux", context.localUtil.TToC( Z40DataPagtoAux, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z41ObservacaoAux", Z41ObservacaoAux);
         GxWebStd.gx_hidden_field( context, "Z42EmCarencia", StringUtil.RTrim( Z42EmCarencia));
         GxWebStd.gx_hidden_field( context, "Z43PercentualCobertura", StringUtil.LTrim( StringUtil.NToC( Z43PercentualCobertura, 18, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z44PacienteUnesp", StringUtil.RTrim( Z44PacienteUnesp));
         GxWebStd.gx_hidden_field( context, "Z45RegistroUnesp", Z45RegistroUnesp);
         GxWebStd.gx_hidden_field( context, "Z47ViciosHabituais", StringUtil.RTrim( Z47ViciosHabituais));
         GxWebStd.gx_hidden_field( context, "Z48ViciosEspecificar", Z48ViciosEspecificar);
         GxWebStd.gx_hidden_field( context, "Z49DoencasConhecidas", Z49DoencasConhecidas);
         GxWebStd.gx_hidden_field( context, "Z50TaxaCapelaAux", StringUtil.LTrim( StringUtil.NToC( Z50TaxaCapelaAux, 18, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z51TaxaSepultamento", StringUtil.LTrim( StringUtil.NToC( Z51TaxaSepultamento, 18, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z52Matricula", Z52Matricula);
         GxWebStd.gx_hidden_field( context, "Z53UsouCremacao", StringUtil.RTrim( Z53UsouCremacao));
         GxWebStd.gx_hidden_field( context, "Z54Seq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54Seq), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vINSCRICAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Inscricao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINSCRICAO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Inscricao), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNOME", AV8Nome);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8Nome, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
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
         return formatLink("obitos.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7Inscricao,9,0)),UrlEncode(StringUtil.RTrim(AV8Nome))}, new string[] {"Gx_mode","Inscricao","Nome"})  ;
      }

      public override string GetPgmname( )
      {
         return "Obitos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Óbitos | Velório Gold" ;
      }

      protected void InitializeNonKey011( )
      {
         A3Grupo = "";
         n3Grupo = false;
         AssignAttri("", false, "A3Grupo", A3Grupo);
         n3Grupo = (String.IsNullOrEmpty(StringUtil.RTrim( A3Grupo)) ? true : false);
         A4Referencia = "";
         n4Referencia = false;
         AssignAttri("", false, "A4Referencia", A4Referencia);
         n4Referencia = (String.IsNullOrEmpty(StringUtil.RTrim( A4Referencia)) ? true : false);
         A5Numero = 0;
         n5Numero = false;
         AssignAttri("", false, "A5Numero", StringUtil.LTrimStr( (decimal)(A5Numero), 9, 0));
         n5Numero = ((0==A5Numero) ? true : false);
         A6Valor = 0;
         n6Valor = false;
         AssignAttri("", false, "A6Valor", StringUtil.LTrimStr( A6Valor, 18, 4));
         n6Valor = ((Convert.ToDecimal(0)==A6Valor) ? true : false);
         A7Vencimento = (DateTime)(DateTime.MinValue);
         n7Vencimento = false;
         AssignAttri("", false, "A7Vencimento", context.localUtil.TToC( A7Vencimento, 10, 8, 0, 3, "/", ":", " "));
         n7Vencimento = ((DateTime.MinValue==A7Vencimento) ? true : false);
         A8Nascimento = (DateTime)(DateTime.MinValue);
         n8Nascimento = false;
         AssignAttri("", false, "A8Nascimento", context.localUtil.TToC( A8Nascimento, 10, 8, 0, 3, "/", ":", " "));
         n8Nascimento = ((DateTime.MinValue==A8Nascimento) ? true : false);
         A9Falecimento = (DateTime)(DateTime.MinValue);
         n9Falecimento = false;
         AssignAttri("", false, "A9Falecimento", context.localUtil.TToC( A9Falecimento, 10, 8, 0, 3, "/", ":", " "));
         n9Falecimento = ((DateTime.MinValue==A9Falecimento) ? true : false);
         A10NumeroObito = "";
         n10NumeroObito = false;
         AssignAttri("", false, "A10NumeroObito", A10NumeroObito);
         n10NumeroObito = (String.IsNullOrEmpty(StringUtil.RTrim( A10NumeroObito)) ? true : false);
         A11NFNumero = "";
         n11NFNumero = false;
         AssignAttri("", false, "A11NFNumero", A11NFNumero);
         n11NFNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A11NFNumero)) ? true : false);
         A12NFValor = 0;
         n12NFValor = false;
         AssignAttri("", false, "A12NFValor", StringUtil.LTrimStr( A12NFValor, 18, 4));
         n12NFValor = ((Convert.ToDecimal(0)==A12NFValor) ? true : false);
         A13Funeraria = "";
         n13Funeraria = false;
         AssignAttri("", false, "A13Funeraria", A13Funeraria);
         n13Funeraria = (String.IsNullOrEmpty(StringUtil.RTrim( A13Funeraria)) ? true : false);
         A14Observacao = "";
         n14Observacao = false;
         AssignAttri("", false, "A14Observacao", A14Observacao);
         n14Observacao = (String.IsNullOrEmpty(StringUtil.RTrim( A14Observacao)) ? true : false);
         A15Parentesco = "";
         n15Parentesco = false;
         AssignAttri("", false, "A15Parentesco", A15Parentesco);
         n15Parentesco = (String.IsNullOrEmpty(StringUtil.RTrim( A15Parentesco)) ? true : false);
         A16Cemiterio = 0;
         n16Cemiterio = false;
         AssignAttri("", false, "A16Cemiterio", StringUtil.LTrimStr( (decimal)(A16Cemiterio), 9, 0));
         n16Cemiterio = ((0==A16Cemiterio) ? true : false);
         A17Jazigo = 0;
         n17Jazigo = false;
         AssignAttri("", false, "A17Jazigo", StringUtil.LTrimStr( (decimal)(A17Jazigo), 9, 0));
         n17Jazigo = ((0==A17Jazigo) ? true : false);
         A18Quadra = 0;
         n18Quadra = false;
         AssignAttri("", false, "A18Quadra", StringUtil.LTrimStr( (decimal)(A18Quadra), 9, 0));
         n18Quadra = ((0==A18Quadra) ? true : false);
         A19Lote = 0;
         n19Lote = false;
         AssignAttri("", false, "A19Lote", StringUtil.LTrimStr( (decimal)(A19Lote), 9, 0));
         n19Lote = ((0==A19Lote) ? true : false);
         A20SeqDependente = 0;
         n20SeqDependente = false;
         AssignAttri("", false, "A20SeqDependente", StringUtil.LTrimStr( (decimal)(A20SeqDependente), 9, 0));
         n20SeqDependente = ((0==A20SeqDependente) ? true : false);
         A21Capela = 0;
         n21Capela = false;
         AssignAttri("", false, "A21Capela", StringUtil.LTrimStr( (decimal)(A21Capela), 9, 0));
         n21Capela = ((0==A21Capela) ? true : false);
         A22EnderecoFalecido = "";
         n22EnderecoFalecido = false;
         AssignAttri("", false, "A22EnderecoFalecido", A22EnderecoFalecido);
         n22EnderecoFalecido = (String.IsNullOrEmpty(StringUtil.RTrim( A22EnderecoFalecido)) ? true : false);
         A23horafalecimento = "";
         n23horafalecimento = false;
         AssignAttri("", false, "A23horafalecimento", A23horafalecimento);
         n23horafalecimento = (String.IsNullOrEmpty(StringUtil.RTrim( A23horafalecimento)) ? true : false);
         A24CidadeFalecimento = 0;
         n24CidadeFalecimento = false;
         AssignAttri("", false, "A24CidadeFalecimento", StringUtil.LTrimStr( (decimal)(A24CidadeFalecimento), 9, 0));
         n24CidadeFalecimento = ((0==A24CidadeFalecimento) ? true : false);
         A25LocalFalecimento = "";
         n25LocalFalecimento = false;
         AssignAttri("", false, "A25LocalFalecimento", A25LocalFalecimento);
         n25LocalFalecimento = (String.IsNullOrEmpty(StringUtil.RTrim( A25LocalFalecimento)) ? true : false);
         A26HoraSepultamento = "";
         n26HoraSepultamento = false;
         AssignAttri("", false, "A26HoraSepultamento", A26HoraSepultamento);
         n26HoraSepultamento = (String.IsNullOrEmpty(StringUtil.RTrim( A26HoraSepultamento)) ? true : false);
         A27DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
         n27DatasolicitacaoAux = false;
         AssignAttri("", false, "A27DatasolicitacaoAux", context.localUtil.TToC( A27DatasolicitacaoAux, 10, 8, 0, 3, "/", ":", " "));
         n27DatasolicitacaoAux = ((DateTime.MinValue==A27DatasolicitacaoAux) ? true : false);
         A28NomeContratanteAux = "";
         n28NomeContratanteAux = false;
         AssignAttri("", false, "A28NomeContratanteAux", A28NomeContratanteAux);
         n28NomeContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A28NomeContratanteAux)) ? true : false);
         A29EndContratanteAux = "";
         n29EndContratanteAux = false;
         AssignAttri("", false, "A29EndContratanteAux", A29EndContratanteAux);
         n29EndContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A29EndContratanteAux)) ? true : false);
         A30CidadeContratanteAux = 0;
         n30CidadeContratanteAux = false;
         AssignAttri("", false, "A30CidadeContratanteAux", StringUtil.LTrimStr( (decimal)(A30CidadeContratanteAux), 9, 0));
         n30CidadeContratanteAux = ((0==A30CidadeContratanteAux) ? true : false);
         A31RGContratanteAux = "";
         n31RGContratanteAux = false;
         AssignAttri("", false, "A31RGContratanteAux", A31RGContratanteAux);
         n31RGContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A31RGContratanteAux)) ? true : false);
         A32CPFContratanteAux = "";
         n32CPFContratanteAux = false;
         AssignAttri("", false, "A32CPFContratanteAux", A32CPFContratanteAux);
         n32CPFContratanteAux = (String.IsNullOrEmpty(StringUtil.RTrim( A32CPFContratanteAux)) ? true : false);
         A33EstCivilContratanteAux = 0;
         n33EstCivilContratanteAux = false;
         AssignAttri("", false, "A33EstCivilContratanteAux", StringUtil.LTrimStr( (decimal)(A33EstCivilContratanteAux), 9, 0));
         n33EstCivilContratanteAux = ((0==A33EstCivilContratanteAux) ? true : false);
         A34DataInsert = (DateTime)(DateTime.MinValue);
         n34DataInsert = false;
         AssignAttri("", false, "A34DataInsert", context.localUtil.TToC( A34DataInsert, 10, 8, 0, 3, "/", ":", " "));
         n34DataInsert = ((DateTime.MinValue==A34DataInsert) ? true : false);
         A35UsuInsert = 0;
         n35UsuInsert = false;
         AssignAttri("", false, "A35UsuInsert", StringUtil.LTrimStr( (decimal)(A35UsuInsert), 9, 0));
         n35UsuInsert = ((0==A35UsuInsert) ? true : false);
         A36DataUpdate = (DateTime)(DateTime.MinValue);
         n36DataUpdate = false;
         AssignAttri("", false, "A36DataUpdate", context.localUtil.TToC( A36DataUpdate, 10, 8, 0, 3, "/", ":", " "));
         n36DataUpdate = ((DateTime.MinValue==A36DataUpdate) ? true : false);
         A37UsuUpdate = 0;
         n37UsuUpdate = false;
         AssignAttri("", false, "A37UsuUpdate", StringUtil.LTrimStr( (decimal)(A37UsuUpdate), 9, 0));
         n37UsuUpdate = ((0==A37UsuUpdate) ? true : false);
         A38NumControleAux = 0;
         n38NumControleAux = false;
         AssignAttri("", false, "A38NumControleAux", StringUtil.LTrimStr( (decimal)(A38NumControleAux), 9, 0));
         n38NumControleAux = ((0==A38NumControleAux) ? true : false);
         A39ValorAux = 0;
         n39ValorAux = false;
         AssignAttri("", false, "A39ValorAux", StringUtil.LTrimStr( A39ValorAux, 18, 4));
         n39ValorAux = ((Convert.ToDecimal(0)==A39ValorAux) ? true : false);
         A40DataPagtoAux = (DateTime)(DateTime.MinValue);
         n40DataPagtoAux = false;
         AssignAttri("", false, "A40DataPagtoAux", context.localUtil.TToC( A40DataPagtoAux, 10, 8, 0, 3, "/", ":", " "));
         n40DataPagtoAux = ((DateTime.MinValue==A40DataPagtoAux) ? true : false);
         A41ObservacaoAux = "";
         n41ObservacaoAux = false;
         AssignAttri("", false, "A41ObservacaoAux", A41ObservacaoAux);
         n41ObservacaoAux = (String.IsNullOrEmpty(StringUtil.RTrim( A41ObservacaoAux)) ? true : false);
         A42EmCarencia = "";
         n42EmCarencia = false;
         AssignAttri("", false, "A42EmCarencia", A42EmCarencia);
         n42EmCarencia = (String.IsNullOrEmpty(StringUtil.RTrim( A42EmCarencia)) ? true : false);
         A43PercentualCobertura = 0;
         n43PercentualCobertura = false;
         AssignAttri("", false, "A43PercentualCobertura", StringUtil.LTrimStr( A43PercentualCobertura, 18, 4));
         n43PercentualCobertura = ((Convert.ToDecimal(0)==A43PercentualCobertura) ? true : false);
         A44PacienteUnesp = "";
         n44PacienteUnesp = false;
         AssignAttri("", false, "A44PacienteUnesp", A44PacienteUnesp);
         n44PacienteUnesp = (String.IsNullOrEmpty(StringUtil.RTrim( A44PacienteUnesp)) ? true : false);
         A45RegistroUnesp = "";
         n45RegistroUnesp = false;
         AssignAttri("", false, "A45RegistroUnesp", A45RegistroUnesp);
         n45RegistroUnesp = (String.IsNullOrEmpty(StringUtil.RTrim( A45RegistroUnesp)) ? true : false);
         A46RelatoObito = "";
         n46RelatoObito = false;
         AssignAttri("", false, "A46RelatoObito", A46RelatoObito);
         n46RelatoObito = (String.IsNullOrEmpty(StringUtil.RTrim( A46RelatoObito)) ? true : false);
         A47ViciosHabituais = "";
         n47ViciosHabituais = false;
         AssignAttri("", false, "A47ViciosHabituais", A47ViciosHabituais);
         n47ViciosHabituais = (String.IsNullOrEmpty(StringUtil.RTrim( A47ViciosHabituais)) ? true : false);
         A48ViciosEspecificar = "";
         n48ViciosEspecificar = false;
         AssignAttri("", false, "A48ViciosEspecificar", A48ViciosEspecificar);
         n48ViciosEspecificar = (String.IsNullOrEmpty(StringUtil.RTrim( A48ViciosEspecificar)) ? true : false);
         A49DoencasConhecidas = "";
         n49DoencasConhecidas = false;
         AssignAttri("", false, "A49DoencasConhecidas", A49DoencasConhecidas);
         n49DoencasConhecidas = (String.IsNullOrEmpty(StringUtil.RTrim( A49DoencasConhecidas)) ? true : false);
         A50TaxaCapelaAux = 0;
         n50TaxaCapelaAux = false;
         AssignAttri("", false, "A50TaxaCapelaAux", StringUtil.LTrimStr( A50TaxaCapelaAux, 18, 4));
         n50TaxaCapelaAux = ((Convert.ToDecimal(0)==A50TaxaCapelaAux) ? true : false);
         A51TaxaSepultamento = 0;
         n51TaxaSepultamento = false;
         AssignAttri("", false, "A51TaxaSepultamento", StringUtil.LTrimStr( A51TaxaSepultamento, 18, 4));
         n51TaxaSepultamento = ((Convert.ToDecimal(0)==A51TaxaSepultamento) ? true : false);
         A52Matricula = "";
         n52Matricula = false;
         AssignAttri("", false, "A52Matricula", A52Matricula);
         n52Matricula = (String.IsNullOrEmpty(StringUtil.RTrim( A52Matricula)) ? true : false);
         A53UsouCremacao = "";
         n53UsouCremacao = false;
         AssignAttri("", false, "A53UsouCremacao", A53UsouCremacao);
         n53UsouCremacao = (String.IsNullOrEmpty(StringUtil.RTrim( A53UsouCremacao)) ? true : false);
         A54Seq = 0;
         n54Seq = false;
         AssignAttri("", false, "A54Seq", StringUtil.LTrimStr( (decimal)(A54Seq), 9, 0));
         n54Seq = ((0==A54Seq) ? true : false);
         Z3Grupo = "";
         Z4Referencia = "";
         Z5Numero = 0;
         Z6Valor = 0;
         Z7Vencimento = (DateTime)(DateTime.MinValue);
         Z8Nascimento = (DateTime)(DateTime.MinValue);
         Z9Falecimento = (DateTime)(DateTime.MinValue);
         Z10NumeroObito = "";
         Z11NFNumero = "";
         Z12NFValor = 0;
         Z13Funeraria = "";
         Z14Observacao = "";
         Z15Parentesco = "";
         Z16Cemiterio = 0;
         Z17Jazigo = 0;
         Z18Quadra = 0;
         Z19Lote = 0;
         Z20SeqDependente = 0;
         Z21Capela = 0;
         Z22EnderecoFalecido = "";
         Z23horafalecimento = "";
         Z24CidadeFalecimento = 0;
         Z25LocalFalecimento = "";
         Z26HoraSepultamento = "";
         Z27DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
         Z28NomeContratanteAux = "";
         Z29EndContratanteAux = "";
         Z30CidadeContratanteAux = 0;
         Z31RGContratanteAux = "";
         Z32CPFContratanteAux = "";
         Z33EstCivilContratanteAux = 0;
         Z34DataInsert = (DateTime)(DateTime.MinValue);
         Z35UsuInsert = 0;
         Z36DataUpdate = (DateTime)(DateTime.MinValue);
         Z37UsuUpdate = 0;
         Z38NumControleAux = 0;
         Z39ValorAux = 0;
         Z40DataPagtoAux = (DateTime)(DateTime.MinValue);
         Z41ObservacaoAux = "";
         Z42EmCarencia = "";
         Z43PercentualCobertura = 0;
         Z44PacienteUnesp = "";
         Z45RegistroUnesp = "";
         Z47ViciosHabituais = "";
         Z48ViciosEspecificar = "";
         Z49DoencasConhecidas = "";
         Z50TaxaCapelaAux = 0;
         Z51TaxaSepultamento = 0;
         Z52Matricula = "";
         Z53UsouCremacao = "";
         Z54Seq = 0;
      }

      protected void InitAll011( )
      {
         A1Inscricao = 0;
         AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
         A2Nome = "";
         AssignAttri("", false, "A2Nome", A2Nome);
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20247248542932", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("obitos.js", "?20247248542932", false, true);
         /* End function include_jscripts */
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
         edtInscricao_Internalname = "INSCRICAO";
         edtNome_Internalname = "NOME";
         edtGrupo_Internalname = "GRUPO";
         edtReferencia_Internalname = "REFERENCIA";
         edtNumero_Internalname = "NUMERO";
         edtValor_Internalname = "VALOR";
         edtVencimento_Internalname = "VENCIMENTO";
         edtNascimento_Internalname = "NASCIMENTO";
         edtFalecimento_Internalname = "FALECIMENTO";
         edtNumeroObito_Internalname = "NUMEROOBITO";
         edtNFNumero_Internalname = "NFNUMERO";
         edtNFValor_Internalname = "NFVALOR";
         edtFuneraria_Internalname = "FUNERARIA";
         edtObservacao_Internalname = "OBSERVACAO";
         edtParentesco_Internalname = "PARENTESCO";
         edtCemiterio_Internalname = "CEMITERIO";
         edtJazigo_Internalname = "JAZIGO";
         edtQuadra_Internalname = "QUADRA";
         edtLote_Internalname = "LOTE";
         edtSeqDependente_Internalname = "SEQDEPENDENTE";
         edtCapela_Internalname = "CAPELA";
         edtEnderecoFalecido_Internalname = "ENDERECOFALECIDO";
         edthorafalecimento_Internalname = "HORAFALECIMENTO";
         edtCidadeFalecimento_Internalname = "CIDADEFALECIMENTO";
         edtLocalFalecimento_Internalname = "LOCALFALECIMENTO";
         edtHoraSepultamento_Internalname = "HORASEPULTAMENTO";
         edtDatasolicitacaoAux_Internalname = "DATASOLICITACAOAUX";
         edtNomeContratanteAux_Internalname = "NOMECONTRATANTEAUX";
         edtEndContratanteAux_Internalname = "ENDCONTRATANTEAUX";
         edtCidadeContratanteAux_Internalname = "CIDADECONTRATANTEAUX";
         edtRGContratanteAux_Internalname = "RGCONTRATANTEAUX";
         edtCPFContratanteAux_Internalname = "CPFCONTRATANTEAUX";
         edtEstCivilContratanteAux_Internalname = "ESTCIVILCONTRATANTEAUX";
         edtDataInsert_Internalname = "DATAINSERT";
         edtUsuInsert_Internalname = "USUINSERT";
         edtDataUpdate_Internalname = "DATAUPDATE";
         edtUsuUpdate_Internalname = "USUUPDATE";
         edtNumControleAux_Internalname = "NUMCONTROLEAUX";
         edtValorAux_Internalname = "VALORAUX";
         edtDataPagtoAux_Internalname = "DATAPAGTOAUX";
         edtObservacaoAux_Internalname = "OBSERVACAOAUX";
         edtEmCarencia_Internalname = "EMCARENCIA";
         edtPercentualCobertura_Internalname = "PERCENTUALCOBERTURA";
         edtPacienteUnesp_Internalname = "PACIENTEUNESP";
         edtRegistroUnesp_Internalname = "REGISTROUNESP";
         edtRelatoObito_Internalname = "RELATOOBITO";
         edtViciosHabituais_Internalname = "VICIOSHABITUAIS";
         edtViciosEspecificar_Internalname = "VICIOSESPECIFICAR";
         edtDoencasConhecidas_Internalname = "DOENCASCONHECIDAS";
         edtTaxaCapelaAux_Internalname = "TAXACAPELAAUX";
         edtTaxaSepultamento_Internalname = "TAXASEPULTAMENTO";
         edtMatricula_Internalname = "MATRICULA";
         edtUsouCremacao_Internalname = "USOUCREMACAO";
         edtSeq_Internalname = "SEQ";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("GoldLegacy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Óbitos | Velório Gold";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSeq_Jsonclick = "";
         edtSeq_Enabled = 1;
         edtUsouCremacao_Jsonclick = "";
         edtUsouCremacao_Enabled = 1;
         edtMatricula_Jsonclick = "";
         edtMatricula_Enabled = 1;
         edtTaxaSepultamento_Jsonclick = "";
         edtTaxaSepultamento_Enabled = 1;
         edtTaxaCapelaAux_Jsonclick = "";
         edtTaxaCapelaAux_Enabled = 1;
         edtDoencasConhecidas_Jsonclick = "";
         edtDoencasConhecidas_Enabled = 1;
         edtViciosEspecificar_Jsonclick = "";
         edtViciosEspecificar_Enabled = 1;
         edtViciosHabituais_Jsonclick = "";
         edtViciosHabituais_Enabled = 1;
         edtRelatoObito_Jsonclick = "";
         edtRelatoObito_Enabled = 1;
         edtRegistroUnesp_Jsonclick = "";
         edtRegistroUnesp_Enabled = 1;
         edtPacienteUnesp_Jsonclick = "";
         edtPacienteUnesp_Enabled = 1;
         edtPercentualCobertura_Jsonclick = "";
         edtPercentualCobertura_Enabled = 1;
         edtEmCarencia_Jsonclick = "";
         edtEmCarencia_Enabled = 1;
         edtObservacaoAux_Enabled = 1;
         edtDataPagtoAux_Jsonclick = "";
         edtDataPagtoAux_Enabled = 1;
         edtValorAux_Jsonclick = "";
         edtValorAux_Enabled = 1;
         edtNumControleAux_Jsonclick = "";
         edtNumControleAux_Enabled = 1;
         edtUsuUpdate_Jsonclick = "";
         edtUsuUpdate_Enabled = 1;
         edtDataUpdate_Jsonclick = "";
         edtDataUpdate_Enabled = 1;
         edtUsuInsert_Jsonclick = "";
         edtUsuInsert_Enabled = 1;
         edtDataInsert_Jsonclick = "";
         edtDataInsert_Enabled = 1;
         edtEstCivilContratanteAux_Jsonclick = "";
         edtEstCivilContratanteAux_Enabled = 1;
         edtCPFContratanteAux_Jsonclick = "";
         edtCPFContratanteAux_Enabled = 1;
         edtRGContratanteAux_Jsonclick = "";
         edtRGContratanteAux_Enabled = 1;
         edtCidadeContratanteAux_Jsonclick = "";
         edtCidadeContratanteAux_Enabled = 1;
         edtEndContratanteAux_Jsonclick = "";
         edtEndContratanteAux_Enabled = 1;
         edtNomeContratanteAux_Jsonclick = "";
         edtNomeContratanteAux_Enabled = 1;
         edtDatasolicitacaoAux_Jsonclick = "";
         edtDatasolicitacaoAux_Enabled = 1;
         edtHoraSepultamento_Jsonclick = "";
         edtHoraSepultamento_Enabled = 1;
         edtLocalFalecimento_Jsonclick = "";
         edtLocalFalecimento_Enabled = 1;
         edtCidadeFalecimento_Jsonclick = "";
         edtCidadeFalecimento_Enabled = 1;
         edthorafalecimento_Jsonclick = "";
         edthorafalecimento_Enabled = 1;
         edtEnderecoFalecido_Jsonclick = "";
         edtEnderecoFalecido_Enabled = 1;
         edtCapela_Jsonclick = "";
         edtCapela_Enabled = 1;
         edtSeqDependente_Jsonclick = "";
         edtSeqDependente_Enabled = 1;
         edtLote_Jsonclick = "";
         edtLote_Enabled = 1;
         edtQuadra_Jsonclick = "";
         edtQuadra_Enabled = 1;
         edtJazigo_Jsonclick = "";
         edtJazigo_Enabled = 1;
         edtCemiterio_Jsonclick = "";
         edtCemiterio_Enabled = 1;
         edtParentesco_Jsonclick = "";
         edtParentesco_Enabled = 1;
         edtObservacao_Jsonclick = "";
         edtObservacao_Enabled = 1;
         edtFuneraria_Jsonclick = "";
         edtFuneraria_Enabled = 1;
         edtNFValor_Jsonclick = "";
         edtNFValor_Enabled = 1;
         edtNFNumero_Jsonclick = "";
         edtNFNumero_Enabled = 1;
         edtNumeroObito_Jsonclick = "";
         edtNumeroObito_Enabled = 1;
         edtFalecimento_Jsonclick = "";
         edtFalecimento_Enabled = 1;
         edtNascimento_Jsonclick = "";
         edtNascimento_Enabled = 1;
         edtVencimento_Jsonclick = "";
         edtVencimento_Enabled = 1;
         edtValor_Jsonclick = "";
         edtValor_Enabled = 1;
         edtNumero_Jsonclick = "";
         edtNumero_Enabled = 1;
         edtReferencia_Jsonclick = "";
         edtReferencia_Enabled = 1;
         edtGrupo_Jsonclick = "";
         edtGrupo_Enabled = 1;
         edtNome_Jsonclick = "";
         edtNome_Enabled = 1;
         edtInscricao_Jsonclick = "";
         edtInscricao_Enabled = 1;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7Inscricao","fld":"vINSCRICAO","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV8Nome","fld":"vNOME","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7Inscricao","fld":"vINSCRICAO","pic":"ZZZZZZZZ9","hsh":true},{"av":"AV8Nome","fld":"vNOME","hsh":true}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12012","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_INSCRICAO","""{"handler":"Valid_Inscricao","iparms":[]}""");
         setEventMetadata("VALID_NOME","""{"handler":"Valid_Nome","iparms":[]}""");
         setEventMetadata("VALID_VENCIMENTO","""{"handler":"Valid_Vencimento","iparms":[]}""");
         setEventMetadata("VALID_NASCIMENTO","""{"handler":"Valid_Nascimento","iparms":[]}""");
         setEventMetadata("VALID_FALECIMENTO","""{"handler":"Valid_Falecimento","iparms":[]}""");
         setEventMetadata("VALID_DATASOLICITACAOAUX","""{"handler":"Valid_Datasolicitacaoaux","iparms":[]}""");
         setEventMetadata("VALID_DATAINSERT","""{"handler":"Valid_Datainsert","iparms":[]}""");
         setEventMetadata("VALID_DATAUPDATE","""{"handler":"Valid_Dataupdate","iparms":[]}""");
         setEventMetadata("VALID_DATAPAGTOAUX","""{"handler":"Valid_Datapagtoaux","iparms":[]}""");
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
         pr_datastore1.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV8Nome = "";
         Z2Nome = "";
         Z3Grupo = "";
         Z4Referencia = "";
         Z7Vencimento = (DateTime)(DateTime.MinValue);
         Z8Nascimento = (DateTime)(DateTime.MinValue);
         Z9Falecimento = (DateTime)(DateTime.MinValue);
         Z10NumeroObito = "";
         Z11NFNumero = "";
         Z13Funeraria = "";
         Z14Observacao = "";
         Z15Parentesco = "";
         Z22EnderecoFalecido = "";
         Z23horafalecimento = "";
         Z25LocalFalecimento = "";
         Z26HoraSepultamento = "";
         Z27DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
         Z28NomeContratanteAux = "";
         Z29EndContratanteAux = "";
         Z31RGContratanteAux = "";
         Z32CPFContratanteAux = "";
         Z34DataInsert = (DateTime)(DateTime.MinValue);
         Z36DataUpdate = (DateTime)(DateTime.MinValue);
         Z40DataPagtoAux = (DateTime)(DateTime.MinValue);
         Z41ObservacaoAux = "";
         Z42EmCarencia = "";
         Z44PacienteUnesp = "";
         Z45RegistroUnesp = "";
         Z47ViciosHabituais = "";
         Z48ViciosEspecificar = "";
         Z49DoencasConhecidas = "";
         Z52Matricula = "";
         Z53UsouCremacao = "";
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
         A2Nome = "";
         A3Grupo = "";
         A4Referencia = "";
         A7Vencimento = (DateTime)(DateTime.MinValue);
         A8Nascimento = (DateTime)(DateTime.MinValue);
         A9Falecimento = (DateTime)(DateTime.MinValue);
         A10NumeroObito = "";
         A11NFNumero = "";
         A13Funeraria = "";
         A14Observacao = "";
         A15Parentesco = "";
         A22EnderecoFalecido = "";
         A23horafalecimento = "";
         A25LocalFalecimento = "";
         A26HoraSepultamento = "";
         A27DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
         A28NomeContratanteAux = "";
         A29EndContratanteAux = "";
         A31RGContratanteAux = "";
         A32CPFContratanteAux = "";
         A34DataInsert = (DateTime)(DateTime.MinValue);
         A36DataUpdate = (DateTime)(DateTime.MinValue);
         A40DataPagtoAux = (DateTime)(DateTime.MinValue);
         A41ObservacaoAux = "";
         A42EmCarencia = "";
         A44PacienteUnesp = "";
         A45RegistroUnesp = "";
         A46RelatoObito = "";
         A47ViciosHabituais = "";
         A48ViciosEspecificar = "";
         A49DoencasConhecidas = "";
         A52Matricula = "";
         A53UsouCremacao = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV11WebSession = context.GetSession();
         Z46RelatoObito = "";
         T00014_A1Inscricao = new int[1] ;
         T00014_A2Nome = new string[] {""} ;
         T00014_A3Grupo = new string[] {""} ;
         T00014_n3Grupo = new bool[] {false} ;
         T00014_A4Referencia = new string[] {""} ;
         T00014_n4Referencia = new bool[] {false} ;
         T00014_A5Numero = new int[1] ;
         T00014_n5Numero = new bool[] {false} ;
         T00014_A6Valor = new decimal[1] ;
         T00014_n6Valor = new bool[] {false} ;
         T00014_A7Vencimento = new DateTime[] {DateTime.MinValue} ;
         T00014_n7Vencimento = new bool[] {false} ;
         T00014_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         T00014_n8Nascimento = new bool[] {false} ;
         T00014_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         T00014_n9Falecimento = new bool[] {false} ;
         T00014_A10NumeroObito = new string[] {""} ;
         T00014_n10NumeroObito = new bool[] {false} ;
         T00014_A11NFNumero = new string[] {""} ;
         T00014_n11NFNumero = new bool[] {false} ;
         T00014_A12NFValor = new decimal[1] ;
         T00014_n12NFValor = new bool[] {false} ;
         T00014_A13Funeraria = new string[] {""} ;
         T00014_n13Funeraria = new bool[] {false} ;
         T00014_A14Observacao = new string[] {""} ;
         T00014_n14Observacao = new bool[] {false} ;
         T00014_A15Parentesco = new string[] {""} ;
         T00014_n15Parentesco = new bool[] {false} ;
         T00014_A16Cemiterio = new int[1] ;
         T00014_n16Cemiterio = new bool[] {false} ;
         T00014_A17Jazigo = new int[1] ;
         T00014_n17Jazigo = new bool[] {false} ;
         T00014_A18Quadra = new int[1] ;
         T00014_n18Quadra = new bool[] {false} ;
         T00014_A19Lote = new int[1] ;
         T00014_n19Lote = new bool[] {false} ;
         T00014_A20SeqDependente = new int[1] ;
         T00014_n20SeqDependente = new bool[] {false} ;
         T00014_A21Capela = new int[1] ;
         T00014_n21Capela = new bool[] {false} ;
         T00014_A22EnderecoFalecido = new string[] {""} ;
         T00014_n22EnderecoFalecido = new bool[] {false} ;
         T00014_A23horafalecimento = new string[] {""} ;
         T00014_n23horafalecimento = new bool[] {false} ;
         T00014_A24CidadeFalecimento = new int[1] ;
         T00014_n24CidadeFalecimento = new bool[] {false} ;
         T00014_A25LocalFalecimento = new string[] {""} ;
         T00014_n25LocalFalecimento = new bool[] {false} ;
         T00014_A26HoraSepultamento = new string[] {""} ;
         T00014_n26HoraSepultamento = new bool[] {false} ;
         T00014_A27DatasolicitacaoAux = new DateTime[] {DateTime.MinValue} ;
         T00014_n27DatasolicitacaoAux = new bool[] {false} ;
         T00014_A28NomeContratanteAux = new string[] {""} ;
         T00014_n28NomeContratanteAux = new bool[] {false} ;
         T00014_A29EndContratanteAux = new string[] {""} ;
         T00014_n29EndContratanteAux = new bool[] {false} ;
         T00014_A30CidadeContratanteAux = new int[1] ;
         T00014_n30CidadeContratanteAux = new bool[] {false} ;
         T00014_A31RGContratanteAux = new string[] {""} ;
         T00014_n31RGContratanteAux = new bool[] {false} ;
         T00014_A32CPFContratanteAux = new string[] {""} ;
         T00014_n32CPFContratanteAux = new bool[] {false} ;
         T00014_A33EstCivilContratanteAux = new int[1] ;
         T00014_n33EstCivilContratanteAux = new bool[] {false} ;
         T00014_A34DataInsert = new DateTime[] {DateTime.MinValue} ;
         T00014_n34DataInsert = new bool[] {false} ;
         T00014_A35UsuInsert = new int[1] ;
         T00014_n35UsuInsert = new bool[] {false} ;
         T00014_A36DataUpdate = new DateTime[] {DateTime.MinValue} ;
         T00014_n36DataUpdate = new bool[] {false} ;
         T00014_A37UsuUpdate = new int[1] ;
         T00014_n37UsuUpdate = new bool[] {false} ;
         T00014_A38NumControleAux = new int[1] ;
         T00014_n38NumControleAux = new bool[] {false} ;
         T00014_A39ValorAux = new decimal[1] ;
         T00014_n39ValorAux = new bool[] {false} ;
         T00014_A40DataPagtoAux = new DateTime[] {DateTime.MinValue} ;
         T00014_n40DataPagtoAux = new bool[] {false} ;
         T00014_A41ObservacaoAux = new string[] {""} ;
         T00014_n41ObservacaoAux = new bool[] {false} ;
         T00014_A42EmCarencia = new string[] {""} ;
         T00014_n42EmCarencia = new bool[] {false} ;
         T00014_A43PercentualCobertura = new decimal[1] ;
         T00014_n43PercentualCobertura = new bool[] {false} ;
         T00014_A44PacienteUnesp = new string[] {""} ;
         T00014_n44PacienteUnesp = new bool[] {false} ;
         T00014_A45RegistroUnesp = new string[] {""} ;
         T00014_n45RegistroUnesp = new bool[] {false} ;
         T00014_A46RelatoObito = new string[] {""} ;
         T00014_n46RelatoObito = new bool[] {false} ;
         T00014_A47ViciosHabituais = new string[] {""} ;
         T00014_n47ViciosHabituais = new bool[] {false} ;
         T00014_A48ViciosEspecificar = new string[] {""} ;
         T00014_n48ViciosEspecificar = new bool[] {false} ;
         T00014_A49DoencasConhecidas = new string[] {""} ;
         T00014_n49DoencasConhecidas = new bool[] {false} ;
         T00014_A50TaxaCapelaAux = new decimal[1] ;
         T00014_n50TaxaCapelaAux = new bool[] {false} ;
         T00014_A51TaxaSepultamento = new decimal[1] ;
         T00014_n51TaxaSepultamento = new bool[] {false} ;
         T00014_A52Matricula = new string[] {""} ;
         T00014_n52Matricula = new bool[] {false} ;
         T00014_A53UsouCremacao = new string[] {""} ;
         T00014_n53UsouCremacao = new bool[] {false} ;
         T00014_A54Seq = new int[1] ;
         T00014_n54Seq = new bool[] {false} ;
         T00015_A1Inscricao = new int[1] ;
         T00015_A2Nome = new string[] {""} ;
         T00013_A1Inscricao = new int[1] ;
         T00013_A2Nome = new string[] {""} ;
         T00013_A3Grupo = new string[] {""} ;
         T00013_n3Grupo = new bool[] {false} ;
         T00013_A4Referencia = new string[] {""} ;
         T00013_n4Referencia = new bool[] {false} ;
         T00013_A5Numero = new int[1] ;
         T00013_n5Numero = new bool[] {false} ;
         T00013_A6Valor = new decimal[1] ;
         T00013_n6Valor = new bool[] {false} ;
         T00013_A7Vencimento = new DateTime[] {DateTime.MinValue} ;
         T00013_n7Vencimento = new bool[] {false} ;
         T00013_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         T00013_n8Nascimento = new bool[] {false} ;
         T00013_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         T00013_n9Falecimento = new bool[] {false} ;
         T00013_A10NumeroObito = new string[] {""} ;
         T00013_n10NumeroObito = new bool[] {false} ;
         T00013_A11NFNumero = new string[] {""} ;
         T00013_n11NFNumero = new bool[] {false} ;
         T00013_A12NFValor = new decimal[1] ;
         T00013_n12NFValor = new bool[] {false} ;
         T00013_A13Funeraria = new string[] {""} ;
         T00013_n13Funeraria = new bool[] {false} ;
         T00013_A14Observacao = new string[] {""} ;
         T00013_n14Observacao = new bool[] {false} ;
         T00013_A15Parentesco = new string[] {""} ;
         T00013_n15Parentesco = new bool[] {false} ;
         T00013_A16Cemiterio = new int[1] ;
         T00013_n16Cemiterio = new bool[] {false} ;
         T00013_A17Jazigo = new int[1] ;
         T00013_n17Jazigo = new bool[] {false} ;
         T00013_A18Quadra = new int[1] ;
         T00013_n18Quadra = new bool[] {false} ;
         T00013_A19Lote = new int[1] ;
         T00013_n19Lote = new bool[] {false} ;
         T00013_A20SeqDependente = new int[1] ;
         T00013_n20SeqDependente = new bool[] {false} ;
         T00013_A21Capela = new int[1] ;
         T00013_n21Capela = new bool[] {false} ;
         T00013_A22EnderecoFalecido = new string[] {""} ;
         T00013_n22EnderecoFalecido = new bool[] {false} ;
         T00013_A23horafalecimento = new string[] {""} ;
         T00013_n23horafalecimento = new bool[] {false} ;
         T00013_A24CidadeFalecimento = new int[1] ;
         T00013_n24CidadeFalecimento = new bool[] {false} ;
         T00013_A25LocalFalecimento = new string[] {""} ;
         T00013_n25LocalFalecimento = new bool[] {false} ;
         T00013_A26HoraSepultamento = new string[] {""} ;
         T00013_n26HoraSepultamento = new bool[] {false} ;
         T00013_A27DatasolicitacaoAux = new DateTime[] {DateTime.MinValue} ;
         T00013_n27DatasolicitacaoAux = new bool[] {false} ;
         T00013_A28NomeContratanteAux = new string[] {""} ;
         T00013_n28NomeContratanteAux = new bool[] {false} ;
         T00013_A29EndContratanteAux = new string[] {""} ;
         T00013_n29EndContratanteAux = new bool[] {false} ;
         T00013_A30CidadeContratanteAux = new int[1] ;
         T00013_n30CidadeContratanteAux = new bool[] {false} ;
         T00013_A31RGContratanteAux = new string[] {""} ;
         T00013_n31RGContratanteAux = new bool[] {false} ;
         T00013_A32CPFContratanteAux = new string[] {""} ;
         T00013_n32CPFContratanteAux = new bool[] {false} ;
         T00013_A33EstCivilContratanteAux = new int[1] ;
         T00013_n33EstCivilContratanteAux = new bool[] {false} ;
         T00013_A34DataInsert = new DateTime[] {DateTime.MinValue} ;
         T00013_n34DataInsert = new bool[] {false} ;
         T00013_A35UsuInsert = new int[1] ;
         T00013_n35UsuInsert = new bool[] {false} ;
         T00013_A36DataUpdate = new DateTime[] {DateTime.MinValue} ;
         T00013_n36DataUpdate = new bool[] {false} ;
         T00013_A37UsuUpdate = new int[1] ;
         T00013_n37UsuUpdate = new bool[] {false} ;
         T00013_A38NumControleAux = new int[1] ;
         T00013_n38NumControleAux = new bool[] {false} ;
         T00013_A39ValorAux = new decimal[1] ;
         T00013_n39ValorAux = new bool[] {false} ;
         T00013_A40DataPagtoAux = new DateTime[] {DateTime.MinValue} ;
         T00013_n40DataPagtoAux = new bool[] {false} ;
         T00013_A41ObservacaoAux = new string[] {""} ;
         T00013_n41ObservacaoAux = new bool[] {false} ;
         T00013_A42EmCarencia = new string[] {""} ;
         T00013_n42EmCarencia = new bool[] {false} ;
         T00013_A43PercentualCobertura = new decimal[1] ;
         T00013_n43PercentualCobertura = new bool[] {false} ;
         T00013_A44PacienteUnesp = new string[] {""} ;
         T00013_n44PacienteUnesp = new bool[] {false} ;
         T00013_A45RegistroUnesp = new string[] {""} ;
         T00013_n45RegistroUnesp = new bool[] {false} ;
         T00013_A46RelatoObito = new string[] {""} ;
         T00013_n46RelatoObito = new bool[] {false} ;
         T00013_A47ViciosHabituais = new string[] {""} ;
         T00013_n47ViciosHabituais = new bool[] {false} ;
         T00013_A48ViciosEspecificar = new string[] {""} ;
         T00013_n48ViciosEspecificar = new bool[] {false} ;
         T00013_A49DoencasConhecidas = new string[] {""} ;
         T00013_n49DoencasConhecidas = new bool[] {false} ;
         T00013_A50TaxaCapelaAux = new decimal[1] ;
         T00013_n50TaxaCapelaAux = new bool[] {false} ;
         T00013_A51TaxaSepultamento = new decimal[1] ;
         T00013_n51TaxaSepultamento = new bool[] {false} ;
         T00013_A52Matricula = new string[] {""} ;
         T00013_n52Matricula = new bool[] {false} ;
         T00013_A53UsouCremacao = new string[] {""} ;
         T00013_n53UsouCremacao = new bool[] {false} ;
         T00013_A54Seq = new int[1] ;
         T00013_n54Seq = new bool[] {false} ;
         T00016_A1Inscricao = new int[1] ;
         T00016_A2Nome = new string[] {""} ;
         T00017_A1Inscricao = new int[1] ;
         T00017_A2Nome = new string[] {""} ;
         T00012_A1Inscricao = new int[1] ;
         T00012_A2Nome = new string[] {""} ;
         T00012_A3Grupo = new string[] {""} ;
         T00012_n3Grupo = new bool[] {false} ;
         T00012_A4Referencia = new string[] {""} ;
         T00012_n4Referencia = new bool[] {false} ;
         T00012_A5Numero = new int[1] ;
         T00012_n5Numero = new bool[] {false} ;
         T00012_A6Valor = new decimal[1] ;
         T00012_n6Valor = new bool[] {false} ;
         T00012_A7Vencimento = new DateTime[] {DateTime.MinValue} ;
         T00012_n7Vencimento = new bool[] {false} ;
         T00012_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         T00012_n8Nascimento = new bool[] {false} ;
         T00012_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         T00012_n9Falecimento = new bool[] {false} ;
         T00012_A10NumeroObito = new string[] {""} ;
         T00012_n10NumeroObito = new bool[] {false} ;
         T00012_A11NFNumero = new string[] {""} ;
         T00012_n11NFNumero = new bool[] {false} ;
         T00012_A12NFValor = new decimal[1] ;
         T00012_n12NFValor = new bool[] {false} ;
         T00012_A13Funeraria = new string[] {""} ;
         T00012_n13Funeraria = new bool[] {false} ;
         T00012_A14Observacao = new string[] {""} ;
         T00012_n14Observacao = new bool[] {false} ;
         T00012_A15Parentesco = new string[] {""} ;
         T00012_n15Parentesco = new bool[] {false} ;
         T00012_A16Cemiterio = new int[1] ;
         T00012_n16Cemiterio = new bool[] {false} ;
         T00012_A17Jazigo = new int[1] ;
         T00012_n17Jazigo = new bool[] {false} ;
         T00012_A18Quadra = new int[1] ;
         T00012_n18Quadra = new bool[] {false} ;
         T00012_A19Lote = new int[1] ;
         T00012_n19Lote = new bool[] {false} ;
         T00012_A20SeqDependente = new int[1] ;
         T00012_n20SeqDependente = new bool[] {false} ;
         T00012_A21Capela = new int[1] ;
         T00012_n21Capela = new bool[] {false} ;
         T00012_A22EnderecoFalecido = new string[] {""} ;
         T00012_n22EnderecoFalecido = new bool[] {false} ;
         T00012_A23horafalecimento = new string[] {""} ;
         T00012_n23horafalecimento = new bool[] {false} ;
         T00012_A24CidadeFalecimento = new int[1] ;
         T00012_n24CidadeFalecimento = new bool[] {false} ;
         T00012_A25LocalFalecimento = new string[] {""} ;
         T00012_n25LocalFalecimento = new bool[] {false} ;
         T00012_A26HoraSepultamento = new string[] {""} ;
         T00012_n26HoraSepultamento = new bool[] {false} ;
         T00012_A27DatasolicitacaoAux = new DateTime[] {DateTime.MinValue} ;
         T00012_n27DatasolicitacaoAux = new bool[] {false} ;
         T00012_A28NomeContratanteAux = new string[] {""} ;
         T00012_n28NomeContratanteAux = new bool[] {false} ;
         T00012_A29EndContratanteAux = new string[] {""} ;
         T00012_n29EndContratanteAux = new bool[] {false} ;
         T00012_A30CidadeContratanteAux = new int[1] ;
         T00012_n30CidadeContratanteAux = new bool[] {false} ;
         T00012_A31RGContratanteAux = new string[] {""} ;
         T00012_n31RGContratanteAux = new bool[] {false} ;
         T00012_A32CPFContratanteAux = new string[] {""} ;
         T00012_n32CPFContratanteAux = new bool[] {false} ;
         T00012_A33EstCivilContratanteAux = new int[1] ;
         T00012_n33EstCivilContratanteAux = new bool[] {false} ;
         T00012_A34DataInsert = new DateTime[] {DateTime.MinValue} ;
         T00012_n34DataInsert = new bool[] {false} ;
         T00012_A35UsuInsert = new int[1] ;
         T00012_n35UsuInsert = new bool[] {false} ;
         T00012_A36DataUpdate = new DateTime[] {DateTime.MinValue} ;
         T00012_n36DataUpdate = new bool[] {false} ;
         T00012_A37UsuUpdate = new int[1] ;
         T00012_n37UsuUpdate = new bool[] {false} ;
         T00012_A38NumControleAux = new int[1] ;
         T00012_n38NumControleAux = new bool[] {false} ;
         T00012_A39ValorAux = new decimal[1] ;
         T00012_n39ValorAux = new bool[] {false} ;
         T00012_A40DataPagtoAux = new DateTime[] {DateTime.MinValue} ;
         T00012_n40DataPagtoAux = new bool[] {false} ;
         T00012_A41ObservacaoAux = new string[] {""} ;
         T00012_n41ObservacaoAux = new bool[] {false} ;
         T00012_A42EmCarencia = new string[] {""} ;
         T00012_n42EmCarencia = new bool[] {false} ;
         T00012_A43PercentualCobertura = new decimal[1] ;
         T00012_n43PercentualCobertura = new bool[] {false} ;
         T00012_A44PacienteUnesp = new string[] {""} ;
         T00012_n44PacienteUnesp = new bool[] {false} ;
         T00012_A45RegistroUnesp = new string[] {""} ;
         T00012_n45RegistroUnesp = new bool[] {false} ;
         T00012_A46RelatoObito = new string[] {""} ;
         T00012_n46RelatoObito = new bool[] {false} ;
         T00012_A47ViciosHabituais = new string[] {""} ;
         T00012_n47ViciosHabituais = new bool[] {false} ;
         T00012_A48ViciosEspecificar = new string[] {""} ;
         T00012_n48ViciosEspecificar = new bool[] {false} ;
         T00012_A49DoencasConhecidas = new string[] {""} ;
         T00012_n49DoencasConhecidas = new bool[] {false} ;
         T00012_A50TaxaCapelaAux = new decimal[1] ;
         T00012_n50TaxaCapelaAux = new bool[] {false} ;
         T00012_A51TaxaSepultamento = new decimal[1] ;
         T00012_n51TaxaSepultamento = new bool[] {false} ;
         T00012_A52Matricula = new string[] {""} ;
         T00012_n52Matricula = new bool[] {false} ;
         T00012_A53UsouCremacao = new string[] {""} ;
         T00012_n53UsouCremacao = new bool[] {false} ;
         T00012_A54Seq = new int[1] ;
         T00012_n54Seq = new bool[] {false} ;
         T000111_A1Inscricao = new int[1] ;
         T000111_A2Nome = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.obitos__datastore1(),
            new Object[][] {
                new Object[] {
               T00012_A1Inscricao, T00012_A2Nome, T00012_A3Grupo, T00012_n3Grupo, T00012_A4Referencia, T00012_n4Referencia, T00012_A5Numero, T00012_n5Numero, T00012_A6Valor, T00012_n6Valor,
               T00012_A7Vencimento, T00012_n7Vencimento, T00012_A8Nascimento, T00012_n8Nascimento, T00012_A9Falecimento, T00012_n9Falecimento, T00012_A10NumeroObito, T00012_n10NumeroObito, T00012_A11NFNumero, T00012_n11NFNumero,
               T00012_A12NFValor, T00012_n12NFValor, T00012_A13Funeraria, T00012_n13Funeraria, T00012_A14Observacao, T00012_n14Observacao, T00012_A15Parentesco, T00012_n15Parentesco, T00012_A16Cemiterio, T00012_n16Cemiterio,
               T00012_A17Jazigo, T00012_n17Jazigo, T00012_A18Quadra, T00012_n18Quadra, T00012_A19Lote, T00012_n19Lote, T00012_A20SeqDependente, T00012_n20SeqDependente, T00012_A21Capela, T00012_n21Capela,
               T00012_A22EnderecoFalecido, T00012_n22EnderecoFalecido, T00012_A23horafalecimento, T00012_n23horafalecimento, T00012_A24CidadeFalecimento, T00012_n24CidadeFalecimento, T00012_A25LocalFalecimento, T00012_n25LocalFalecimento, T00012_A26HoraSepultamento, T00012_n26HoraSepultamento,
               T00012_A27DatasolicitacaoAux, T00012_n27DatasolicitacaoAux, T00012_A28NomeContratanteAux, T00012_n28NomeContratanteAux, T00012_A29EndContratanteAux, T00012_n29EndContratanteAux, T00012_A30CidadeContratanteAux, T00012_n30CidadeContratanteAux, T00012_A31RGContratanteAux, T00012_n31RGContratanteAux,
               T00012_A32CPFContratanteAux, T00012_n32CPFContratanteAux, T00012_A33EstCivilContratanteAux, T00012_n33EstCivilContratanteAux, T00012_A34DataInsert, T00012_n34DataInsert, T00012_A35UsuInsert, T00012_n35UsuInsert, T00012_A36DataUpdate, T00012_n36DataUpdate,
               T00012_A37UsuUpdate, T00012_n37UsuUpdate, T00012_A38NumControleAux, T00012_n38NumControleAux, T00012_A39ValorAux, T00012_n39ValorAux, T00012_A40DataPagtoAux, T00012_n40DataPagtoAux, T00012_A41ObservacaoAux, T00012_n41ObservacaoAux,
               T00012_A42EmCarencia, T00012_n42EmCarencia, T00012_A43PercentualCobertura, T00012_n43PercentualCobertura, T00012_A44PacienteUnesp, T00012_n44PacienteUnesp, T00012_A45RegistroUnesp, T00012_n45RegistroUnesp, T00012_A46RelatoObito, T00012_n46RelatoObito,
               T00012_A47ViciosHabituais, T00012_n47ViciosHabituais, T00012_A48ViciosEspecificar, T00012_n48ViciosEspecificar, T00012_A49DoencasConhecidas, T00012_n49DoencasConhecidas, T00012_A50TaxaCapelaAux, T00012_n50TaxaCapelaAux, T00012_A51TaxaSepultamento, T00012_n51TaxaSepultamento,
               T00012_A52Matricula, T00012_n52Matricula, T00012_A53UsouCremacao, T00012_n53UsouCremacao, T00012_A54Seq, T00012_n54Seq
               }
               , new Object[] {
               T00013_A1Inscricao, T00013_A2Nome, T00013_A3Grupo, T00013_n3Grupo, T00013_A4Referencia, T00013_n4Referencia, T00013_A5Numero, T00013_n5Numero, T00013_A6Valor, T00013_n6Valor,
               T00013_A7Vencimento, T00013_n7Vencimento, T00013_A8Nascimento, T00013_n8Nascimento, T00013_A9Falecimento, T00013_n9Falecimento, T00013_A10NumeroObito, T00013_n10NumeroObito, T00013_A11NFNumero, T00013_n11NFNumero,
               T00013_A12NFValor, T00013_n12NFValor, T00013_A13Funeraria, T00013_n13Funeraria, T00013_A14Observacao, T00013_n14Observacao, T00013_A15Parentesco, T00013_n15Parentesco, T00013_A16Cemiterio, T00013_n16Cemiterio,
               T00013_A17Jazigo, T00013_n17Jazigo, T00013_A18Quadra, T00013_n18Quadra, T00013_A19Lote, T00013_n19Lote, T00013_A20SeqDependente, T00013_n20SeqDependente, T00013_A21Capela, T00013_n21Capela,
               T00013_A22EnderecoFalecido, T00013_n22EnderecoFalecido, T00013_A23horafalecimento, T00013_n23horafalecimento, T00013_A24CidadeFalecimento, T00013_n24CidadeFalecimento, T00013_A25LocalFalecimento, T00013_n25LocalFalecimento, T00013_A26HoraSepultamento, T00013_n26HoraSepultamento,
               T00013_A27DatasolicitacaoAux, T00013_n27DatasolicitacaoAux, T00013_A28NomeContratanteAux, T00013_n28NomeContratanteAux, T00013_A29EndContratanteAux, T00013_n29EndContratanteAux, T00013_A30CidadeContratanteAux, T00013_n30CidadeContratanteAux, T00013_A31RGContratanteAux, T00013_n31RGContratanteAux,
               T00013_A32CPFContratanteAux, T00013_n32CPFContratanteAux, T00013_A33EstCivilContratanteAux, T00013_n33EstCivilContratanteAux, T00013_A34DataInsert, T00013_n34DataInsert, T00013_A35UsuInsert, T00013_n35UsuInsert, T00013_A36DataUpdate, T00013_n36DataUpdate,
               T00013_A37UsuUpdate, T00013_n37UsuUpdate, T00013_A38NumControleAux, T00013_n38NumControleAux, T00013_A39ValorAux, T00013_n39ValorAux, T00013_A40DataPagtoAux, T00013_n40DataPagtoAux, T00013_A41ObservacaoAux, T00013_n41ObservacaoAux,
               T00013_A42EmCarencia, T00013_n42EmCarencia, T00013_A43PercentualCobertura, T00013_n43PercentualCobertura, T00013_A44PacienteUnesp, T00013_n44PacienteUnesp, T00013_A45RegistroUnesp, T00013_n45RegistroUnesp, T00013_A46RelatoObito, T00013_n46RelatoObito,
               T00013_A47ViciosHabituais, T00013_n47ViciosHabituais, T00013_A48ViciosEspecificar, T00013_n48ViciosEspecificar, T00013_A49DoencasConhecidas, T00013_n49DoencasConhecidas, T00013_A50TaxaCapelaAux, T00013_n50TaxaCapelaAux, T00013_A51TaxaSepultamento, T00013_n51TaxaSepultamento,
               T00013_A52Matricula, T00013_n52Matricula, T00013_A53UsouCremacao, T00013_n53UsouCremacao, T00013_A54Seq, T00013_n54Seq
               }
               , new Object[] {
               T00014_A1Inscricao, T00014_A2Nome, T00014_A3Grupo, T00014_n3Grupo, T00014_A4Referencia, T00014_n4Referencia, T00014_A5Numero, T00014_n5Numero, T00014_A6Valor, T00014_n6Valor,
               T00014_A7Vencimento, T00014_n7Vencimento, T00014_A8Nascimento, T00014_n8Nascimento, T00014_A9Falecimento, T00014_n9Falecimento, T00014_A10NumeroObito, T00014_n10NumeroObito, T00014_A11NFNumero, T00014_n11NFNumero,
               T00014_A12NFValor, T00014_n12NFValor, T00014_A13Funeraria, T00014_n13Funeraria, T00014_A14Observacao, T00014_n14Observacao, T00014_A15Parentesco, T00014_n15Parentesco, T00014_A16Cemiterio, T00014_n16Cemiterio,
               T00014_A17Jazigo, T00014_n17Jazigo, T00014_A18Quadra, T00014_n18Quadra, T00014_A19Lote, T00014_n19Lote, T00014_A20SeqDependente, T00014_n20SeqDependente, T00014_A21Capela, T00014_n21Capela,
               T00014_A22EnderecoFalecido, T00014_n22EnderecoFalecido, T00014_A23horafalecimento, T00014_n23horafalecimento, T00014_A24CidadeFalecimento, T00014_n24CidadeFalecimento, T00014_A25LocalFalecimento, T00014_n25LocalFalecimento, T00014_A26HoraSepultamento, T00014_n26HoraSepultamento,
               T00014_A27DatasolicitacaoAux, T00014_n27DatasolicitacaoAux, T00014_A28NomeContratanteAux, T00014_n28NomeContratanteAux, T00014_A29EndContratanteAux, T00014_n29EndContratanteAux, T00014_A30CidadeContratanteAux, T00014_n30CidadeContratanteAux, T00014_A31RGContratanteAux, T00014_n31RGContratanteAux,
               T00014_A32CPFContratanteAux, T00014_n32CPFContratanteAux, T00014_A33EstCivilContratanteAux, T00014_n33EstCivilContratanteAux, T00014_A34DataInsert, T00014_n34DataInsert, T00014_A35UsuInsert, T00014_n35UsuInsert, T00014_A36DataUpdate, T00014_n36DataUpdate,
               T00014_A37UsuUpdate, T00014_n37UsuUpdate, T00014_A38NumControleAux, T00014_n38NumControleAux, T00014_A39ValorAux, T00014_n39ValorAux, T00014_A40DataPagtoAux, T00014_n40DataPagtoAux, T00014_A41ObservacaoAux, T00014_n41ObservacaoAux,
               T00014_A42EmCarencia, T00014_n42EmCarencia, T00014_A43PercentualCobertura, T00014_n43PercentualCobertura, T00014_A44PacienteUnesp, T00014_n44PacienteUnesp, T00014_A45RegistroUnesp, T00014_n45RegistroUnesp, T00014_A46RelatoObito, T00014_n46RelatoObito,
               T00014_A47ViciosHabituais, T00014_n47ViciosHabituais, T00014_A48ViciosEspecificar, T00014_n48ViciosEspecificar, T00014_A49DoencasConhecidas, T00014_n49DoencasConhecidas, T00014_A50TaxaCapelaAux, T00014_n50TaxaCapelaAux, T00014_A51TaxaSepultamento, T00014_n51TaxaSepultamento,
               T00014_A52Matricula, T00014_n52Matricula, T00014_A53UsouCremacao, T00014_n53UsouCremacao, T00014_A54Seq, T00014_n54Seq
               }
               , new Object[] {
               T00015_A1Inscricao, T00015_A2Nome
               }
               , new Object[] {
               T00016_A1Inscricao, T00016_A2Nome
               }
               , new Object[] {
               T00017_A1Inscricao, T00017_A2Nome
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000111_A1Inscricao, T000111_A2Nome
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obitos__default(),
            new Object[][] {
            }
         );
         AV12Pgmname = "Obitos";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7Inscricao ;
      private int Z1Inscricao ;
      private int Z5Numero ;
      private int Z16Cemiterio ;
      private int Z17Jazigo ;
      private int Z18Quadra ;
      private int Z19Lote ;
      private int Z20SeqDependente ;
      private int Z21Capela ;
      private int Z24CidadeFalecimento ;
      private int Z30CidadeContratanteAux ;
      private int Z33EstCivilContratanteAux ;
      private int Z35UsuInsert ;
      private int Z37UsuUpdate ;
      private int Z38NumControleAux ;
      private int Z54Seq ;
      private int AV7Inscricao ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A1Inscricao ;
      private int edtInscricao_Enabled ;
      private int edtNome_Enabled ;
      private int edtGrupo_Enabled ;
      private int edtReferencia_Enabled ;
      private int A5Numero ;
      private int edtNumero_Enabled ;
      private int edtValor_Enabled ;
      private int edtVencimento_Enabled ;
      private int edtNascimento_Enabled ;
      private int edtFalecimento_Enabled ;
      private int edtNumeroObito_Enabled ;
      private int edtNFNumero_Enabled ;
      private int edtNFValor_Enabled ;
      private int edtFuneraria_Enabled ;
      private int edtObservacao_Enabled ;
      private int edtParentesco_Enabled ;
      private int A16Cemiterio ;
      private int edtCemiterio_Enabled ;
      private int A17Jazigo ;
      private int edtJazigo_Enabled ;
      private int A18Quadra ;
      private int edtQuadra_Enabled ;
      private int A19Lote ;
      private int edtLote_Enabled ;
      private int A20SeqDependente ;
      private int edtSeqDependente_Enabled ;
      private int A21Capela ;
      private int edtCapela_Enabled ;
      private int edtEnderecoFalecido_Enabled ;
      private int edthorafalecimento_Enabled ;
      private int A24CidadeFalecimento ;
      private int edtCidadeFalecimento_Enabled ;
      private int edtLocalFalecimento_Enabled ;
      private int edtHoraSepultamento_Enabled ;
      private int edtDatasolicitacaoAux_Enabled ;
      private int edtNomeContratanteAux_Enabled ;
      private int edtEndContratanteAux_Enabled ;
      private int A30CidadeContratanteAux ;
      private int edtCidadeContratanteAux_Enabled ;
      private int edtRGContratanteAux_Enabled ;
      private int edtCPFContratanteAux_Enabled ;
      private int A33EstCivilContratanteAux ;
      private int edtEstCivilContratanteAux_Enabled ;
      private int edtDataInsert_Enabled ;
      private int A35UsuInsert ;
      private int edtUsuInsert_Enabled ;
      private int edtDataUpdate_Enabled ;
      private int A37UsuUpdate ;
      private int edtUsuUpdate_Enabled ;
      private int A38NumControleAux ;
      private int edtNumControleAux_Enabled ;
      private int edtValorAux_Enabled ;
      private int edtDataPagtoAux_Enabled ;
      private int edtObservacaoAux_Enabled ;
      private int edtEmCarencia_Enabled ;
      private int edtPercentualCobertura_Enabled ;
      private int edtPacienteUnesp_Enabled ;
      private int edtRegistroUnesp_Enabled ;
      private int edtRelatoObito_Enabled ;
      private int edtViciosHabituais_Enabled ;
      private int edtViciosEspecificar_Enabled ;
      private int edtDoencasConhecidas_Enabled ;
      private int edtTaxaCapelaAux_Enabled ;
      private int edtTaxaSepultamento_Enabled ;
      private int edtMatricula_Enabled ;
      private int edtUsouCremacao_Enabled ;
      private int A54Seq ;
      private int edtSeq_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z6Valor ;
      private decimal Z12NFValor ;
      private decimal Z39ValorAux ;
      private decimal Z43PercentualCobertura ;
      private decimal Z50TaxaCapelaAux ;
      private decimal Z51TaxaSepultamento ;
      private decimal A6Valor ;
      private decimal A12NFValor ;
      private decimal A39ValorAux ;
      private decimal A43PercentualCobertura ;
      private decimal A50TaxaCapelaAux ;
      private decimal A51TaxaSepultamento ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z3Grupo ;
      private string Z4Referencia ;
      private string Z13Funeraria ;
      private string Z15Parentesco ;
      private string Z42EmCarencia ;
      private string Z44PacienteUnesp ;
      private string Z47ViciosHabituais ;
      private string Z53UsouCremacao ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtInscricao_Internalname ;
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
      private string edtInscricao_Jsonclick ;
      private string edtNome_Internalname ;
      private string edtNome_Jsonclick ;
      private string edtGrupo_Internalname ;
      private string A3Grupo ;
      private string edtGrupo_Jsonclick ;
      private string edtReferencia_Internalname ;
      private string A4Referencia ;
      private string edtReferencia_Jsonclick ;
      private string edtNumero_Internalname ;
      private string edtNumero_Jsonclick ;
      private string edtValor_Internalname ;
      private string edtValor_Jsonclick ;
      private string edtVencimento_Internalname ;
      private string edtVencimento_Jsonclick ;
      private string edtNascimento_Internalname ;
      private string edtNascimento_Jsonclick ;
      private string edtFalecimento_Internalname ;
      private string edtFalecimento_Jsonclick ;
      private string edtNumeroObito_Internalname ;
      private string edtNumeroObito_Jsonclick ;
      private string edtNFNumero_Internalname ;
      private string edtNFNumero_Jsonclick ;
      private string edtNFValor_Internalname ;
      private string edtNFValor_Jsonclick ;
      private string edtFuneraria_Internalname ;
      private string A13Funeraria ;
      private string edtFuneraria_Jsonclick ;
      private string edtObservacao_Internalname ;
      private string edtObservacao_Jsonclick ;
      private string edtParentesco_Internalname ;
      private string A15Parentesco ;
      private string edtParentesco_Jsonclick ;
      private string edtCemiterio_Internalname ;
      private string edtCemiterio_Jsonclick ;
      private string edtJazigo_Internalname ;
      private string edtJazigo_Jsonclick ;
      private string edtQuadra_Internalname ;
      private string edtQuadra_Jsonclick ;
      private string edtLote_Internalname ;
      private string edtLote_Jsonclick ;
      private string edtSeqDependente_Internalname ;
      private string edtSeqDependente_Jsonclick ;
      private string edtCapela_Internalname ;
      private string edtCapela_Jsonclick ;
      private string edtEnderecoFalecido_Internalname ;
      private string edtEnderecoFalecido_Jsonclick ;
      private string edthorafalecimento_Internalname ;
      private string edthorafalecimento_Jsonclick ;
      private string edtCidadeFalecimento_Internalname ;
      private string edtCidadeFalecimento_Jsonclick ;
      private string edtLocalFalecimento_Internalname ;
      private string edtLocalFalecimento_Jsonclick ;
      private string edtHoraSepultamento_Internalname ;
      private string edtHoraSepultamento_Jsonclick ;
      private string edtDatasolicitacaoAux_Internalname ;
      private string edtDatasolicitacaoAux_Jsonclick ;
      private string edtNomeContratanteAux_Internalname ;
      private string edtNomeContratanteAux_Jsonclick ;
      private string edtEndContratanteAux_Internalname ;
      private string edtEndContratanteAux_Jsonclick ;
      private string edtCidadeContratanteAux_Internalname ;
      private string edtCidadeContratanteAux_Jsonclick ;
      private string edtRGContratanteAux_Internalname ;
      private string edtRGContratanteAux_Jsonclick ;
      private string edtCPFContratanteAux_Internalname ;
      private string edtCPFContratanteAux_Jsonclick ;
      private string edtEstCivilContratanteAux_Internalname ;
      private string edtEstCivilContratanteAux_Jsonclick ;
      private string edtDataInsert_Internalname ;
      private string edtDataInsert_Jsonclick ;
      private string edtUsuInsert_Internalname ;
      private string edtUsuInsert_Jsonclick ;
      private string edtDataUpdate_Internalname ;
      private string edtDataUpdate_Jsonclick ;
      private string edtUsuUpdate_Internalname ;
      private string edtUsuUpdate_Jsonclick ;
      private string edtNumControleAux_Internalname ;
      private string edtNumControleAux_Jsonclick ;
      private string edtValorAux_Internalname ;
      private string edtValorAux_Jsonclick ;
      private string edtDataPagtoAux_Internalname ;
      private string edtDataPagtoAux_Jsonclick ;
      private string edtObservacaoAux_Internalname ;
      private string edtEmCarencia_Internalname ;
      private string A42EmCarencia ;
      private string edtEmCarencia_Jsonclick ;
      private string edtPercentualCobertura_Internalname ;
      private string edtPercentualCobertura_Jsonclick ;
      private string edtPacienteUnesp_Internalname ;
      private string A44PacienteUnesp ;
      private string edtPacienteUnesp_Jsonclick ;
      private string edtRegistroUnesp_Internalname ;
      private string edtRegistroUnesp_Jsonclick ;
      private string edtRelatoObito_Internalname ;
      private string edtRelatoObito_Jsonclick ;
      private string edtViciosHabituais_Internalname ;
      private string A47ViciosHabituais ;
      private string edtViciosHabituais_Jsonclick ;
      private string edtViciosEspecificar_Internalname ;
      private string edtViciosEspecificar_Jsonclick ;
      private string edtDoencasConhecidas_Internalname ;
      private string edtDoencasConhecidas_Jsonclick ;
      private string edtTaxaCapelaAux_Internalname ;
      private string edtTaxaCapelaAux_Jsonclick ;
      private string edtTaxaSepultamento_Internalname ;
      private string edtTaxaSepultamento_Jsonclick ;
      private string edtMatricula_Internalname ;
      private string edtMatricula_Jsonclick ;
      private string edtUsouCremacao_Internalname ;
      private string A53UsouCremacao ;
      private string edtUsouCremacao_Jsonclick ;
      private string edtSeq_Internalname ;
      private string edtSeq_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV12Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z7Vencimento ;
      private DateTime Z8Nascimento ;
      private DateTime Z9Falecimento ;
      private DateTime Z27DatasolicitacaoAux ;
      private DateTime Z34DataInsert ;
      private DateTime Z36DataUpdate ;
      private DateTime Z40DataPagtoAux ;
      private DateTime A7Vencimento ;
      private DateTime A8Nascimento ;
      private DateTime A9Falecimento ;
      private DateTime A27DatasolicitacaoAux ;
      private DateTime A34DataInsert ;
      private DateTime A36DataUpdate ;
      private DateTime A40DataPagtoAux ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n3Grupo ;
      private bool n4Referencia ;
      private bool n5Numero ;
      private bool n6Valor ;
      private bool n7Vencimento ;
      private bool n8Nascimento ;
      private bool n9Falecimento ;
      private bool n10NumeroObito ;
      private bool n11NFNumero ;
      private bool n12NFValor ;
      private bool n13Funeraria ;
      private bool n14Observacao ;
      private bool n15Parentesco ;
      private bool n16Cemiterio ;
      private bool n17Jazigo ;
      private bool n18Quadra ;
      private bool n19Lote ;
      private bool n20SeqDependente ;
      private bool n21Capela ;
      private bool n22EnderecoFalecido ;
      private bool n23horafalecimento ;
      private bool n24CidadeFalecimento ;
      private bool n25LocalFalecimento ;
      private bool n26HoraSepultamento ;
      private bool n27DatasolicitacaoAux ;
      private bool n28NomeContratanteAux ;
      private bool n29EndContratanteAux ;
      private bool n30CidadeContratanteAux ;
      private bool n31RGContratanteAux ;
      private bool n32CPFContratanteAux ;
      private bool n33EstCivilContratanteAux ;
      private bool n34DataInsert ;
      private bool n35UsuInsert ;
      private bool n36DataUpdate ;
      private bool n37UsuUpdate ;
      private bool n38NumControleAux ;
      private bool n39ValorAux ;
      private bool n40DataPagtoAux ;
      private bool n41ObservacaoAux ;
      private bool n42EmCarencia ;
      private bool n43PercentualCobertura ;
      private bool n44PacienteUnesp ;
      private bool n45RegistroUnesp ;
      private bool n47ViciosHabituais ;
      private bool n48ViciosEspecificar ;
      private bool n49DoencasConhecidas ;
      private bool n50TaxaCapelaAux ;
      private bool n51TaxaSepultamento ;
      private bool n52Matricula ;
      private bool n53UsouCremacao ;
      private bool n54Seq ;
      private bool n46RelatoObito ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A46RelatoObito ;
      private string Z46RelatoObito ;
      private string wcpOAV8Nome ;
      private string Z2Nome ;
      private string Z10NumeroObito ;
      private string Z11NFNumero ;
      private string Z14Observacao ;
      private string Z22EnderecoFalecido ;
      private string Z23horafalecimento ;
      private string Z25LocalFalecimento ;
      private string Z26HoraSepultamento ;
      private string Z28NomeContratanteAux ;
      private string Z29EndContratanteAux ;
      private string Z31RGContratanteAux ;
      private string Z32CPFContratanteAux ;
      private string Z41ObservacaoAux ;
      private string Z45RegistroUnesp ;
      private string Z48ViciosEspecificar ;
      private string Z49DoencasConhecidas ;
      private string Z52Matricula ;
      private string AV8Nome ;
      private string A2Nome ;
      private string A10NumeroObito ;
      private string A11NFNumero ;
      private string A14Observacao ;
      private string A22EnderecoFalecido ;
      private string A23horafalecimento ;
      private string A25LocalFalecimento ;
      private string A26HoraSepultamento ;
      private string A28NomeContratanteAux ;
      private string A29EndContratanteAux ;
      private string A31RGContratanteAux ;
      private string A32CPFContratanteAux ;
      private string A41ObservacaoAux ;
      private string A45RegistroUnesp ;
      private string A48ViciosEspecificar ;
      private string A49DoencasConhecidas ;
      private string A52Matricula ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] T00014_A1Inscricao ;
      private string[] T00014_A2Nome ;
      private string[] T00014_A3Grupo ;
      private bool[] T00014_n3Grupo ;
      private string[] T00014_A4Referencia ;
      private bool[] T00014_n4Referencia ;
      private int[] T00014_A5Numero ;
      private bool[] T00014_n5Numero ;
      private decimal[] T00014_A6Valor ;
      private bool[] T00014_n6Valor ;
      private DateTime[] T00014_A7Vencimento ;
      private bool[] T00014_n7Vencimento ;
      private DateTime[] T00014_A8Nascimento ;
      private bool[] T00014_n8Nascimento ;
      private DateTime[] T00014_A9Falecimento ;
      private bool[] T00014_n9Falecimento ;
      private string[] T00014_A10NumeroObito ;
      private bool[] T00014_n10NumeroObito ;
      private string[] T00014_A11NFNumero ;
      private bool[] T00014_n11NFNumero ;
      private decimal[] T00014_A12NFValor ;
      private bool[] T00014_n12NFValor ;
      private string[] T00014_A13Funeraria ;
      private bool[] T00014_n13Funeraria ;
      private string[] T00014_A14Observacao ;
      private bool[] T00014_n14Observacao ;
      private string[] T00014_A15Parentesco ;
      private bool[] T00014_n15Parentesco ;
      private int[] T00014_A16Cemiterio ;
      private bool[] T00014_n16Cemiterio ;
      private int[] T00014_A17Jazigo ;
      private bool[] T00014_n17Jazigo ;
      private int[] T00014_A18Quadra ;
      private bool[] T00014_n18Quadra ;
      private int[] T00014_A19Lote ;
      private bool[] T00014_n19Lote ;
      private int[] T00014_A20SeqDependente ;
      private bool[] T00014_n20SeqDependente ;
      private int[] T00014_A21Capela ;
      private bool[] T00014_n21Capela ;
      private string[] T00014_A22EnderecoFalecido ;
      private bool[] T00014_n22EnderecoFalecido ;
      private string[] T00014_A23horafalecimento ;
      private bool[] T00014_n23horafalecimento ;
      private int[] T00014_A24CidadeFalecimento ;
      private bool[] T00014_n24CidadeFalecimento ;
      private string[] T00014_A25LocalFalecimento ;
      private bool[] T00014_n25LocalFalecimento ;
      private string[] T00014_A26HoraSepultamento ;
      private bool[] T00014_n26HoraSepultamento ;
      private DateTime[] T00014_A27DatasolicitacaoAux ;
      private bool[] T00014_n27DatasolicitacaoAux ;
      private string[] T00014_A28NomeContratanteAux ;
      private bool[] T00014_n28NomeContratanteAux ;
      private string[] T00014_A29EndContratanteAux ;
      private bool[] T00014_n29EndContratanteAux ;
      private int[] T00014_A30CidadeContratanteAux ;
      private bool[] T00014_n30CidadeContratanteAux ;
      private string[] T00014_A31RGContratanteAux ;
      private bool[] T00014_n31RGContratanteAux ;
      private string[] T00014_A32CPFContratanteAux ;
      private bool[] T00014_n32CPFContratanteAux ;
      private int[] T00014_A33EstCivilContratanteAux ;
      private bool[] T00014_n33EstCivilContratanteAux ;
      private DateTime[] T00014_A34DataInsert ;
      private bool[] T00014_n34DataInsert ;
      private int[] T00014_A35UsuInsert ;
      private bool[] T00014_n35UsuInsert ;
      private DateTime[] T00014_A36DataUpdate ;
      private bool[] T00014_n36DataUpdate ;
      private int[] T00014_A37UsuUpdate ;
      private bool[] T00014_n37UsuUpdate ;
      private int[] T00014_A38NumControleAux ;
      private bool[] T00014_n38NumControleAux ;
      private decimal[] T00014_A39ValorAux ;
      private bool[] T00014_n39ValorAux ;
      private DateTime[] T00014_A40DataPagtoAux ;
      private bool[] T00014_n40DataPagtoAux ;
      private string[] T00014_A41ObservacaoAux ;
      private bool[] T00014_n41ObservacaoAux ;
      private string[] T00014_A42EmCarencia ;
      private bool[] T00014_n42EmCarencia ;
      private decimal[] T00014_A43PercentualCobertura ;
      private bool[] T00014_n43PercentualCobertura ;
      private string[] T00014_A44PacienteUnesp ;
      private bool[] T00014_n44PacienteUnesp ;
      private string[] T00014_A45RegistroUnesp ;
      private bool[] T00014_n45RegistroUnesp ;
      private string[] T00014_A46RelatoObito ;
      private bool[] T00014_n46RelatoObito ;
      private string[] T00014_A47ViciosHabituais ;
      private bool[] T00014_n47ViciosHabituais ;
      private string[] T00014_A48ViciosEspecificar ;
      private bool[] T00014_n48ViciosEspecificar ;
      private string[] T00014_A49DoencasConhecidas ;
      private bool[] T00014_n49DoencasConhecidas ;
      private decimal[] T00014_A50TaxaCapelaAux ;
      private bool[] T00014_n50TaxaCapelaAux ;
      private decimal[] T00014_A51TaxaSepultamento ;
      private bool[] T00014_n51TaxaSepultamento ;
      private string[] T00014_A52Matricula ;
      private bool[] T00014_n52Matricula ;
      private string[] T00014_A53UsouCremacao ;
      private bool[] T00014_n53UsouCremacao ;
      private int[] T00014_A54Seq ;
      private bool[] T00014_n54Seq ;
      private int[] T00015_A1Inscricao ;
      private string[] T00015_A2Nome ;
      private int[] T00013_A1Inscricao ;
      private string[] T00013_A2Nome ;
      private string[] T00013_A3Grupo ;
      private bool[] T00013_n3Grupo ;
      private string[] T00013_A4Referencia ;
      private bool[] T00013_n4Referencia ;
      private int[] T00013_A5Numero ;
      private bool[] T00013_n5Numero ;
      private decimal[] T00013_A6Valor ;
      private bool[] T00013_n6Valor ;
      private DateTime[] T00013_A7Vencimento ;
      private bool[] T00013_n7Vencimento ;
      private DateTime[] T00013_A8Nascimento ;
      private bool[] T00013_n8Nascimento ;
      private DateTime[] T00013_A9Falecimento ;
      private bool[] T00013_n9Falecimento ;
      private string[] T00013_A10NumeroObito ;
      private bool[] T00013_n10NumeroObito ;
      private string[] T00013_A11NFNumero ;
      private bool[] T00013_n11NFNumero ;
      private decimal[] T00013_A12NFValor ;
      private bool[] T00013_n12NFValor ;
      private string[] T00013_A13Funeraria ;
      private bool[] T00013_n13Funeraria ;
      private string[] T00013_A14Observacao ;
      private bool[] T00013_n14Observacao ;
      private string[] T00013_A15Parentesco ;
      private bool[] T00013_n15Parentesco ;
      private int[] T00013_A16Cemiterio ;
      private bool[] T00013_n16Cemiterio ;
      private int[] T00013_A17Jazigo ;
      private bool[] T00013_n17Jazigo ;
      private int[] T00013_A18Quadra ;
      private bool[] T00013_n18Quadra ;
      private int[] T00013_A19Lote ;
      private bool[] T00013_n19Lote ;
      private int[] T00013_A20SeqDependente ;
      private bool[] T00013_n20SeqDependente ;
      private int[] T00013_A21Capela ;
      private bool[] T00013_n21Capela ;
      private string[] T00013_A22EnderecoFalecido ;
      private bool[] T00013_n22EnderecoFalecido ;
      private string[] T00013_A23horafalecimento ;
      private bool[] T00013_n23horafalecimento ;
      private int[] T00013_A24CidadeFalecimento ;
      private bool[] T00013_n24CidadeFalecimento ;
      private string[] T00013_A25LocalFalecimento ;
      private bool[] T00013_n25LocalFalecimento ;
      private string[] T00013_A26HoraSepultamento ;
      private bool[] T00013_n26HoraSepultamento ;
      private DateTime[] T00013_A27DatasolicitacaoAux ;
      private bool[] T00013_n27DatasolicitacaoAux ;
      private string[] T00013_A28NomeContratanteAux ;
      private bool[] T00013_n28NomeContratanteAux ;
      private string[] T00013_A29EndContratanteAux ;
      private bool[] T00013_n29EndContratanteAux ;
      private int[] T00013_A30CidadeContratanteAux ;
      private bool[] T00013_n30CidadeContratanteAux ;
      private string[] T00013_A31RGContratanteAux ;
      private bool[] T00013_n31RGContratanteAux ;
      private string[] T00013_A32CPFContratanteAux ;
      private bool[] T00013_n32CPFContratanteAux ;
      private int[] T00013_A33EstCivilContratanteAux ;
      private bool[] T00013_n33EstCivilContratanteAux ;
      private DateTime[] T00013_A34DataInsert ;
      private bool[] T00013_n34DataInsert ;
      private int[] T00013_A35UsuInsert ;
      private bool[] T00013_n35UsuInsert ;
      private DateTime[] T00013_A36DataUpdate ;
      private bool[] T00013_n36DataUpdate ;
      private int[] T00013_A37UsuUpdate ;
      private bool[] T00013_n37UsuUpdate ;
      private int[] T00013_A38NumControleAux ;
      private bool[] T00013_n38NumControleAux ;
      private decimal[] T00013_A39ValorAux ;
      private bool[] T00013_n39ValorAux ;
      private DateTime[] T00013_A40DataPagtoAux ;
      private bool[] T00013_n40DataPagtoAux ;
      private string[] T00013_A41ObservacaoAux ;
      private bool[] T00013_n41ObservacaoAux ;
      private string[] T00013_A42EmCarencia ;
      private bool[] T00013_n42EmCarencia ;
      private decimal[] T00013_A43PercentualCobertura ;
      private bool[] T00013_n43PercentualCobertura ;
      private string[] T00013_A44PacienteUnesp ;
      private bool[] T00013_n44PacienteUnesp ;
      private string[] T00013_A45RegistroUnesp ;
      private bool[] T00013_n45RegistroUnesp ;
      private string[] T00013_A46RelatoObito ;
      private bool[] T00013_n46RelatoObito ;
      private string[] T00013_A47ViciosHabituais ;
      private bool[] T00013_n47ViciosHabituais ;
      private string[] T00013_A48ViciosEspecificar ;
      private bool[] T00013_n48ViciosEspecificar ;
      private string[] T00013_A49DoencasConhecidas ;
      private bool[] T00013_n49DoencasConhecidas ;
      private decimal[] T00013_A50TaxaCapelaAux ;
      private bool[] T00013_n50TaxaCapelaAux ;
      private decimal[] T00013_A51TaxaSepultamento ;
      private bool[] T00013_n51TaxaSepultamento ;
      private string[] T00013_A52Matricula ;
      private bool[] T00013_n52Matricula ;
      private string[] T00013_A53UsouCremacao ;
      private bool[] T00013_n53UsouCremacao ;
      private int[] T00013_A54Seq ;
      private bool[] T00013_n54Seq ;
      private int[] T00016_A1Inscricao ;
      private string[] T00016_A2Nome ;
      private int[] T00017_A1Inscricao ;
      private string[] T00017_A2Nome ;
      private int[] T00012_A1Inscricao ;
      private string[] T00012_A2Nome ;
      private string[] T00012_A3Grupo ;
      private bool[] T00012_n3Grupo ;
      private string[] T00012_A4Referencia ;
      private bool[] T00012_n4Referencia ;
      private int[] T00012_A5Numero ;
      private bool[] T00012_n5Numero ;
      private decimal[] T00012_A6Valor ;
      private bool[] T00012_n6Valor ;
      private DateTime[] T00012_A7Vencimento ;
      private bool[] T00012_n7Vencimento ;
      private DateTime[] T00012_A8Nascimento ;
      private bool[] T00012_n8Nascimento ;
      private DateTime[] T00012_A9Falecimento ;
      private bool[] T00012_n9Falecimento ;
      private string[] T00012_A10NumeroObito ;
      private bool[] T00012_n10NumeroObito ;
      private string[] T00012_A11NFNumero ;
      private bool[] T00012_n11NFNumero ;
      private decimal[] T00012_A12NFValor ;
      private bool[] T00012_n12NFValor ;
      private string[] T00012_A13Funeraria ;
      private bool[] T00012_n13Funeraria ;
      private string[] T00012_A14Observacao ;
      private bool[] T00012_n14Observacao ;
      private string[] T00012_A15Parentesco ;
      private bool[] T00012_n15Parentesco ;
      private int[] T00012_A16Cemiterio ;
      private bool[] T00012_n16Cemiterio ;
      private int[] T00012_A17Jazigo ;
      private bool[] T00012_n17Jazigo ;
      private int[] T00012_A18Quadra ;
      private bool[] T00012_n18Quadra ;
      private int[] T00012_A19Lote ;
      private bool[] T00012_n19Lote ;
      private int[] T00012_A20SeqDependente ;
      private bool[] T00012_n20SeqDependente ;
      private int[] T00012_A21Capela ;
      private bool[] T00012_n21Capela ;
      private string[] T00012_A22EnderecoFalecido ;
      private bool[] T00012_n22EnderecoFalecido ;
      private string[] T00012_A23horafalecimento ;
      private bool[] T00012_n23horafalecimento ;
      private int[] T00012_A24CidadeFalecimento ;
      private bool[] T00012_n24CidadeFalecimento ;
      private string[] T00012_A25LocalFalecimento ;
      private bool[] T00012_n25LocalFalecimento ;
      private string[] T00012_A26HoraSepultamento ;
      private bool[] T00012_n26HoraSepultamento ;
      private DateTime[] T00012_A27DatasolicitacaoAux ;
      private bool[] T00012_n27DatasolicitacaoAux ;
      private string[] T00012_A28NomeContratanteAux ;
      private bool[] T00012_n28NomeContratanteAux ;
      private string[] T00012_A29EndContratanteAux ;
      private bool[] T00012_n29EndContratanteAux ;
      private int[] T00012_A30CidadeContratanteAux ;
      private bool[] T00012_n30CidadeContratanteAux ;
      private string[] T00012_A31RGContratanteAux ;
      private bool[] T00012_n31RGContratanteAux ;
      private string[] T00012_A32CPFContratanteAux ;
      private bool[] T00012_n32CPFContratanteAux ;
      private int[] T00012_A33EstCivilContratanteAux ;
      private bool[] T00012_n33EstCivilContratanteAux ;
      private DateTime[] T00012_A34DataInsert ;
      private bool[] T00012_n34DataInsert ;
      private int[] T00012_A35UsuInsert ;
      private bool[] T00012_n35UsuInsert ;
      private DateTime[] T00012_A36DataUpdate ;
      private bool[] T00012_n36DataUpdate ;
      private int[] T00012_A37UsuUpdate ;
      private bool[] T00012_n37UsuUpdate ;
      private int[] T00012_A38NumControleAux ;
      private bool[] T00012_n38NumControleAux ;
      private decimal[] T00012_A39ValorAux ;
      private bool[] T00012_n39ValorAux ;
      private DateTime[] T00012_A40DataPagtoAux ;
      private bool[] T00012_n40DataPagtoAux ;
      private string[] T00012_A41ObservacaoAux ;
      private bool[] T00012_n41ObservacaoAux ;
      private string[] T00012_A42EmCarencia ;
      private bool[] T00012_n42EmCarencia ;
      private decimal[] T00012_A43PercentualCobertura ;
      private bool[] T00012_n43PercentualCobertura ;
      private string[] T00012_A44PacienteUnesp ;
      private bool[] T00012_n44PacienteUnesp ;
      private string[] T00012_A45RegistroUnesp ;
      private bool[] T00012_n45RegistroUnesp ;
      private string[] T00012_A46RelatoObito ;
      private bool[] T00012_n46RelatoObito ;
      private string[] T00012_A47ViciosHabituais ;
      private bool[] T00012_n47ViciosHabituais ;
      private string[] T00012_A48ViciosEspecificar ;
      private bool[] T00012_n48ViciosEspecificar ;
      private string[] T00012_A49DoencasConhecidas ;
      private bool[] T00012_n49DoencasConhecidas ;
      private decimal[] T00012_A50TaxaCapelaAux ;
      private bool[] T00012_n50TaxaCapelaAux ;
      private decimal[] T00012_A51TaxaSepultamento ;
      private bool[] T00012_n51TaxaSepultamento ;
      private string[] T00012_A52Matricula ;
      private bool[] T00012_n52Matricula ;
      private string[] T00012_A53UsouCremacao ;
      private bool[] T00012_n53UsouCremacao ;
      private int[] T00012_A54Seq ;
      private bool[] T00012_n54Seq ;
      private IDataStoreProvider pr_default ;
      private int[] T000111_A1Inscricao ;
      private string[] T000111_A2Nome ;
   }

   public class obitos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0) ,
          new ParDef("@Grupo",GXType.NChar,5,0){Nullable=true} ,
          new ParDef("@Referencia",GXType.NChar,7,0){Nullable=true} ,
          new ParDef("@Numero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Valor",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@Vencimento",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@Nascimento",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@Falecimento",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@NumeroObito",GXType.NVarChar,15,0){Nullable=true} ,
          new ParDef("@NFNumero",GXType.NVarChar,9,0){Nullable=true} ,
          new ParDef("@NFValor",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@Funeraria",GXType.NChar,5,0){Nullable=true} ,
          new ParDef("@Observacao",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@Parentesco",GXType.NChar,5,0){Nullable=true} ,
          new ParDef("@Cemiterio",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Jazigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Quadra",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Lote",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@SeqDependente",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Capela",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@EnderecoFalecido",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@horafalecimento",GXType.NVarChar,5,0){Nullable=true} ,
          new ParDef("@CidadeFalecimento",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@LocalFalecimento",GXType.NVarChar,45,0){Nullable=true} ,
          new ParDef("@HoraSepultamento",GXType.NVarChar,5,0){Nullable=true} ,
          new ParDef("@DatasolicitacaoAux",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@NomeContratanteAux",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@EndContratanteAux",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@CidadeContratanteAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@RGContratanteAux",GXType.NVarChar,14,0){Nullable=true} ,
          new ParDef("@CPFContratanteAux",GXType.NVarChar,14,0){Nullable=true} ,
          new ParDef("@EstCivilContratanteAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@DataInsert",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@UsuInsert",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@DataUpdate",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@UsuUpdate",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@NumControleAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@ValorAux",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@DataPagtoAux",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@ObservacaoAux",GXType.NVarChar,255,0){Nullable=true} ,
          new ParDef("@EmCarencia",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@PercentualCobertura",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@PacienteUnesp",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@RegistroUnesp",GXType.NVarChar,15,0){Nullable=true} ,
          new ParDef("@RelatoObito",GXType.NVarChar,16,0){Nullable=true} ,
          new ParDef("@ViciosHabituais",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@ViciosEspecificar",GXType.NVarChar,30,0){Nullable=true} ,
          new ParDef("@DoencasConhecidas",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TaxaCapelaAux",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@TaxaSepultamento",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@Matricula",GXType.NVarChar,38,0){Nullable=true} ,
          new ParDef("@UsouCremacao",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@Seq",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@Grupo",GXType.NChar,5,0){Nullable=true} ,
          new ParDef("@Referencia",GXType.NChar,7,0){Nullable=true} ,
          new ParDef("@Numero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Valor",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@Vencimento",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@Nascimento",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@Falecimento",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@NumeroObito",GXType.NVarChar,15,0){Nullable=true} ,
          new ParDef("@NFNumero",GXType.NVarChar,9,0){Nullable=true} ,
          new ParDef("@NFValor",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@Funeraria",GXType.NChar,5,0){Nullable=true} ,
          new ParDef("@Observacao",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@Parentesco",GXType.NChar,5,0){Nullable=true} ,
          new ParDef("@Cemiterio",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Jazigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Quadra",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Lote",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@SeqDependente",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Capela",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@EnderecoFalecido",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@horafalecimento",GXType.NVarChar,5,0){Nullable=true} ,
          new ParDef("@CidadeFalecimento",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@LocalFalecimento",GXType.NVarChar,45,0){Nullable=true} ,
          new ParDef("@HoraSepultamento",GXType.NVarChar,5,0){Nullable=true} ,
          new ParDef("@DatasolicitacaoAux",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@NomeContratanteAux",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@EndContratanteAux",GXType.NVarChar,50,0){Nullable=true} ,
          new ParDef("@CidadeContratanteAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@RGContratanteAux",GXType.NVarChar,14,0){Nullable=true} ,
          new ParDef("@CPFContratanteAux",GXType.NVarChar,14,0){Nullable=true} ,
          new ParDef("@EstCivilContratanteAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@DataInsert",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@UsuInsert",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@DataUpdate",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@UsuUpdate",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@NumControleAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@ValorAux",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@DataPagtoAux",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@ObservacaoAux",GXType.NVarChar,255,0){Nullable=true} ,
          new ParDef("@EmCarencia",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@PercentualCobertura",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@PacienteUnesp",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@RegistroUnesp",GXType.NVarChar,15,0){Nullable=true} ,
          new ParDef("@RelatoObito",GXType.NVarChar,16,0){Nullable=true} ,
          new ParDef("@ViciosHabituais",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@ViciosEspecificar",GXType.NVarChar,30,0){Nullable=true} ,
          new ParDef("@DoencasConhecidas",GXType.NVarChar,60,0){Nullable=true} ,
          new ParDef("@TaxaCapelaAux",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@TaxaSepultamento",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@Matricula",GXType.NVarChar,38,0){Nullable=true} ,
          new ParDef("@UsouCremacao",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@Seq",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@Inscricao",GXType.Int32,9,0) ,
          new ParDef("@Nome",GXType.NVarChar,50,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [Inscricao], [Nome], [Grupo], [Referencia], [Numero], [Valor], [Vencimento], [Nascimento], [Falecimento], [NumeroObito], [NFNumero], [NFValor], [Funeraria], [Observacao], [Parentesco], [Cemiterio], [Jazigo], [Quadra], [Lote], [SeqDependente], [Capela], [EnderecoFalecido], [horafalecimento], [CidadeFalecimento], [LocalFalecimento], [HoraSepultamento], [DatasolicitacaoAux], [NomeContratanteAux], [EndContratanteAux], [CidadeContratanteAux], [RGContratanteAux], [CPFContratanteAux], [EstCivilContratanteAux], [DataInsert], [UsuInsert], [DataUpdate], [UsuUpdate], [NumControleAux], [ValorAux], [DataPagtoAux], [ObservacaoAux], [EmCarencia], [PercentualCobertura], [PacienteUnesp], [RegistroUnesp], [RelatoObito], [ViciosHabituais], [ViciosEspecificar], [DoencasConhecidas], [TaxaCapelaAux], [TaxaSepultamento], [Matricula], [UsouCremacao], [Seq] FROM dbo.[Obitos] WITH (UPDLOCK) WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [Inscricao], [Nome], [Grupo], [Referencia], [Numero], [Valor], [Vencimento], [Nascimento], [Falecimento], [NumeroObito], [NFNumero], [NFValor], [Funeraria], [Observacao], [Parentesco], [Cemiterio], [Jazigo], [Quadra], [Lote], [SeqDependente], [Capela], [EnderecoFalecido], [horafalecimento], [CidadeFalecimento], [LocalFalecimento], [HoraSepultamento], [DatasolicitacaoAux], [NomeContratanteAux], [EndContratanteAux], [CidadeContratanteAux], [RGContratanteAux], [CPFContratanteAux], [EstCivilContratanteAux], [DataInsert], [UsuInsert], [DataUpdate], [UsuUpdate], [NumControleAux], [ValorAux], [DataPagtoAux], [ObservacaoAux], [EmCarencia], [PercentualCobertura], [PacienteUnesp], [RegistroUnesp], [RelatoObito], [ViciosHabituais], [ViciosEspecificar], [DoencasConhecidas], [TaxaCapelaAux], [TaxaSepultamento], [Matricula], [UsouCremacao], [Seq] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT TM1.[Inscricao], TM1.[Nome], TM1.[Grupo], TM1.[Referencia], TM1.[Numero], TM1.[Valor], TM1.[Vencimento], TM1.[Nascimento], TM1.[Falecimento], TM1.[NumeroObito], TM1.[NFNumero], TM1.[NFValor], TM1.[Funeraria], TM1.[Observacao], TM1.[Parentesco], TM1.[Cemiterio], TM1.[Jazigo], TM1.[Quadra], TM1.[Lote], TM1.[SeqDependente], TM1.[Capela], TM1.[EnderecoFalecido], TM1.[horafalecimento], TM1.[CidadeFalecimento], TM1.[LocalFalecimento], TM1.[HoraSepultamento], TM1.[DatasolicitacaoAux], TM1.[NomeContratanteAux], TM1.[EndContratanteAux], TM1.[CidadeContratanteAux], TM1.[RGContratanteAux], TM1.[CPFContratanteAux], TM1.[EstCivilContratanteAux], TM1.[DataInsert], TM1.[UsuInsert], TM1.[DataUpdate], TM1.[UsuUpdate], TM1.[NumControleAux], TM1.[ValorAux], TM1.[DataPagtoAux], TM1.[ObservacaoAux], TM1.[EmCarencia], TM1.[PercentualCobertura], TM1.[PacienteUnesp], TM1.[RegistroUnesp], TM1.[RelatoObito], TM1.[ViciosHabituais], TM1.[ViciosEspecificar], TM1.[DoencasConhecidas], TM1.[TaxaCapelaAux], TM1.[TaxaSepultamento], TM1.[Matricula], TM1.[UsouCremacao], TM1.[Seq] FROM dbo.[Obitos] TM1 WHERE TM1.[Inscricao] = @Inscricao and TM1.[Nome] = @Nome ORDER BY TM1.[Inscricao], TM1.[Nome]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [Inscricao], [Nome] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TOP 1 [Inscricao], [Nome] FROM dbo.[Obitos] WHERE ( [Inscricao] > @Inscricao or [Inscricao] = @Inscricao and [Nome] > @Nome) ORDER BY [Inscricao], [Nome]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00017", "SELECT TOP 1 [Inscricao], [Nome] FROM dbo.[Obitos] WHERE ( [Inscricao] < @Inscricao or [Inscricao] = @Inscricao and [Nome] < @Nome) ORDER BY [Inscricao] DESC, [Nome] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00018", "INSERT INTO dbo.[Obitos]([Inscricao], [Nome], [Grupo], [Referencia], [Numero], [Valor], [Vencimento], [Nascimento], [Falecimento], [NumeroObito], [NFNumero], [NFValor], [Funeraria], [Observacao], [Parentesco], [Cemiterio], [Jazigo], [Quadra], [Lote], [SeqDependente], [Capela], [EnderecoFalecido], [horafalecimento], [CidadeFalecimento], [LocalFalecimento], [HoraSepultamento], [DatasolicitacaoAux], [NomeContratanteAux], [EndContratanteAux], [CidadeContratanteAux], [RGContratanteAux], [CPFContratanteAux], [EstCivilContratanteAux], [DataInsert], [UsuInsert], [DataUpdate], [UsuUpdate], [NumControleAux], [ValorAux], [DataPagtoAux], [ObservacaoAux], [EmCarencia], [PercentualCobertura], [PacienteUnesp], [RegistroUnesp], [RelatoObito], [ViciosHabituais], [ViciosEspecificar], [DoencasConhecidas], [TaxaCapelaAux], [TaxaSepultamento], [Matricula], [UsouCremacao], [Seq]) VALUES(@Inscricao, @Nome, @Grupo, @Referencia, @Numero, @Valor, @Vencimento, @Nascimento, @Falecimento, @NumeroObito, @NFNumero, @NFValor, @Funeraria, @Observacao, @Parentesco, @Cemiterio, @Jazigo, @Quadra, @Lote, @SeqDependente, @Capela, @EnderecoFalecido, @horafalecimento, @CidadeFalecimento, @LocalFalecimento, @HoraSepultamento, @DatasolicitacaoAux, @NomeContratanteAux, @EndContratanteAux, @CidadeContratanteAux, @RGContratanteAux, @CPFContratanteAux, @EstCivilContratanteAux, @DataInsert, @UsuInsert, @DataUpdate, @UsuUpdate, @NumControleAux, @ValorAux, @DataPagtoAux, @ObservacaoAux, @EmCarencia, @PercentualCobertura, @PacienteUnesp, @RegistroUnesp, @RelatoObito, @ViciosHabituais, @ViciosEspecificar, @DoencasConhecidas, @TaxaCapelaAux, @TaxaSepultamento, @Matricula, @UsouCremacao, @Seq)", GxErrorMask.GX_NOMASK,prmT00018)
             ,new CursorDef("T00019", "UPDATE dbo.[Obitos] SET [Grupo]=@Grupo, [Referencia]=@Referencia, [Numero]=@Numero, [Valor]=@Valor, [Vencimento]=@Vencimento, [Nascimento]=@Nascimento, [Falecimento]=@Falecimento, [NumeroObito]=@NumeroObito, [NFNumero]=@NFNumero, [NFValor]=@NFValor, [Funeraria]=@Funeraria, [Observacao]=@Observacao, [Parentesco]=@Parentesco, [Cemiterio]=@Cemiterio, [Jazigo]=@Jazigo, [Quadra]=@Quadra, [Lote]=@Lote, [SeqDependente]=@SeqDependente, [Capela]=@Capela, [EnderecoFalecido]=@EnderecoFalecido, [horafalecimento]=@horafalecimento, [CidadeFalecimento]=@CidadeFalecimento, [LocalFalecimento]=@LocalFalecimento, [HoraSepultamento]=@HoraSepultamento, [DatasolicitacaoAux]=@DatasolicitacaoAux, [NomeContratanteAux]=@NomeContratanteAux, [EndContratanteAux]=@EndContratanteAux, [CidadeContratanteAux]=@CidadeContratanteAux, [RGContratanteAux]=@RGContratanteAux, [CPFContratanteAux]=@CPFContratanteAux, [EstCivilContratanteAux]=@EstCivilContratanteAux, [DataInsert]=@DataInsert, [UsuInsert]=@UsuInsert, [DataUpdate]=@DataUpdate, [UsuUpdate]=@UsuUpdate, [NumControleAux]=@NumControleAux, [ValorAux]=@ValorAux, [DataPagtoAux]=@DataPagtoAux, [ObservacaoAux]=@ObservacaoAux, [EmCarencia]=@EmCarencia, [PercentualCobertura]=@PercentualCobertura, [PacienteUnesp]=@PacienteUnesp, [RegistroUnesp]=@RegistroUnesp, [RelatoObito]=@RelatoObito, [ViciosHabituais]=@ViciosHabituais, [ViciosEspecificar]=@ViciosEspecificar, [DoencasConhecidas]=@DoencasConhecidas, [TaxaCapelaAux]=@TaxaCapelaAux, [TaxaSepultamento]=@TaxaSepultamento, [Matricula]=@Matricula, [UsouCremacao]=@UsouCremacao, [Seq]=@Seq  WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome", GxErrorMask.GX_NOMASK,prmT00019)
             ,new CursorDef("T000110", "DELETE FROM dbo.[Obitos]  WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "SELECT [Inscricao], [Nome] FROM dbo.[Obitos] ORDER BY [Inscricao], [Nome]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 7);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((string[]) buf[18])[0] = rslt.getVarchar(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((string[]) buf[22])[0] = rslt.getString(13, 5);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((string[]) buf[24])[0] = rslt.getVarchar(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((string[]) buf[26])[0] = rslt.getString(15, 5);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((int[]) buf[28])[0] = rslt.getInt(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((int[]) buf[30])[0] = rslt.getInt(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((int[]) buf[32])[0] = rslt.getInt(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((int[]) buf[34])[0] = rslt.getInt(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((int[]) buf[36])[0] = rslt.getInt(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((int[]) buf[38])[0] = rslt.getInt(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((string[]) buf[40])[0] = rslt.getVarchar(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((string[]) buf[42])[0] = rslt.getVarchar(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                ((int[]) buf[44])[0] = rslt.getInt(24);
                ((bool[]) buf[45])[0] = rslt.wasNull(24);
                ((string[]) buf[46])[0] = rslt.getVarchar(25);
                ((bool[]) buf[47])[0] = rslt.wasNull(25);
                ((string[]) buf[48])[0] = rslt.getVarchar(26);
                ((bool[]) buf[49])[0] = rslt.wasNull(26);
                ((DateTime[]) buf[50])[0] = rslt.getGXDateTime(27);
                ((bool[]) buf[51])[0] = rslt.wasNull(27);
                ((string[]) buf[52])[0] = rslt.getVarchar(28);
                ((bool[]) buf[53])[0] = rslt.wasNull(28);
                ((string[]) buf[54])[0] = rslt.getVarchar(29);
                ((bool[]) buf[55])[0] = rslt.wasNull(29);
                ((int[]) buf[56])[0] = rslt.getInt(30);
                ((bool[]) buf[57])[0] = rslt.wasNull(30);
                ((string[]) buf[58])[0] = rslt.getVarchar(31);
                ((bool[]) buf[59])[0] = rslt.wasNull(31);
                ((string[]) buf[60])[0] = rslt.getVarchar(32);
                ((bool[]) buf[61])[0] = rslt.wasNull(32);
                ((int[]) buf[62])[0] = rslt.getInt(33);
                ((bool[]) buf[63])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[64])[0] = rslt.getGXDateTime(34);
                ((bool[]) buf[65])[0] = rslt.wasNull(34);
                ((int[]) buf[66])[0] = rslt.getInt(35);
                ((bool[]) buf[67])[0] = rslt.wasNull(35);
                ((DateTime[]) buf[68])[0] = rslt.getGXDateTime(36);
                ((bool[]) buf[69])[0] = rslt.wasNull(36);
                ((int[]) buf[70])[0] = rslt.getInt(37);
                ((bool[]) buf[71])[0] = rslt.wasNull(37);
                ((int[]) buf[72])[0] = rslt.getInt(38);
                ((bool[]) buf[73])[0] = rslt.wasNull(38);
                ((decimal[]) buf[74])[0] = rslt.getDecimal(39);
                ((bool[]) buf[75])[0] = rslt.wasNull(39);
                ((DateTime[]) buf[76])[0] = rslt.getGXDateTime(40);
                ((bool[]) buf[77])[0] = rslt.wasNull(40);
                ((string[]) buf[78])[0] = rslt.getVarchar(41);
                ((bool[]) buf[79])[0] = rslt.wasNull(41);
                ((string[]) buf[80])[0] = rslt.getString(42, 1);
                ((bool[]) buf[81])[0] = rslt.wasNull(42);
                ((decimal[]) buf[82])[0] = rslt.getDecimal(43);
                ((bool[]) buf[83])[0] = rslt.wasNull(43);
                ((string[]) buf[84])[0] = rslt.getString(44, 1);
                ((bool[]) buf[85])[0] = rslt.wasNull(44);
                ((string[]) buf[86])[0] = rslt.getVarchar(45);
                ((bool[]) buf[87])[0] = rslt.wasNull(45);
                ((string[]) buf[88])[0] = rslt.getLongVarchar(46);
                ((bool[]) buf[89])[0] = rslt.wasNull(46);
                ((string[]) buf[90])[0] = rslt.getString(47, 1);
                ((bool[]) buf[91])[0] = rslt.wasNull(47);
                ((string[]) buf[92])[0] = rslt.getVarchar(48);
                ((bool[]) buf[93])[0] = rslt.wasNull(48);
                ((string[]) buf[94])[0] = rslt.getVarchar(49);
                ((bool[]) buf[95])[0] = rslt.wasNull(49);
                ((decimal[]) buf[96])[0] = rslt.getDecimal(50);
                ((bool[]) buf[97])[0] = rslt.wasNull(50);
                ((decimal[]) buf[98])[0] = rslt.getDecimal(51);
                ((bool[]) buf[99])[0] = rslt.wasNull(51);
                ((string[]) buf[100])[0] = rslt.getVarchar(52);
                ((bool[]) buf[101])[0] = rslt.wasNull(52);
                ((string[]) buf[102])[0] = rslt.getString(53, 1);
                ((bool[]) buf[103])[0] = rslt.wasNull(53);
                ((int[]) buf[104])[0] = rslt.getInt(54);
                ((bool[]) buf[105])[0] = rslt.wasNull(54);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 7);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((string[]) buf[18])[0] = rslt.getVarchar(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((string[]) buf[22])[0] = rslt.getString(13, 5);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((string[]) buf[24])[0] = rslt.getVarchar(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((string[]) buf[26])[0] = rslt.getString(15, 5);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((int[]) buf[28])[0] = rslt.getInt(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((int[]) buf[30])[0] = rslt.getInt(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((int[]) buf[32])[0] = rslt.getInt(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((int[]) buf[34])[0] = rslt.getInt(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((int[]) buf[36])[0] = rslt.getInt(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((int[]) buf[38])[0] = rslt.getInt(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((string[]) buf[40])[0] = rslt.getVarchar(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((string[]) buf[42])[0] = rslt.getVarchar(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                ((int[]) buf[44])[0] = rslt.getInt(24);
                ((bool[]) buf[45])[0] = rslt.wasNull(24);
                ((string[]) buf[46])[0] = rslt.getVarchar(25);
                ((bool[]) buf[47])[0] = rslt.wasNull(25);
                ((string[]) buf[48])[0] = rslt.getVarchar(26);
                ((bool[]) buf[49])[0] = rslt.wasNull(26);
                ((DateTime[]) buf[50])[0] = rslt.getGXDateTime(27);
                ((bool[]) buf[51])[0] = rslt.wasNull(27);
                ((string[]) buf[52])[0] = rslt.getVarchar(28);
                ((bool[]) buf[53])[0] = rslt.wasNull(28);
                ((string[]) buf[54])[0] = rslt.getVarchar(29);
                ((bool[]) buf[55])[0] = rslt.wasNull(29);
                ((int[]) buf[56])[0] = rslt.getInt(30);
                ((bool[]) buf[57])[0] = rslt.wasNull(30);
                ((string[]) buf[58])[0] = rslt.getVarchar(31);
                ((bool[]) buf[59])[0] = rslt.wasNull(31);
                ((string[]) buf[60])[0] = rslt.getVarchar(32);
                ((bool[]) buf[61])[0] = rslt.wasNull(32);
                ((int[]) buf[62])[0] = rslt.getInt(33);
                ((bool[]) buf[63])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[64])[0] = rslt.getGXDateTime(34);
                ((bool[]) buf[65])[0] = rslt.wasNull(34);
                ((int[]) buf[66])[0] = rslt.getInt(35);
                ((bool[]) buf[67])[0] = rslt.wasNull(35);
                ((DateTime[]) buf[68])[0] = rslt.getGXDateTime(36);
                ((bool[]) buf[69])[0] = rslt.wasNull(36);
                ((int[]) buf[70])[0] = rslt.getInt(37);
                ((bool[]) buf[71])[0] = rslt.wasNull(37);
                ((int[]) buf[72])[0] = rslt.getInt(38);
                ((bool[]) buf[73])[0] = rslt.wasNull(38);
                ((decimal[]) buf[74])[0] = rslt.getDecimal(39);
                ((bool[]) buf[75])[0] = rslt.wasNull(39);
                ((DateTime[]) buf[76])[0] = rslt.getGXDateTime(40);
                ((bool[]) buf[77])[0] = rslt.wasNull(40);
                ((string[]) buf[78])[0] = rslt.getVarchar(41);
                ((bool[]) buf[79])[0] = rslt.wasNull(41);
                ((string[]) buf[80])[0] = rslt.getString(42, 1);
                ((bool[]) buf[81])[0] = rslt.wasNull(42);
                ((decimal[]) buf[82])[0] = rslt.getDecimal(43);
                ((bool[]) buf[83])[0] = rslt.wasNull(43);
                ((string[]) buf[84])[0] = rslt.getString(44, 1);
                ((bool[]) buf[85])[0] = rslt.wasNull(44);
                ((string[]) buf[86])[0] = rslt.getVarchar(45);
                ((bool[]) buf[87])[0] = rslt.wasNull(45);
                ((string[]) buf[88])[0] = rslt.getLongVarchar(46);
                ((bool[]) buf[89])[0] = rslt.wasNull(46);
                ((string[]) buf[90])[0] = rslt.getString(47, 1);
                ((bool[]) buf[91])[0] = rslt.wasNull(47);
                ((string[]) buf[92])[0] = rslt.getVarchar(48);
                ((bool[]) buf[93])[0] = rslt.wasNull(48);
                ((string[]) buf[94])[0] = rslt.getVarchar(49);
                ((bool[]) buf[95])[0] = rslt.wasNull(49);
                ((decimal[]) buf[96])[0] = rslt.getDecimal(50);
                ((bool[]) buf[97])[0] = rslt.wasNull(50);
                ((decimal[]) buf[98])[0] = rslt.getDecimal(51);
                ((bool[]) buf[99])[0] = rslt.wasNull(51);
                ((string[]) buf[100])[0] = rslt.getVarchar(52);
                ((bool[]) buf[101])[0] = rslt.wasNull(52);
                ((string[]) buf[102])[0] = rslt.getString(53, 1);
                ((bool[]) buf[103])[0] = rslt.wasNull(53);
                ((int[]) buf[104])[0] = rslt.getInt(54);
                ((bool[]) buf[105])[0] = rslt.wasNull(54);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 7);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((string[]) buf[18])[0] = rslt.getVarchar(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                ((string[]) buf[22])[0] = rslt.getString(13, 5);
                ((bool[]) buf[23])[0] = rslt.wasNull(13);
                ((string[]) buf[24])[0] = rslt.getVarchar(14);
                ((bool[]) buf[25])[0] = rslt.wasNull(14);
                ((string[]) buf[26])[0] = rslt.getString(15, 5);
                ((bool[]) buf[27])[0] = rslt.wasNull(15);
                ((int[]) buf[28])[0] = rslt.getInt(16);
                ((bool[]) buf[29])[0] = rslt.wasNull(16);
                ((int[]) buf[30])[0] = rslt.getInt(17);
                ((bool[]) buf[31])[0] = rslt.wasNull(17);
                ((int[]) buf[32])[0] = rslt.getInt(18);
                ((bool[]) buf[33])[0] = rslt.wasNull(18);
                ((int[]) buf[34])[0] = rslt.getInt(19);
                ((bool[]) buf[35])[0] = rslt.wasNull(19);
                ((int[]) buf[36])[0] = rslt.getInt(20);
                ((bool[]) buf[37])[0] = rslt.wasNull(20);
                ((int[]) buf[38])[0] = rslt.getInt(21);
                ((bool[]) buf[39])[0] = rslt.wasNull(21);
                ((string[]) buf[40])[0] = rslt.getVarchar(22);
                ((bool[]) buf[41])[0] = rslt.wasNull(22);
                ((string[]) buf[42])[0] = rslt.getVarchar(23);
                ((bool[]) buf[43])[0] = rslt.wasNull(23);
                ((int[]) buf[44])[0] = rslt.getInt(24);
                ((bool[]) buf[45])[0] = rslt.wasNull(24);
                ((string[]) buf[46])[0] = rslt.getVarchar(25);
                ((bool[]) buf[47])[0] = rslt.wasNull(25);
                ((string[]) buf[48])[0] = rslt.getVarchar(26);
                ((bool[]) buf[49])[0] = rslt.wasNull(26);
                ((DateTime[]) buf[50])[0] = rslt.getGXDateTime(27);
                ((bool[]) buf[51])[0] = rslt.wasNull(27);
                ((string[]) buf[52])[0] = rslt.getVarchar(28);
                ((bool[]) buf[53])[0] = rslt.wasNull(28);
                ((string[]) buf[54])[0] = rslt.getVarchar(29);
                ((bool[]) buf[55])[0] = rslt.wasNull(29);
                ((int[]) buf[56])[0] = rslt.getInt(30);
                ((bool[]) buf[57])[0] = rslt.wasNull(30);
                ((string[]) buf[58])[0] = rslt.getVarchar(31);
                ((bool[]) buf[59])[0] = rslt.wasNull(31);
                ((string[]) buf[60])[0] = rslt.getVarchar(32);
                ((bool[]) buf[61])[0] = rslt.wasNull(32);
                ((int[]) buf[62])[0] = rslt.getInt(33);
                ((bool[]) buf[63])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[64])[0] = rslt.getGXDateTime(34);
                ((bool[]) buf[65])[0] = rslt.wasNull(34);
                ((int[]) buf[66])[0] = rslt.getInt(35);
                ((bool[]) buf[67])[0] = rslt.wasNull(35);
                ((DateTime[]) buf[68])[0] = rslt.getGXDateTime(36);
                ((bool[]) buf[69])[0] = rslt.wasNull(36);
                ((int[]) buf[70])[0] = rslt.getInt(37);
                ((bool[]) buf[71])[0] = rslt.wasNull(37);
                ((int[]) buf[72])[0] = rslt.getInt(38);
                ((bool[]) buf[73])[0] = rslt.wasNull(38);
                ((decimal[]) buf[74])[0] = rslt.getDecimal(39);
                ((bool[]) buf[75])[0] = rslt.wasNull(39);
                ((DateTime[]) buf[76])[0] = rslt.getGXDateTime(40);
                ((bool[]) buf[77])[0] = rslt.wasNull(40);
                ((string[]) buf[78])[0] = rslt.getVarchar(41);
                ((bool[]) buf[79])[0] = rslt.wasNull(41);
                ((string[]) buf[80])[0] = rslt.getString(42, 1);
                ((bool[]) buf[81])[0] = rslt.wasNull(42);
                ((decimal[]) buf[82])[0] = rslt.getDecimal(43);
                ((bool[]) buf[83])[0] = rslt.wasNull(43);
                ((string[]) buf[84])[0] = rslt.getString(44, 1);
                ((bool[]) buf[85])[0] = rslt.wasNull(44);
                ((string[]) buf[86])[0] = rslt.getVarchar(45);
                ((bool[]) buf[87])[0] = rslt.wasNull(45);
                ((string[]) buf[88])[0] = rslt.getLongVarchar(46);
                ((bool[]) buf[89])[0] = rslt.wasNull(46);
                ((string[]) buf[90])[0] = rslt.getString(47, 1);
                ((bool[]) buf[91])[0] = rslt.wasNull(47);
                ((string[]) buf[92])[0] = rslt.getVarchar(48);
                ((bool[]) buf[93])[0] = rslt.wasNull(48);
                ((string[]) buf[94])[0] = rslt.getVarchar(49);
                ((bool[]) buf[95])[0] = rslt.wasNull(49);
                ((decimal[]) buf[96])[0] = rslt.getDecimal(50);
                ((bool[]) buf[97])[0] = rslt.wasNull(50);
                ((decimal[]) buf[98])[0] = rslt.getDecimal(51);
                ((bool[]) buf[99])[0] = rslt.wasNull(51);
                ((string[]) buf[100])[0] = rslt.getVarchar(52);
                ((bool[]) buf[101])[0] = rslt.wasNull(52);
                ((string[]) buf[102])[0] = rslt.getString(53, 1);
                ((bool[]) buf[103])[0] = rslt.wasNull(53);
                ((int[]) buf[104])[0] = rslt.getInt(54);
                ((bool[]) buf[105])[0] = rslt.wasNull(54);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class obitos__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
