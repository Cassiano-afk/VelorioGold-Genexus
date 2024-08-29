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
   public class gerenciadordetransmissoes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A1Inscricao = (int)(Math.Round(NumberUtil.Val( GetPar( "Inscricao"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = GetPar( "Nome");
            AssignAttri("", false, "A2Nome", A2Nome);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A1Inscricao, A2Nome) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A61IdEstado = (short)(Math.Round(NumberUtil.Val( GetPar( "IdEstado"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A61IdEstado) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
         {
            A61IdEstado = (short)(Math.Round(NumberUtil.Val( GetPar( "IdEstado"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
            A64IdCidade = (short)(Math.Round(NumberUtil.Val( GetPar( "IdCidade"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A64IdCidade", StringUtil.LTrimStr( (decimal)(A64IdCidade), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_26( A61IdEstado, A64IdCidade) ;
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
               AV7IdTransmissao = (short)(Math.Round(NumberUtil.Val( GetPar( "IdTransmissao"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7IdTransmissao", StringUtil.LTrimStr( (decimal)(AV7IdTransmissao), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vIDTRANSMISSAO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IdTransmissao), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Gerenciador De Transmissões | Velório Gold", 0) ;
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
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public gerenciadordetransmissoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Design.GoldLegacy", true);
      }

      public gerenciadordetransmissoes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_IdTransmissao )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IdTransmissao = aP1_IdTransmissao;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Gerenciador De Transmissões", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInscricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInscricao_Internalname, "Inscrição", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInscricao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Inscricao), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1Inscricao), "ZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInscricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInscricao_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_single_line_edit( context, edtNome_Internalname, A2Nome, StringUtil.RTrim( context.localUtil.Format( A2Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNome_Enabled, 1, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_2_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_2_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_2_Internalname, sImgUrl, imgprompt_1_2_Link, "", "", context.GetTheme( ), imgprompt_1_2_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_label_element( context, edtNascimento_Internalname, "Nascimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNascimento_Internalname, context.localUtil.Format(A8Nascimento, "99/99/9999"), context.localUtil.Format( A8Nascimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNascimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNascimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_bitmap( context, edtNascimento_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_label_element( context, edtFalecimento_Internalname, "Falecimento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFalecimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFalecimento_Internalname, context.localUtil.Format(A9Falecimento, "99/99/9999"), context.localUtil.Format( A9Falecimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFalecimento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFalecimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_bitmap( context, edtFalecimento_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFalecimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_label_element( context, edtDataVelorio_Internalname, "Data Velório", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtDataVelorio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtDataVelorio_Internalname, context.localUtil.Format(A56DataVelorio, "99/99/99"), context.localUtil.Format( A56DataVelorio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDataVelorio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDataVelorio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_bitmap( context, edtDataVelorio_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtDataVelorio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_label_element( context, edtHoraInicio_Internalname, "Horário de Ínicio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHoraInicio_Internalname, context.localUtil.TToC( A57HoraInicio, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A57HoraInicio, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHoraInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHoraInicio_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_label_element( context, edtHoraFim_Internalname, "Horário de Término", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHoraFim_Internalname, context.localUtil.TToC( A58HoraFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A58HoraFim, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHoraFim_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHoraFim_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Time", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSenhaAcesso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSenhaAcesso_Internalname, "Senha de Acesso", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSenhaAcesso_Internalname, A60SenhaAcesso, StringUtil.RTrim( context.localUtil.Format( A60SenhaAcesso, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSenhaAcesso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSenhaAcesso_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIdEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIdEstado_Internalname, "Id Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIdEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61IdEstado), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A61IdEstado), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIdEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIdEstado_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Transactions\\Id", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_61_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_61_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_61_Internalname, sImgUrl, imgprompt_61_Link, "", "", context.GetTheme( ), imgprompt_61_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         GxWebStd.gx_label_element( context, edtNomeEstado_Internalname, "Nome Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNomeEstado_Internalname, StringUtil.RTrim( A62NomeEstado), StringUtil.RTrim( context.localUtil.Format( A62NomeEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNomeEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNomeEstado_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIdCidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIdCidade_Internalname, "Id Cidade", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIdCidade_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64IdCidade), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A64IdCidade), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIdCidade_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtIdCidade_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Transactions\\Id", "end", false, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_64_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_64_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_64_Internalname, sImgUrl, imgprompt_64_Link, "", "", context.GetTheme( ), imgprompt_64_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNomeCidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNomeCidade_Internalname, "Nome Cidade", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNomeCidade_Internalname, StringUtil.RTrim( A65NomeCidade), StringUtil.RTrim( context.localUtil.Format( A65NomeCidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNomeCidade_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNomeCidade_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Transactions\\Nome", "start", true, "", "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Transactions/GerenciadorDeTransmissoes.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z55IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z55IdTransmissao"), ",", "."), 18, MidpointRounding.ToEven));
               Z56DataVelorio = context.localUtil.CToD( cgiGet( "Z56DataVelorio"), 0);
               Z57HoraInicio = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z57HoraInicio"), 0));
               Z58HoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z58HoraFim"), 0));
               Z60SenhaAcesso = cgiGet( "Z60SenhaAcesso");
               Z66AoVivo = StringUtil.StrToBool( cgiGet( "Z66AoVivo"));
               Z1Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1Inscricao"), ",", "."), 18, MidpointRounding.ToEven));
               Z2Nome = cgiGet( "Z2Nome");
               Z61IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z61IdEstado"), ",", "."), 18, MidpointRounding.ToEven));
               Z64IdCidade = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z64IdCidade"), ",", "."), 18, MidpointRounding.ToEven));
               A66AoVivo = StringUtil.StrToBool( cgiGet( "Z66AoVivo"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N1Inscricao"), ",", "."), 18, MidpointRounding.ToEven));
               N2Nome = cgiGet( "N2Nome");
               N61IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N61IdEstado"), ",", "."), 18, MidpointRounding.ToEven));
               N64IdCidade = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N64IdCidade"), ",", "."), 18, MidpointRounding.ToEven));
               AV7IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vIDTRANSMISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               A55IdTransmissao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IDTRANSMISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_Inscricao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_INSCRICAO"), ",", "."), 18, MidpointRounding.ToEven));
               AV12Insert_Nome = cgiGet( "vINSERT_NOME");
               AV13Insert_IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_IDESTADO"), ",", "."), 18, MidpointRounding.ToEven));
               AV14Insert_IdCidade = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_IDCIDADE"), ",", "."), 18, MidpointRounding.ToEven));
               A66AoVivo = StringUtil.StrToBool( cgiGet( "AOVIVO"));
               AV23Pgmname = cgiGet( "vPGMNAME");
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
               A8Nascimento = context.localUtil.CToD( cgiGet( edtNascimento_Internalname), 2);
               n8Nascimento = false;
               AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
               A9Falecimento = context.localUtil.CToD( cgiGet( edtFalecimento_Internalname), 2);
               n9Falecimento = false;
               AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
               if ( context.localUtil.VCDate( cgiGet( edtDataVelorio_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data Velorio"}), 1, "DATAVELORIO");
                  AnyError = 1;
                  GX_FocusControl = edtDataVelorio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A56DataVelorio = DateTime.MinValue;
                  AssignAttri("", false, "A56DataVelorio", context.localUtil.Format(A56DataVelorio, "99/99/99"));
               }
               else
               {
                  A56DataVelorio = context.localUtil.CToD( cgiGet( edtDataVelorio_Internalname), 2);
                  AssignAttri("", false, "A56DataVelorio", context.localUtil.Format(A56DataVelorio, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHoraInicio_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora Inicio"}), 1, "HORAINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtHoraInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A57HoraInicio = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A57HoraInicio", context.localUtil.TToC( A57HoraInicio, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A57HoraInicio = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraInicio_Internalname)));
                  AssignAttri("", false, "A57HoraInicio", context.localUtil.TToC( A57HoraInicio, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHoraFim_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora Fim"}), 1, "HORAFIM");
                  AnyError = 1;
                  GX_FocusControl = edtHoraFim_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A58HoraFim = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A58HoraFim", context.localUtil.TToC( A58HoraFim, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A58HoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraFim_Internalname)));
                  AssignAttri("", false, "A58HoraFim", context.localUtil.TToC( A58HoraFim, 0, 5, 0, 3, "/", ":", " "));
               }
               A60SenhaAcesso = cgiGet( edtSenhaAcesso_Internalname);
               AssignAttri("", false, "A60SenhaAcesso", A60SenhaAcesso);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIdEstado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIdEstado_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDESTADO");
                  AnyError = 1;
                  GX_FocusControl = edtIdEstado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A61IdEstado = 0;
                  AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
               }
               else
               {
                  A61IdEstado = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtIdEstado_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
               }
               A62NomeEstado = cgiGet( edtNomeEstado_Internalname);
               AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
               if ( ( ( context.localUtil.CToN( cgiGet( edtIdCidade_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIdCidade_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IDCIDADE");
                  AnyError = 1;
                  GX_FocusControl = edtIdCidade_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A64IdCidade = 0;
                  AssignAttri("", false, "A64IdCidade", StringUtil.LTrimStr( (decimal)(A64IdCidade), 4, 0));
               }
               else
               {
                  A64IdCidade = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtIdCidade_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A64IdCidade", StringUtil.LTrimStr( (decimal)(A64IdCidade), 4, 0));
               }
               A65NomeCidade = cgiGet( edtNomeCidade_Internalname);
               AssignAttri("", false, "A65NomeCidade", A65NomeCidade);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"GerenciadorDeTransmissoes");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("IdTransmissao", context.localUtil.Format( (decimal)(A55IdTransmissao), "ZZZ9"));
               forbiddenHiddens.Add("AoVivo", StringUtil.BoolToStr( A66AoVivo));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("transactions\\gerenciadordetransmissoes:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A55IdTransmissao = (short)(Math.Round(NumberUtil.Val( GetPar( "IdTransmissao"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "");
                        AnyError = 1;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV23Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV23Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_Inscricao = 0;
         AssignAttri("", false, "AV11Insert_Inscricao", StringUtil.LTrimStr( (decimal)(AV11Insert_Inscricao), 9, 0));
         AV12Insert_Nome = "";
         AssignAttri("", false, "AV12Insert_Nome", AV12Insert_Nome);
         AV13Insert_IdEstado = 0;
         AssignAttri("", false, "AV13Insert_IdEstado", StringUtil.LTrimStr( (decimal)(AV13Insert_IdEstado), 4, 0));
         AV14Insert_IdCidade = 0;
         AssignAttri("", false, "AV14Insert_IdCidade", StringUtil.LTrimStr( (decimal)(AV14Insert_IdCidade), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "Inscricao") == 0 )
               {
                  AV11Insert_Inscricao = (int)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_Inscricao", StringUtil.LTrimStr( (decimal)(AV11Insert_Inscricao), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "Nome") == 0 )
               {
                  AV12Insert_Nome = AV15TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV12Insert_Nome", AV12Insert_Nome);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "IdEstado") == 0 )
               {
                  AV13Insert_IdEstado = (short)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_IdEstado", StringUtil.LTrimStr( (decimal)(AV13Insert_IdEstado), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "IdCidade") == 0 )
               {
                  AV14Insert_IdCidade = (short)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_IdCidade", StringUtil.LTrimStr( (decimal)(AV14Insert_IdCidade), 4, 0));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
               AssignAttri("", false, "AV24GXV1", StringUtil.LTrimStr( (decimal)(AV24GXV1), 8, 0));
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("transactions.wwgerenciadordetransmissoes.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_datastore1.close(0);
         pr_default.close(2);
         pr_default.close(3);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z56DataVelorio = T00023_A56DataVelorio[0];
               Z57HoraInicio = T00023_A57HoraInicio[0];
               Z58HoraFim = T00023_A58HoraFim[0];
               Z60SenhaAcesso = T00023_A60SenhaAcesso[0];
               Z66AoVivo = T00023_A66AoVivo[0];
               Z1Inscricao = T00023_A1Inscricao[0];
               Z2Nome = T00023_A2Nome[0];
               Z61IdEstado = T00023_A61IdEstado[0];
               Z64IdCidade = T00023_A64IdCidade[0];
            }
            else
            {
               Z56DataVelorio = A56DataVelorio;
               Z57HoraInicio = A57HoraInicio;
               Z58HoraFim = A58HoraFim;
               Z60SenhaAcesso = A60SenhaAcesso;
               Z66AoVivo = A66AoVivo;
               Z1Inscricao = A1Inscricao;
               Z2Nome = A2Nome;
               Z61IdEstado = A61IdEstado;
               Z64IdCidade = A64IdCidade;
            }
         }
         if ( GX_JID == -23 )
         {
            Z55IdTransmissao = A55IdTransmissao;
            Z56DataVelorio = A56DataVelorio;
            Z57HoraInicio = A57HoraInicio;
            Z58HoraFim = A58HoraFim;
            Z60SenhaAcesso = A60SenhaAcesso;
            Z66AoVivo = A66AoVivo;
            Z1Inscricao = A1Inscricao;
            Z2Nome = A2Nome;
            Z61IdEstado = A61IdEstado;
            Z64IdCidade = A64IdCidade;
            Z62NomeEstado = A62NomeEstado;
            Z65NomeCidade = A65NomeCidade;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_1_2_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"transactions.gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INSCRICAO"+"'), id:'"+"INSCRICAO"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"NOME"+"'), id:'"+"NOME"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_61_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"transactions.gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDESTADO"+"'), id:'"+"IDESTADO"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_64_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"transactions.gx0041.aspx"+"',["+"{Ctrl:gx.dom.el('"+"IDESTADO"+"'), id:'"+"IDESTADO"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"IDCIDADE"+"'), id:'"+"IDCIDADE"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7IdTransmissao) )
         {
            A55IdTransmissao = AV7IdTransmissao;
            AssignAttri("", false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_Inscricao) )
         {
            edtInscricao_Enabled = 0;
            AssignProp("", false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         }
         else
         {
            edtInscricao_Enabled = 1;
            AssignProp("", false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_Nome)) )
         {
            edtNome_Enabled = 0;
            AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         }
         else
         {
            edtNome_Enabled = 1;
            AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_IdEstado) )
         {
            edtIdEstado_Enabled = 0;
            AssignProp("", false, edtIdEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdEstado_Enabled), 5, 0), true);
         }
         else
         {
            edtIdEstado_Enabled = 1;
            AssignProp("", false, edtIdEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdEstado_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_IdCidade) )
         {
            edtIdCidade_Enabled = 0;
            AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), true);
         }
         else
         {
            edtIdCidade_Enabled = 1;
            AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_IdCidade) )
         {
            A64IdCidade = AV14Insert_IdCidade;
            AssignAttri("", false, "A64IdCidade", StringUtil.LTrimStr( (decimal)(A64IdCidade), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_IdEstado) )
         {
            A61IdEstado = AV13Insert_IdEstado;
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV12Insert_Nome)) )
         {
            A2Nome = AV12Insert_Nome;
            AssignAttri("", false, "A2Nome", A2Nome);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_Inscricao) )
         {
            A1Inscricao = AV11Insert_Inscricao;
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
         }
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
            AV23Pgmname = "Transactions.GerenciadorDeTransmissoes";
            AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
            /* Using cursor T00025 */
            pr_default.execute(2, new Object[] {A61IdEstado});
            A62NomeEstado = T00025_A62NomeEstado[0];
            AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
            pr_default.close(2);
            /* Using cursor T00026 */
            pr_default.execute(3, new Object[] {A61IdEstado, A64IdCidade});
            A65NomeCidade = T00026_A65NomeCidade[0];
            AssignAttri("", false, "A65NomeCidade", A65NomeCidade);
            pr_default.close(3);
            /* Using cursor T00024 */
            pr_datastore1.execute(0, new Object[] {A1Inscricao, A2Nome});
            A8Nascimento = T00024_A8Nascimento[0];
            n8Nascimento = T00024_n8Nascimento[0];
            AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
            A9Falecimento = T00024_A9Falecimento[0];
            n9Falecimento = T00024_n9Falecimento[0];
            AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
            pr_datastore1.close(0);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(4, new Object[] {A55IdTransmissao});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound2 = 1;
            A56DataVelorio = T00027_A56DataVelorio[0];
            AssignAttri("", false, "A56DataVelorio", context.localUtil.Format(A56DataVelorio, "99/99/99"));
            A57HoraInicio = T00027_A57HoraInicio[0];
            AssignAttri("", false, "A57HoraInicio", context.localUtil.TToC( A57HoraInicio, 0, 5, 0, 3, "/", ":", " "));
            A58HoraFim = T00027_A58HoraFim[0];
            AssignAttri("", false, "A58HoraFim", context.localUtil.TToC( A58HoraFim, 0, 5, 0, 3, "/", ":", " "));
            A60SenhaAcesso = T00027_A60SenhaAcesso[0];
            AssignAttri("", false, "A60SenhaAcesso", A60SenhaAcesso);
            A62NomeEstado = T00027_A62NomeEstado[0];
            AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
            A65NomeCidade = T00027_A65NomeCidade[0];
            AssignAttri("", false, "A65NomeCidade", A65NomeCidade);
            A66AoVivo = T00027_A66AoVivo[0];
            A1Inscricao = T00027_A1Inscricao[0];
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = T00027_A2Nome[0];
            AssignAttri("", false, "A2Nome", A2Nome);
            A61IdEstado = T00027_A61IdEstado[0];
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
            A64IdCidade = T00027_A64IdCidade[0];
            AssignAttri("", false, "A64IdCidade", StringUtil.LTrimStr( (decimal)(A64IdCidade), 4, 0));
            ZM022( -23) ;
         }
         pr_default.close(4);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV23Pgmname = "Transactions.GerenciadorDeTransmissoes";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         /* Using cursor T00024 */
         pr_datastore1.execute(0, new Object[] {A1Inscricao, A2Nome});
         A8Nascimento = T00024_A8Nascimento[0];
         n8Nascimento = T00024_n8Nascimento[0];
         AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
         A9Falecimento = T00024_A9Falecimento[0];
         n9Falecimento = T00024_n9Falecimento[0];
         AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
         pr_datastore1.close(0);
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV23Pgmname = "Transactions.GerenciadorDeTransmissoes";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         /* Using cursor T00024 */
         pr_datastore1.execute(0, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(0) == 101) )
         {
            GX_msglist.addItem("Não existe 'Obitos'.", "ForeignKeyNotFound", 1, "NOME");
            AnyError = 1;
            GX_FocusControl = edtInscricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8Nascimento = T00024_A8Nascimento[0];
         n8Nascimento = T00024_n8Nascimento[0];
         AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
         A9Falecimento = T00024_A9Falecimento[0];
         n9Falecimento = T00024_n9Falecimento[0];
         AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
         pr_datastore1.close(0);
         if ( ! ( (DateTime.MinValue==A56DataVelorio) || ( DateTimeUtil.ResetTime ( A56DataVelorio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Data Velorio fora do intervalo", "OutOfRange", 1, "DATAVELORIO");
            AnyError = 1;
            GX_FocusControl = edtDataVelorio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A56DataVelorio) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "DATAVELORIO");
            AnyError = 1;
            GX_FocusControl = edtDataVelorio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A57HoraInicio) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "HORAINICIO");
            AnyError = 1;
            GX_FocusControl = edtHoraInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A58HoraFim) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "HORAFIM");
            AnyError = 1;
            GX_FocusControl = edtHoraFim_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A60SenhaAcesso)) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "SENHAACESSO");
            AnyError = 1;
            GX_FocusControl = edtSenhaAcesso_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00025 */
         pr_default.execute(2, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Estados'.", "ForeignKeyNotFound", 1, "IDESTADO");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A62NomeEstado = T00025_A62NomeEstado[0];
         AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A62NomeEstado)) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "");
            AnyError = 1;
         }
         /* Using cursor T00026 */
         pr_default.execute(3, new Object[] {A61IdEstado, A64IdCidade});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Id'.", "ForeignKeyNotFound", 1, "IDCIDADE");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A65NomeCidade = T00026_A65NomeCidade[0];
         AssignAttri("", false, "A65NomeCidade", A65NomeCidade);
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65NomeCidade)) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_datastore1.close(0);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( int A1Inscricao ,
                                string A2Nome )
      {
         /* Using cursor T00028 */
         pr_datastore1.execute(1, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            GX_msglist.addItem("Não existe 'Obitos'.", "ForeignKeyNotFound", 1, "NOME");
            AnyError = 1;
            GX_FocusControl = edtInscricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8Nascimento = T00028_A8Nascimento[0];
         n8Nascimento = T00028_n8Nascimento[0];
         AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
         A9Falecimento = T00028_A9Falecimento[0];
         n9Falecimento = T00028_n9Falecimento[0];
         AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A8Nascimento, "99/99/9999"))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A9Falecimento, "99/99/9999"))+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore1.close(1);
      }

      protected void gxLoad_25( short A61IdEstado )
      {
         /* Using cursor T00029 */
         pr_default.execute(5, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Estados'.", "ForeignKeyNotFound", 1, "IDESTADO");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A62NomeEstado = T00029_A62NomeEstado[0];
         AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A62NomeEstado))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_26( short A61IdEstado ,
                                short A64IdCidade )
      {
         /* Using cursor T000210 */
         pr_default.execute(6, new Object[] {A61IdEstado, A64IdCidade});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Id'.", "ForeignKeyNotFound", 1, "IDCIDADE");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A65NomeCidade = T000210_A65NomeCidade[0];
         AssignAttri("", false, "A65NomeCidade", A65NomeCidade);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A65NomeCidade))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000211 */
         pr_default.execute(7, new Object[] {A55IdTransmissao});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A55IdTransmissao});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 23) ;
            RcdFound2 = 1;
            A55IdTransmissao = T00023_A55IdTransmissao[0];
            A56DataVelorio = T00023_A56DataVelorio[0];
            AssignAttri("", false, "A56DataVelorio", context.localUtil.Format(A56DataVelorio, "99/99/99"));
            A57HoraInicio = T00023_A57HoraInicio[0];
            AssignAttri("", false, "A57HoraInicio", context.localUtil.TToC( A57HoraInicio, 0, 5, 0, 3, "/", ":", " "));
            A58HoraFim = T00023_A58HoraFim[0];
            AssignAttri("", false, "A58HoraFim", context.localUtil.TToC( A58HoraFim, 0, 5, 0, 3, "/", ":", " "));
            A60SenhaAcesso = T00023_A60SenhaAcesso[0];
            AssignAttri("", false, "A60SenhaAcesso", A60SenhaAcesso);
            A66AoVivo = T00023_A66AoVivo[0];
            A1Inscricao = T00023_A1Inscricao[0];
            AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
            A2Nome = T00023_A2Nome[0];
            AssignAttri("", false, "A2Nome", A2Nome);
            A61IdEstado = T00023_A61IdEstado[0];
            AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
            A64IdCidade = T00023_A64IdCidade[0];
            AssignAttri("", false, "A64IdCidade", StringUtil.LTrimStr( (decimal)(A64IdCidade), 4, 0));
            Z55IdTransmissao = A55IdTransmissao;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000212 */
         pr_default.execute(8, new Object[] {A55IdTransmissao});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000212_A55IdTransmissao[0] < A55IdTransmissao ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000212_A55IdTransmissao[0] > A55IdTransmissao ) ) )
            {
               A55IdTransmissao = T000212_A55IdTransmissao[0];
               RcdFound2 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000213 */
         pr_default.execute(9, new Object[] {A55IdTransmissao});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000213_A55IdTransmissao[0] > A55IdTransmissao ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000213_A55IdTransmissao[0] < A55IdTransmissao ) ) )
            {
               A55IdTransmissao = T000213_A55IdTransmissao[0];
               RcdFound2 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtInscricao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A55IdTransmissao != Z55IdTransmissao )
               {
                  A55IdTransmissao = Z55IdTransmissao;
                  AssignAttri("", false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
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
                  Update022( ) ;
                  GX_FocusControl = edtInscricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A55IdTransmissao != Z55IdTransmissao )
               {
                  /* Insert record */
                  GX_FocusControl = edtInscricao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                     AnyError = 1;
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtInscricao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A55IdTransmissao != Z55IdTransmissao )
         {
            A55IdTransmissao = Z55IdTransmissao;
            AssignAttri("", false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
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

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A55IdTransmissao});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"GerenciadorDeTransmissoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z56DataVelorio ) != DateTimeUtil.ResetTime ( T00022_A56DataVelorio[0] ) ) || ( Z57HoraInicio != T00022_A57HoraInicio[0] ) || ( Z58HoraFim != T00022_A58HoraFim[0] ) || ( StringUtil.StrCmp(Z60SenhaAcesso, T00022_A60SenhaAcesso[0]) != 0 ) || ( Z66AoVivo != T00022_A66AoVivo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1Inscricao != T00022_A1Inscricao[0] ) || ( StringUtil.StrCmp(Z2Nome, T00022_A2Nome[0]) != 0 ) || ( Z61IdEstado != T00022_A61IdEstado[0] ) || ( Z64IdCidade != T00022_A64IdCidade[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z56DataVelorio ) != DateTimeUtil.ResetTime ( T00022_A56DataVelorio[0] ) )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"DataVelorio");
                  GXUtil.WriteLogRaw("Old: ",Z56DataVelorio);
                  GXUtil.WriteLogRaw("Current: ",T00022_A56DataVelorio[0]);
               }
               if ( Z57HoraInicio != T00022_A57HoraInicio[0] )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"HoraInicio");
                  GXUtil.WriteLogRaw("Old: ",Z57HoraInicio);
                  GXUtil.WriteLogRaw("Current: ",T00022_A57HoraInicio[0]);
               }
               if ( Z58HoraFim != T00022_A58HoraFim[0] )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"HoraFim");
                  GXUtil.WriteLogRaw("Old: ",Z58HoraFim);
                  GXUtil.WriteLogRaw("Current: ",T00022_A58HoraFim[0]);
               }
               if ( StringUtil.StrCmp(Z60SenhaAcesso, T00022_A60SenhaAcesso[0]) != 0 )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"SenhaAcesso");
                  GXUtil.WriteLogRaw("Old: ",Z60SenhaAcesso);
                  GXUtil.WriteLogRaw("Current: ",T00022_A60SenhaAcesso[0]);
               }
               if ( Z66AoVivo != T00022_A66AoVivo[0] )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"AoVivo");
                  GXUtil.WriteLogRaw("Old: ",Z66AoVivo);
                  GXUtil.WriteLogRaw("Current: ",T00022_A66AoVivo[0]);
               }
               if ( Z1Inscricao != T00022_A1Inscricao[0] )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"Inscricao");
                  GXUtil.WriteLogRaw("Old: ",Z1Inscricao);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1Inscricao[0]);
               }
               if ( StringUtil.StrCmp(Z2Nome, T00022_A2Nome[0]) != 0 )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"Nome");
                  GXUtil.WriteLogRaw("Old: ",Z2Nome);
                  GXUtil.WriteLogRaw("Current: ",T00022_A2Nome[0]);
               }
               if ( Z61IdEstado != T00022_A61IdEstado[0] )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"IdEstado");
                  GXUtil.WriteLogRaw("Old: ",Z61IdEstado);
                  GXUtil.WriteLogRaw("Current: ",T00022_A61IdEstado[0]);
               }
               if ( Z64IdCidade != T00022_A64IdCidade[0] )
               {
                  GXUtil.WriteLog("transactions.gerenciadordetransmissoes:[seudo value changed for attri]"+"IdCidade");
                  GXUtil.WriteLogRaw("Old: ",Z64IdCidade);
                  GXUtil.WriteLogRaw("Current: ",T00022_A64IdCidade[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"GerenciadorDeTransmissoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000214 */
                     pr_default.execute(10, new Object[] {A56DataVelorio, A57HoraInicio, A58HoraFim, A60SenhaAcesso, A66AoVivo, A1Inscricao, A2Nome, A61IdEstado, A64IdCidade});
                     A55IdTransmissao = T000214_A55IdTransmissao[0];
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("GerenciadorDeTransmissoes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000215 */
                     pr_default.execute(11, new Object[] {A56DataVelorio, A57HoraInicio, A58HoraFim, A60SenhaAcesso, A66AoVivo, A1Inscricao, A2Nome, A61IdEstado, A64IdCidade, A55IdTransmissao});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("GerenciadorDeTransmissoes");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"GerenciadorDeTransmissoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000216 */
                  pr_default.execute(12, new Object[] {A55IdTransmissao});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("GerenciadorDeTransmissoes");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV23Pgmname = "Transactions.GerenciadorDeTransmissoes";
            AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
            /* Using cursor T000217 */
            pr_datastore1.execute(2, new Object[] {A1Inscricao, A2Nome});
            A8Nascimento = T000217_A8Nascimento[0];
            n8Nascimento = T000217_n8Nascimento[0];
            AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
            A9Falecimento = T000217_A9Falecimento[0];
            n9Falecimento = T000217_n9Falecimento[0];
            AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
            pr_datastore1.close(2);
            /* Using cursor T000218 */
            pr_default.execute(13, new Object[] {A61IdEstado});
            A62NomeEstado = T000218_A62NomeEstado[0];
            AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
            pr_default.close(13);
            /* Using cursor T000219 */
            pr_default.execute(14, new Object[] {A61IdEstado, A64IdCidade});
            A65NomeCidade = T000219_A65NomeCidade[0];
            AssignAttri("", false, "A65NomeCidade", A65NomeCidade);
            pr_default.close(14);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_datastore1.close(2);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("transactions.gerenciadordetransmissoes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_datastore1.close(2);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("transactions.gerenciadordetransmissoes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000220 */
         pr_default.execute(15);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A55IdTransmissao = T000220_A55IdTransmissao[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A55IdTransmissao = T000220_A55IdTransmissao[0];
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtInscricao_Enabled = 0;
         AssignProp("", false, edtInscricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInscricao_Enabled), 5, 0), true);
         edtNome_Enabled = 0;
         AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         edtNascimento_Enabled = 0;
         AssignProp("", false, edtNascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNascimento_Enabled), 5, 0), true);
         edtFalecimento_Enabled = 0;
         AssignProp("", false, edtFalecimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFalecimento_Enabled), 5, 0), true);
         edtDataVelorio_Enabled = 0;
         AssignProp("", false, edtDataVelorio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDataVelorio_Enabled), 5, 0), true);
         edtHoraInicio_Enabled = 0;
         AssignProp("", false, edtHoraInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHoraInicio_Enabled), 5, 0), true);
         edtHoraFim_Enabled = 0;
         AssignProp("", false, edtHoraFim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHoraFim_Enabled), 5, 0), true);
         edtSenhaAcesso_Enabled = 0;
         AssignProp("", false, edtSenhaAcesso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSenhaAcesso_Enabled), 5, 0), true);
         edtIdEstado_Enabled = 0;
         AssignProp("", false, edtIdEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdEstado_Enabled), 5, 0), true);
         edtNomeEstado_Enabled = 0;
         AssignProp("", false, edtNomeEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNomeEstado_Enabled), 5, 0), true);
         edtIdCidade_Enabled = 0;
         AssignProp("", false, edtIdCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIdCidade_Enabled), 5, 0), true);
         edtNomeCidade_Enabled = 0;
         AssignProp("", false, edtNomeCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNomeCidade_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("transactions.gerenciadordetransmissoes.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IdTransmissao,4,0))}, new string[] {"Gx_mode","IdTransmissao"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"GerenciadorDeTransmissoes");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("IdTransmissao", context.localUtil.Format( (decimal)(A55IdTransmissao), "ZZZ9"));
         forbiddenHiddens.Add("AoVivo", StringUtil.BoolToStr( A66AoVivo));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("transactions\\gerenciadordetransmissoes:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z55IdTransmissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z55IdTransmissao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z56DataVelorio", context.localUtil.DToC( Z56DataVelorio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z57HoraInicio", context.localUtil.TToC( Z57HoraInicio, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z58HoraFim", context.localUtil.TToC( Z58HoraFim, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z60SenhaAcesso", Z60SenhaAcesso);
         GxWebStd.gx_boolean_hidden_field( context, "Z66AoVivo", Z66AoVivo);
         GxWebStd.gx_hidden_field( context, "Z1Inscricao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1Inscricao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2Nome", Z2Nome);
         GxWebStd.gx_hidden_field( context, "Z61IdEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61IdEstado), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z64IdCidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64IdCidade), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1Inscricao", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1Inscricao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N2Nome", A2Nome);
         GxWebStd.gx_hidden_field( context, "N61IdEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A61IdEstado), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N64IdCidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64IdCidade), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vIDTRANSMISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7IdTransmissao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vIDTRANSMISSAO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7IdTransmissao), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "IDTRANSMISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A55IdTransmissao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_INSCRICAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_Inscricao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_NOME", AV12Insert_Nome);
         GxWebStd.gx_hidden_field( context, "vINSERT_IDESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_IdEstado), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_IDCIDADE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_IdCidade), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "AOVIVO", A66AoVivo);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
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
         return formatLink("transactions.gerenciadordetransmissoes.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7IdTransmissao,4,0))}, new string[] {"Gx_mode","IdTransmissao"})  ;
      }

      public override string GetPgmname( )
      {
         return "Transactions.GerenciadorDeTransmissoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Gerenciador De Transmissões | Velório Gold" ;
      }

      protected void InitializeNonKey022( )
      {
         A1Inscricao = 0;
         AssignAttri("", false, "A1Inscricao", StringUtil.LTrimStr( (decimal)(A1Inscricao), 9, 0));
         A2Nome = "";
         AssignAttri("", false, "A2Nome", A2Nome);
         A61IdEstado = 0;
         AssignAttri("", false, "A61IdEstado", StringUtil.LTrimStr( (decimal)(A61IdEstado), 4, 0));
         A64IdCidade = 0;
         AssignAttri("", false, "A64IdCidade", StringUtil.LTrimStr( (decimal)(A64IdCidade), 4, 0));
         A8Nascimento = DateTime.MinValue;
         n8Nascimento = false;
         AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
         A9Falecimento = DateTime.MinValue;
         n9Falecimento = false;
         AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
         A56DataVelorio = DateTime.MinValue;
         AssignAttri("", false, "A56DataVelorio", context.localUtil.Format(A56DataVelorio, "99/99/99"));
         A57HoraInicio = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A57HoraInicio", context.localUtil.TToC( A57HoraInicio, 0, 5, 0, 3, "/", ":", " "));
         A58HoraFim = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A58HoraFim", context.localUtil.TToC( A58HoraFim, 0, 5, 0, 3, "/", ":", " "));
         A60SenhaAcesso = "";
         AssignAttri("", false, "A60SenhaAcesso", A60SenhaAcesso);
         A62NomeEstado = "";
         AssignAttri("", false, "A62NomeEstado", A62NomeEstado);
         A65NomeCidade = "";
         AssignAttri("", false, "A65NomeCidade", A65NomeCidade);
         A66AoVivo = false;
         AssignAttri("", false, "A66AoVivo", A66AoVivo);
         Z56DataVelorio = DateTime.MinValue;
         Z57HoraInicio = (DateTime)(DateTime.MinValue);
         Z58HoraFim = (DateTime)(DateTime.MinValue);
         Z60SenhaAcesso = "";
         Z66AoVivo = false;
         Z1Inscricao = 0;
         Z2Nome = "";
         Z61IdEstado = 0;
         Z64IdCidade = 0;
      }

      protected void InitAll022( )
      {
         A55IdTransmissao = 0;
         AssignAttri("", false, "A55IdTransmissao", StringUtil.LTrimStr( (decimal)(A55IdTransmissao), 4, 0));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248251941165", true, true);
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
         context.AddJavascriptSource("transactions/gerenciadordetransmissoes.js", "?20248251941165", false, true);
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
         edtNascimento_Internalname = "NASCIMENTO";
         edtFalecimento_Internalname = "FALECIMENTO";
         edtDataVelorio_Internalname = "DATAVELORIO";
         edtHoraInicio_Internalname = "HORAINICIO";
         edtHoraFim_Internalname = "HORAFIM";
         edtSenhaAcesso_Internalname = "SENHAACESSO";
         edtIdEstado_Internalname = "IDESTADO";
         edtNomeEstado_Internalname = "NOMEESTADO";
         edtIdCidade_Internalname = "IDCIDADE";
         edtNomeCidade_Internalname = "NOMECIDADE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_2_Internalname = "PROMPT_1_2";
         imgprompt_61_Internalname = "PROMPT_61";
         imgprompt_64_Internalname = "PROMPT_64";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Gerenciador De Transmissões | Velório Gold";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtNomeCidade_Jsonclick = "";
         edtNomeCidade_Enabled = 0;
         imgprompt_64_Visible = 1;
         imgprompt_64_Link = "";
         edtIdCidade_Jsonclick = "";
         edtIdCidade_Enabled = 1;
         edtNomeEstado_Jsonclick = "";
         edtNomeEstado_Enabled = 0;
         imgprompt_61_Visible = 1;
         imgprompt_61_Link = "";
         edtIdEstado_Jsonclick = "";
         edtIdEstado_Enabled = 1;
         edtSenhaAcesso_Jsonclick = "";
         edtSenhaAcesso_Enabled = 1;
         edtHoraFim_Jsonclick = "";
         edtHoraFim_Enabled = 1;
         edtHoraInicio_Jsonclick = "";
         edtHoraInicio_Enabled = 1;
         edtDataVelorio_Jsonclick = "";
         edtDataVelorio_Enabled = 1;
         edtFalecimento_Jsonclick = "";
         edtFalecimento_Enabled = 0;
         edtNascimento_Jsonclick = "";
         edtNascimento_Enabled = 0;
         imgprompt_1_2_Visible = 1;
         imgprompt_1_2_Link = "";
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

      public void Valid_Nome( )
      {
         n8Nascimento = false;
         n9Falecimento = false;
         /* Using cursor T000217 */
         pr_datastore1.execute(2, new Object[] {A1Inscricao, A2Nome});
         if ( (pr_datastore1.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Obitos'.", "ForeignKeyNotFound", 1, "NOME");
            AnyError = 1;
            GX_FocusControl = edtInscricao_Internalname;
         }
         A8Nascimento = T000217_A8Nascimento[0];
         n8Nascimento = T000217_n8Nascimento[0];
         A9Falecimento = T000217_A9Falecimento[0];
         n9Falecimento = T000217_n9Falecimento[0];
         pr_datastore1.close(2);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8Nascimento", context.localUtil.Format(A8Nascimento, "99/99/9999"));
         AssignAttri("", false, "A9Falecimento", context.localUtil.Format(A9Falecimento, "99/99/9999"));
      }

      public void Valid_Idestado( )
      {
         /* Using cursor T000218 */
         pr_default.execute(13, new Object[] {A61IdEstado});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Estados'.", "ForeignKeyNotFound", 1, "IDESTADO");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
         }
         A62NomeEstado = T000218_A62NomeEstado[0];
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A62NomeEstado)) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "IDESTADO");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A62NomeEstado", StringUtil.RTrim( A62NomeEstado));
      }

      public void Valid_Idcidade( )
      {
         /* Using cursor T000219 */
         pr_default.execute(14, new Object[] {A61IdEstado, A64IdCidade});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Id'.", "ForeignKeyNotFound", 1, "IDCIDADE");
            AnyError = 1;
            GX_FocusControl = edtIdEstado_Internalname;
         }
         A65NomeCidade = T000219_A65NomeCidade[0];
         pr_default.close(14);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A65NomeCidade)) )
         {
            GX_msglist.addItem("Esse campo é obrigatório", 1, "IDCIDADE");
            AnyError = 1;
            GX_FocusControl = edtIdCidade_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A65NomeCidade", StringUtil.RTrim( A65NomeCidade));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7IdTransmissao","fld":"vIDTRANSMISSAO","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7IdTransmissao","fld":"vIDTRANSMISSAO","pic":"ZZZ9","hsh":true},{"av":"A55IdTransmissao","fld":"IDTRANSMISSAO","pic":"ZZZ9"},{"av":"A66AoVivo","fld":"AOVIVO"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12022","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_INSCRICAO","""{"handler":"Valid_Inscricao","iparms":[]}""");
         setEventMetadata("VALID_NOME","""{"handler":"Valid_Nome","iparms":[{"av":"A1Inscricao","fld":"INSCRICAO","pic":"ZZZZZZZZ9"},{"av":"A2Nome","fld":"NOME"},{"av":"A8Nascimento","fld":"NASCIMENTO"},{"av":"A9Falecimento","fld":"FALECIMENTO"}]""");
         setEventMetadata("VALID_NOME",""","oparms":[{"av":"A8Nascimento","fld":"NASCIMENTO"},{"av":"A9Falecimento","fld":"FALECIMENTO"}]}""");
         setEventMetadata("VALID_DATAVELORIO","""{"handler":"Valid_Datavelorio","iparms":[]}""");
         setEventMetadata("VALID_HORAINICIO","""{"handler":"Valid_Horainicio","iparms":[]}""");
         setEventMetadata("VALID_HORAFIM","""{"handler":"Valid_Horafim","iparms":[]}""");
         setEventMetadata("VALID_SENHAACESSO","""{"handler":"Valid_Senhaacesso","iparms":[]}""");
         setEventMetadata("VALID_IDESTADO","""{"handler":"Valid_Idestado","iparms":[{"av":"A61IdEstado","fld":"IDESTADO","pic":"ZZZ9"},{"av":"A62NomeEstado","fld":"NOMEESTADO"}]""");
         setEventMetadata("VALID_IDESTADO",""","oparms":[{"av":"A62NomeEstado","fld":"NOMEESTADO"}]}""");
         setEventMetadata("VALID_NOMEESTADO","""{"handler":"Valid_Nomeestado","iparms":[]}""");
         setEventMetadata("VALID_IDCIDADE","""{"handler":"Valid_Idcidade","iparms":[{"av":"A61IdEstado","fld":"IDESTADO","pic":"ZZZ9"},{"av":"A64IdCidade","fld":"IDCIDADE","pic":"ZZZ9"},{"av":"A65NomeCidade","fld":"NOMECIDADE"}]""");
         setEventMetadata("VALID_IDCIDADE",""","oparms":[{"av":"A65NomeCidade","fld":"NOMECIDADE"}]}""");
         setEventMetadata("VALID_NOMECIDADE","""{"handler":"Valid_Nomecidade","iparms":[]}""");
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
         pr_datastore1.close(2);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z56DataVelorio = DateTime.MinValue;
         Z57HoraInicio = (DateTime)(DateTime.MinValue);
         Z58HoraFim = (DateTime)(DateTime.MinValue);
         Z60SenhaAcesso = "";
         Z2Nome = "";
         N2Nome = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2Nome = "";
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
         imgprompt_1_2_gximage = "";
         sImgUrl = "";
         A8Nascimento = DateTime.MinValue;
         A9Falecimento = DateTime.MinValue;
         A56DataVelorio = DateTime.MinValue;
         A57HoraInicio = (DateTime)(DateTime.MinValue);
         A58HoraFim = (DateTime)(DateTime.MinValue);
         A60SenhaAcesso = "";
         imgprompt_61_gximage = "";
         A62NomeEstado = "";
         imgprompt_64_gximage = "";
         A65NomeCidade = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV12Insert_Nome = "";
         AV23Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z62NomeEstado = "";
         Z65NomeCidade = "";
         T00025_A62NomeEstado = new string[] {""} ;
         T00026_A65NomeCidade = new string[] {""} ;
         T00024_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         T00024_n8Nascimento = new bool[] {false} ;
         T00024_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         T00024_n9Falecimento = new bool[] {false} ;
         T00027_A55IdTransmissao = new short[1] ;
         T00027_A56DataVelorio = new DateTime[] {DateTime.MinValue} ;
         T00027_A57HoraInicio = new DateTime[] {DateTime.MinValue} ;
         T00027_A58HoraFim = new DateTime[] {DateTime.MinValue} ;
         T00027_A60SenhaAcesso = new string[] {""} ;
         T00027_A62NomeEstado = new string[] {""} ;
         T00027_A65NomeCidade = new string[] {""} ;
         T00027_A66AoVivo = new bool[] {false} ;
         T00027_A1Inscricao = new int[1] ;
         T00027_A2Nome = new string[] {""} ;
         T00027_A61IdEstado = new short[1] ;
         T00027_A64IdCidade = new short[1] ;
         T00028_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         T00028_n8Nascimento = new bool[] {false} ;
         T00028_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         T00028_n9Falecimento = new bool[] {false} ;
         T00029_A62NomeEstado = new string[] {""} ;
         T000210_A65NomeCidade = new string[] {""} ;
         T000211_A55IdTransmissao = new short[1] ;
         T00023_A55IdTransmissao = new short[1] ;
         T00023_A56DataVelorio = new DateTime[] {DateTime.MinValue} ;
         T00023_A57HoraInicio = new DateTime[] {DateTime.MinValue} ;
         T00023_A58HoraFim = new DateTime[] {DateTime.MinValue} ;
         T00023_A60SenhaAcesso = new string[] {""} ;
         T00023_A66AoVivo = new bool[] {false} ;
         T00023_A1Inscricao = new int[1] ;
         T00023_A2Nome = new string[] {""} ;
         T00023_A61IdEstado = new short[1] ;
         T00023_A64IdCidade = new short[1] ;
         T000212_A55IdTransmissao = new short[1] ;
         T000213_A55IdTransmissao = new short[1] ;
         T00022_A55IdTransmissao = new short[1] ;
         T00022_A56DataVelorio = new DateTime[] {DateTime.MinValue} ;
         T00022_A57HoraInicio = new DateTime[] {DateTime.MinValue} ;
         T00022_A58HoraFim = new DateTime[] {DateTime.MinValue} ;
         T00022_A60SenhaAcesso = new string[] {""} ;
         T00022_A66AoVivo = new bool[] {false} ;
         T00022_A1Inscricao = new int[1] ;
         T00022_A2Nome = new string[] {""} ;
         T00022_A61IdEstado = new short[1] ;
         T00022_A64IdCidade = new short[1] ;
         T000214_A55IdTransmissao = new short[1] ;
         T000217_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         T000217_n8Nascimento = new bool[] {false} ;
         T000217_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         T000217_n9Falecimento = new bool[] {false} ;
         T000218_A62NomeEstado = new string[] {""} ;
         T000219_A65NomeCidade = new string[] {""} ;
         T000220_A55IdTransmissao = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z8Nascimento = DateTime.MinValue;
         Z9Falecimento = DateTime.MinValue;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.transactions.gerenciadordetransmissoes__gam(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.transactions.gerenciadordetransmissoes__datastore1(),
            new Object[][] {
                new Object[] {
               T00024_A8Nascimento, T00024_n8Nascimento, T00024_A9Falecimento, T00024_n9Falecimento
               }
               , new Object[] {
               T00028_A8Nascimento, T00028_n8Nascimento, T00028_A9Falecimento, T00028_n9Falecimento
               }
               , new Object[] {
               T000217_A8Nascimento, T000217_n8Nascimento, T000217_A9Falecimento, T000217_n9Falecimento
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.transactions.gerenciadordetransmissoes__default(),
            new Object[][] {
                new Object[] {
               T00022_A55IdTransmissao, T00022_A56DataVelorio, T00022_A57HoraInicio, T00022_A58HoraFim, T00022_A60SenhaAcesso, T00022_A66AoVivo, T00022_A1Inscricao, T00022_A2Nome, T00022_A61IdEstado, T00022_A64IdCidade
               }
               , new Object[] {
               T00023_A55IdTransmissao, T00023_A56DataVelorio, T00023_A57HoraInicio, T00023_A58HoraFim, T00023_A60SenhaAcesso, T00023_A66AoVivo, T00023_A1Inscricao, T00023_A2Nome, T00023_A61IdEstado, T00023_A64IdCidade
               }
               , new Object[] {
               T00025_A62NomeEstado
               }
               , new Object[] {
               T00026_A65NomeCidade
               }
               , new Object[] {
               T00027_A55IdTransmissao, T00027_A56DataVelorio, T00027_A57HoraInicio, T00027_A58HoraFim, T00027_A60SenhaAcesso, T00027_A62NomeEstado, T00027_A65NomeCidade, T00027_A66AoVivo, T00027_A1Inscricao, T00027_A2Nome,
               T00027_A61IdEstado, T00027_A64IdCidade
               }
               , new Object[] {
               T00029_A62NomeEstado
               }
               , new Object[] {
               T000210_A65NomeCidade
               }
               , new Object[] {
               T000211_A55IdTransmissao
               }
               , new Object[] {
               T000212_A55IdTransmissao
               }
               , new Object[] {
               T000213_A55IdTransmissao
               }
               , new Object[] {
               T000214_A55IdTransmissao
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000218_A62NomeEstado
               }
               , new Object[] {
               T000219_A65NomeCidade
               }
               , new Object[] {
               T000220_A55IdTransmissao
               }
            }
         );
         AV23Pgmname = "Transactions.GerenciadorDeTransmissoes";
      }

      private short wcpOAV7IdTransmissao ;
      private short Z55IdTransmissao ;
      private short Z61IdEstado ;
      private short Z64IdCidade ;
      private short N61IdEstado ;
      private short N64IdCidade ;
      private short GxWebError ;
      private short A61IdEstado ;
      private short A64IdCidade ;
      private short AV7IdTransmissao ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A55IdTransmissao ;
      private short AV13Insert_IdEstado ;
      private short AV14Insert_IdCidade ;
      private short RcdFound2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1Inscricao ;
      private int N1Inscricao ;
      private int A1Inscricao ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtInscricao_Enabled ;
      private int edtNome_Enabled ;
      private int imgprompt_1_2_Visible ;
      private int edtNascimento_Enabled ;
      private int edtFalecimento_Enabled ;
      private int edtDataVelorio_Enabled ;
      private int edtHoraInicio_Enabled ;
      private int edtHoraFim_Enabled ;
      private int edtSenhaAcesso_Enabled ;
      private int edtIdEstado_Enabled ;
      private int imgprompt_61_Visible ;
      private int edtNomeEstado_Enabled ;
      private int edtIdCidade_Enabled ;
      private int imgprompt_64_Visible ;
      private int edtNomeCidade_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_Inscricao ;
      private int AV24GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
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
      private string imgprompt_1_2_gximage ;
      private string sImgUrl ;
      private string imgprompt_1_2_Internalname ;
      private string imgprompt_1_2_Link ;
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
      private string edtSenhaAcesso_Internalname ;
      private string edtSenhaAcesso_Jsonclick ;
      private string edtIdEstado_Internalname ;
      private string edtIdEstado_Jsonclick ;
      private string imgprompt_61_gximage ;
      private string imgprompt_61_Internalname ;
      private string imgprompt_61_Link ;
      private string edtNomeEstado_Internalname ;
      private string A62NomeEstado ;
      private string edtNomeEstado_Jsonclick ;
      private string edtIdCidade_Internalname ;
      private string edtIdCidade_Jsonclick ;
      private string imgprompt_64_gximage ;
      private string imgprompt_64_Internalname ;
      private string imgprompt_64_Link ;
      private string edtNomeCidade_Internalname ;
      private string A65NomeCidade ;
      private string edtNomeCidade_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV23Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z62NomeEstado ;
      private string Z65NomeCidade ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z57HoraInicio ;
      private DateTime Z58HoraFim ;
      private DateTime A57HoraInicio ;
      private DateTime A58HoraFim ;
      private DateTime Z56DataVelorio ;
      private DateTime A8Nascimento ;
      private DateTime A9Falecimento ;
      private DateTime A56DataVelorio ;
      private DateTime Z8Nascimento ;
      private DateTime Z9Falecimento ;
      private bool Z66AoVivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A66AoVivo ;
      private bool n8Nascimento ;
      private bool n9Falecimento ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z60SenhaAcesso ;
      private string Z2Nome ;
      private string N2Nome ;
      private string A2Nome ;
      private string A60SenhaAcesso ;
      private string AV12Insert_Nome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private string[] T00025_A62NomeEstado ;
      private string[] T00026_A65NomeCidade ;
      private IDataStoreProvider pr_datastore1 ;
      private DateTime[] T00024_A8Nascimento ;
      private bool[] T00024_n8Nascimento ;
      private DateTime[] T00024_A9Falecimento ;
      private bool[] T00024_n9Falecimento ;
      private short[] T00027_A55IdTransmissao ;
      private DateTime[] T00027_A56DataVelorio ;
      private DateTime[] T00027_A57HoraInicio ;
      private DateTime[] T00027_A58HoraFim ;
      private string[] T00027_A60SenhaAcesso ;
      private string[] T00027_A62NomeEstado ;
      private string[] T00027_A65NomeCidade ;
      private bool[] T00027_A66AoVivo ;
      private int[] T00027_A1Inscricao ;
      private string[] T00027_A2Nome ;
      private short[] T00027_A61IdEstado ;
      private short[] T00027_A64IdCidade ;
      private DateTime[] T00028_A8Nascimento ;
      private bool[] T00028_n8Nascimento ;
      private DateTime[] T00028_A9Falecimento ;
      private bool[] T00028_n9Falecimento ;
      private string[] T00029_A62NomeEstado ;
      private string[] T000210_A65NomeCidade ;
      private short[] T000211_A55IdTransmissao ;
      private short[] T00023_A55IdTransmissao ;
      private DateTime[] T00023_A56DataVelorio ;
      private DateTime[] T00023_A57HoraInicio ;
      private DateTime[] T00023_A58HoraFim ;
      private string[] T00023_A60SenhaAcesso ;
      private bool[] T00023_A66AoVivo ;
      private int[] T00023_A1Inscricao ;
      private string[] T00023_A2Nome ;
      private short[] T00023_A61IdEstado ;
      private short[] T00023_A64IdCidade ;
      private short[] T000212_A55IdTransmissao ;
      private short[] T000213_A55IdTransmissao ;
      private short[] T00022_A55IdTransmissao ;
      private DateTime[] T00022_A56DataVelorio ;
      private DateTime[] T00022_A57HoraInicio ;
      private DateTime[] T00022_A58HoraFim ;
      private string[] T00022_A60SenhaAcesso ;
      private bool[] T00022_A66AoVivo ;
      private int[] T00022_A1Inscricao ;
      private string[] T00022_A2Nome ;
      private short[] T00022_A61IdEstado ;
      private short[] T00022_A64IdCidade ;
      private short[] T000214_A55IdTransmissao ;
      private DateTime[] T000217_A8Nascimento ;
      private bool[] T000217_n8Nascimento ;
      private DateTime[] T000217_A9Falecimento ;
      private bool[] T000217_n9Falecimento ;
      private string[] T000218_A62NomeEstado ;
      private string[] T000219_A65NomeCidade ;
      private short[] T000220_A55IdTransmissao ;
      private IDataStoreProvider pr_gam ;
   }

   public class gerenciadordetransmissoes__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gerenciadordetransmissoes__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("@Inscricao",GXType.Int32,9,0) ,
        new ParDef("@Nome",GXType.NVarChar,50,0)
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("@Inscricao",GXType.Int32,9,0) ,
        new ParDef("@Nome",GXType.NVarChar,50,0)
        };
        Object[] prmT000217;
        prmT000217 = new Object[] {
        new ParDef("@Inscricao",GXType.Int32,9,0) ,
        new ParDef("@Nome",GXType.NVarChar,50,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00024", "SELECT [Nascimento], [Falecimento] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00028", "SELECT [Nascimento], [Falecimento] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000217", "SELECT [Nascimento], [Falecimento] FROM dbo.[Obitos] WHERE [Inscricao] = @Inscricao AND [Nome] = @Nome ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,false )
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
           case 2 :
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

public class gerenciadordetransmissoes__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00022;
       prmT00022 = new Object[] {
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT00023;
       prmT00023 = new Object[] {
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT00025;
       prmT00025 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT00026;
       prmT00026 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT00027;
       prmT00027 = new Object[] {
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT00029;
       prmT00029 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT000210;
       prmT000210 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000211;
       prmT000211 = new Object[] {
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT000212;
       prmT000212 = new Object[] {
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT000213;
       prmT000213 = new Object[] {
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT000214;
       prmT000214 = new Object[] {
       new ParDef("@DataVelorio",GXType.Date,8,0) ,
       new ParDef("@HoraInicio",GXType.DateTime,0,5) ,
       new ParDef("@HoraFim",GXType.DateTime,0,5) ,
       new ParDef("@SenhaAcesso",GXType.NVarChar,70,0) ,
       new ParDef("@AoVivo",GXType.Boolean,4,0) ,
       new ParDef("@Inscricao",GXType.Int32,9,0) ,
       new ParDef("@Nome",GXType.NVarChar,50,0) ,
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000215;
       prmT000215 = new Object[] {
       new ParDef("@DataVelorio",GXType.Date,8,0) ,
       new ParDef("@HoraInicio",GXType.DateTime,0,5) ,
       new ParDef("@HoraFim",GXType.DateTime,0,5) ,
       new ParDef("@SenhaAcesso",GXType.NVarChar,70,0) ,
       new ParDef("@AoVivo",GXType.Boolean,4,0) ,
       new ParDef("@Inscricao",GXType.Int32,9,0) ,
       new ParDef("@Nome",GXType.NVarChar,50,0) ,
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0) ,
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT000216;
       prmT000216 = new Object[] {
       new ParDef("@IdTransmissao",GXType.Int16,4,0)
       };
       Object[] prmT000218;
       prmT000218 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0)
       };
       Object[] prmT000219;
       prmT000219 = new Object[] {
       new ParDef("@IdEstado",GXType.Int16,4,0) ,
       new ParDef("@IdCidade",GXType.Int16,4,0)
       };
       Object[] prmT000220;
       prmT000220 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T00022", "SELECT [IdTransmissao], [DataVelorio], [HoraInicio], [HoraFim], [SenhaAcesso], [AoVivo], [Inscricao], [Nome], [IdEstado], [IdCidade] FROM [GerenciadorDeTransmissoes] WITH (UPDLOCK) WHERE [IdTransmissao] = @IdTransmissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00023", "SELECT [IdTransmissao], [DataVelorio], [HoraInicio], [HoraFim], [SenhaAcesso], [AoVivo], [Inscricao], [Nome], [IdEstado], [IdCidade] FROM [GerenciadorDeTransmissoes] WHERE [IdTransmissao] = @IdTransmissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00025", "SELECT [NomeEstado] FROM [Estados] WHERE [IdEstado] = @IdEstado ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00026", "SELECT [NomeCidade] FROM [EstadosId] WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00027", "SELECT TM1.[IdTransmissao], TM1.[DataVelorio], TM1.[HoraInicio], TM1.[HoraFim], TM1.[SenhaAcesso], T2.[NomeEstado], T3.[NomeCidade], TM1.[AoVivo], TM1.[Inscricao], TM1.[Nome], TM1.[IdEstado], TM1.[IdCidade] FROM (([GerenciadorDeTransmissoes] TM1 INNER JOIN [Estados] T2 ON T2.[IdEstado] = TM1.[IdEstado]) INNER JOIN [EstadosId] T3 ON T3.[IdEstado] = TM1.[IdEstado] AND T3.[IdCidade] = TM1.[IdCidade]) WHERE TM1.[IdTransmissao] = @IdTransmissao ORDER BY TM1.[IdTransmissao]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00029", "SELECT [NomeEstado] FROM [Estados] WHERE [IdEstado] = @IdEstado ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000210", "SELECT [NomeCidade] FROM [EstadosId] WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000211", "SELECT [IdTransmissao] FROM [GerenciadorDeTransmissoes] WHERE [IdTransmissao] = @IdTransmissao  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000212", "SELECT TOP 1 [IdTransmissao] FROM [GerenciadorDeTransmissoes] WHERE ( [IdTransmissao] > @IdTransmissao) ORDER BY [IdTransmissao]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000213", "SELECT TOP 1 [IdTransmissao] FROM [GerenciadorDeTransmissoes] WHERE ( [IdTransmissao] < @IdTransmissao) ORDER BY [IdTransmissao] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000214", "INSERT INTO [GerenciadorDeTransmissoes]([DataVelorio], [HoraInicio], [HoraFim], [SenhaAcesso], [AoVivo], [Inscricao], [Nome], [IdEstado], [IdCidade]) VALUES(@DataVelorio, @HoraInicio, @HoraFim, @SenhaAcesso, @AoVivo, @Inscricao, @Nome, @IdEstado, @IdCidade); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000215", "UPDATE [GerenciadorDeTransmissoes] SET [DataVelorio]=@DataVelorio, [HoraInicio]=@HoraInicio, [HoraFim]=@HoraFim, [SenhaAcesso]=@SenhaAcesso, [AoVivo]=@AoVivo, [Inscricao]=@Inscricao, [Nome]=@Nome, [IdEstado]=@IdEstado, [IdCidade]=@IdCidade  WHERE [IdTransmissao] = @IdTransmissao", GxErrorMask.GX_NOMASK,prmT000215)
          ,new CursorDef("T000216", "DELETE FROM [GerenciadorDeTransmissoes]  WHERE [IdTransmissao] = @IdTransmissao", GxErrorMask.GX_NOMASK,prmT000216)
          ,new CursorDef("T000218", "SELECT [NomeEstado] FROM [Estados] WHERE [IdEstado] = @IdEstado ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000219", "SELECT [NomeCidade] FROM [EstadosId] WHERE [IdEstado] = @IdEstado AND [IdCidade] = @IdCidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000220", "SELECT [IdTransmissao] FROM [GerenciadorDeTransmissoes] ORDER BY [IdTransmissao]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((int[]) buf[6])[0] = rslt.getInt(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((int[]) buf[6])[0] = rslt.getInt(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 2);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 4 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getString(6, 2);
             ((string[]) buf[6])[0] = rslt.getString(7, 40);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((int[]) buf[8])[0] = rslt.getInt(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((short[]) buf[11])[0] = rslt.getShort(12);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getString(1, 2);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 7 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 8 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 9 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 10 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getString(1, 2);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             return;
          case 15 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
