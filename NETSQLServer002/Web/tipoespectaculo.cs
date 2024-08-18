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
   public class tipoespectaculo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A2TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A2TipoEspectaculoId) ;
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
               AV7TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV7TipoEspectaculoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTIPOESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipoEspectaculoId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Tipo Espectaculo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipoEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipoespectaculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public tipoespectaculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_TipoEspectaculoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipoEspectaculoId = aP1_TipoEspectaculoId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tipo de Espectáculo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TipoEspectaculo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoEspectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoEspectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoEspectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoEspectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TipoEspectaculo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoId_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2TipoEspectaculoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtTipoEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A2TipoEspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A2TipoEspectaculoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_TipoEspectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoEspectaculoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoNombre_Internalname, "Espectaculo Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoNombre_Internalname, A12TipoEspectaculoNombre, StringUtil.RTrim( context.localUtil.Format( A12TipoEspectaculoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_TipoEspectaculo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoEspectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoEspectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TipoEspectaculo.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z2TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z2TipoEspectaculoId"), ".", ","), 18, MidpointRounding.ToEven));
               Z12TipoEspectaculoNombre = cgiGet( "Z12TipoEspectaculoNombre");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vTIPOESPECTACULOID"), ".", ","), 18, MidpointRounding.ToEven));
               A38CantidadEspectaculos = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CANTIDADESPECTACULOS"), ".", ","), 18, MidpointRounding.ToEven));
               n38CantidadEspectaculos = false;
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A2TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
               A12TipoEspectaculoNombre = cgiGet( edtTipoEspectaculoNombre_Internalname);
               AssignAttri("", false, "A12TipoEspectaculoNombre", A12TipoEspectaculoNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoEspectaculo");
               A2TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
               forbiddenHiddens.Add("TipoEspectaculoId", context.localUtil.Format( (decimal)(A2TipoEspectaculoId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A2TipoEspectaculoId != Z2TipoEspectaculoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tipoespectaculo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A2TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPOESPECTACULOID");
                        AnyError = 1;
                        GX_FocusControl = edtTipoEspectaculoId_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll079( ) ;
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
            DisableAttributes079( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls079( ) ;
            }
            else
            {
               CheckExtendedTable079( ) ;
               CloseExtendedTableCursors079( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwtipoespectaculo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM079( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z12TipoEspectaculoNombre = T00073_A12TipoEspectaculoNombre[0];
            }
            else
            {
               Z12TipoEspectaculoNombre = A12TipoEspectaculoNombre;
            }
         }
         if ( GX_JID == -3 )
         {
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
            Z12TipoEspectaculoNombre = A12TipoEspectaculoNombre;
            Z38CantidadEspectaculos = A38CantidadEspectaculos;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTipoEspectaculoId_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         edtTipoEspectaculoId_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TipoEspectaculoId) )
         {
            A2TipoEspectaculoId = AV7TipoEspectaculoId;
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
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
            /* Using cursor T00075 */
            pr_default.execute(2, new Object[] {A2TipoEspectaculoId});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A38CantidadEspectaculos = T00075_A38CantidadEspectaculos[0];
               n38CantidadEspectaculos = T00075_n38CantidadEspectaculos[0];
            }
            else
            {
               A38CantidadEspectaculos = 0;
               n38CantidadEspectaculos = false;
               AssignAttri("", false, "A38CantidadEspectaculos", StringUtil.LTrimStr( (decimal)(A38CantidadEspectaculos), 4, 0));
            }
            pr_default.close(2);
         }
      }

      protected void Load079( )
      {
         /* Using cursor T00077 */
         pr_default.execute(3, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A12TipoEspectaculoNombre = T00077_A12TipoEspectaculoNombre[0];
            AssignAttri("", false, "A12TipoEspectaculoNombre", A12TipoEspectaculoNombre);
            A38CantidadEspectaculos = T00077_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = T00077_n38CantidadEspectaculos[0];
            ZM079( -3) ;
         }
         pr_default.close(3);
         OnLoadActions079( ) ;
      }

      protected void OnLoadActions079( )
      {
         AV11Pgmname = "TipoEspectaculo";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable079( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "TipoEspectaculo";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         /* Using cursor T00075 */
         pr_default.execute(2, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A38CantidadEspectaculos = T00075_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = T00075_n38CantidadEspectaculos[0];
         }
         else
         {
            A38CantidadEspectaculos = 0;
            n38CantidadEspectaculos = false;
            AssignAttri("", false, "A38CantidadEspectaculos", StringUtil.LTrimStr( (decimal)(A38CantidadEspectaculos), 4, 0));
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors079( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( short A2TipoEspectaculoId )
      {
         /* Using cursor T00079 */
         pr_default.execute(4, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A38CantidadEspectaculos = T00079_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = T00079_n38CantidadEspectaculos[0];
         }
         else
         {
            A38CantidadEspectaculos = 0;
            n38CantidadEspectaculos = false;
            AssignAttri("", false, "A38CantidadEspectaculos", StringUtil.LTrimStr( (decimal)(A38CantidadEspectaculos), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A38CantidadEspectaculos), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey079( )
      {
         /* Using cursor T000710 */
         pr_default.execute(5, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM079( 3) ;
            RcdFound9 = 1;
            A2TipoEspectaculoId = T00073_A2TipoEspectaculoId[0];
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
            A12TipoEspectaculoNombre = T00073_A12TipoEspectaculoNombre[0];
            AssignAttri("", false, "A12TipoEspectaculoNombre", A12TipoEspectaculoNombre);
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load079( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey079( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey079( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey079( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000711 */
         pr_default.execute(6, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000711_A2TipoEspectaculoId[0] < A2TipoEspectaculoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000711_A2TipoEspectaculoId[0] > A2TipoEspectaculoId ) ) )
            {
               A2TipoEspectaculoId = T000711_A2TipoEspectaculoId[0];
               AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000712 */
         pr_default.execute(7, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000712_A2TipoEspectaculoId[0] > A2TipoEspectaculoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000712_A2TipoEspectaculoId[0] < A2TipoEspectaculoId ) ) )
            {
               A2TipoEspectaculoId = T000712_A2TipoEspectaculoId[0];
               AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey079( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipoEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert079( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A2TipoEspectaculoId != Z2TipoEspectaculoId )
               {
                  A2TipoEspectaculoId = Z2TipoEspectaculoId;
                  AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPOESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipoEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update079( ) ;
                  GX_FocusControl = edtTipoEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2TipoEspectaculoId != Z2TipoEspectaculoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipoEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert079( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPOESPECTACULOID");
                     AnyError = 1;
                     GX_FocusControl = edtTipoEspectaculoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipoEspectaculoNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert079( ) ;
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
         if ( A2TipoEspectaculoId != Z2TipoEspectaculoId )
         {
            A2TipoEspectaculoId = Z2TipoEspectaculoId;
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipoEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency079( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A2TipoEspectaculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoEspectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z12TipoEspectaculoNombre, T00072_A12TipoEspectaculoNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z12TipoEspectaculoNombre, T00072_A12TipoEspectaculoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("tipoespectaculo:[seudo value changed for attri]"+"TipoEspectaculoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z12TipoEspectaculoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00072_A12TipoEspectaculoNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoEspectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM079( 0) ;
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000713 */
                     pr_default.execute(8, new Object[] {A12TipoEspectaculoNombre});
                     A2TipoEspectaculoId = T000713_A2TipoEspectaculoId[0];
                     AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
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
               Load079( ) ;
            }
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void Update079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000714 */
                     pr_default.execute(9, new Object[] {A12TipoEspectaculoNombre, A2TipoEspectaculoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoEspectaculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate079( ) ;
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
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void DeferredUpdate079( )
      {
      }

      protected void delete( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls079( ) ;
            AfterConfirm079( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete079( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000715 */
                  pr_default.execute(10, new Object[] {A2TipoEspectaculoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel079( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls079( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "TipoEspectaculo";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
            /* Using cursor T000717 */
            pr_default.execute(11, new Object[] {A2TipoEspectaculoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A38CantidadEspectaculos = T000717_A38CantidadEspectaculos[0];
               n38CantidadEspectaculos = T000717_n38CantidadEspectaculos[0];
            }
            else
            {
               A38CantidadEspectaculos = 0;
               n38CantidadEspectaculos = false;
               AssignAttri("", false, "A38CantidadEspectaculos", StringUtil.LTrimStr( (decimal)(A38CantidadEspectaculos), 4, 0));
            }
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000718 */
            pr_default.execute(12, new Object[] {A2TipoEspectaculoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Espectaculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel079( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete079( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("tipoespectaculo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("tipoespectaculo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart079( )
      {
         /* Scan By routine */
         /* Using cursor T000719 */
         pr_default.execute(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A2TipoEspectaculoId = T000719_A2TipoEspectaculoId[0];
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext079( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A2TipoEspectaculoId = T000719_A2TipoEspectaculoId[0];
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
         }
      }

      protected void ScanEnd079( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm079( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert079( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate079( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete079( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete079( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate079( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes079( )
      {
         edtTipoEspectaculoId_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         edtTipoEspectaculoNombre_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes079( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tipoespectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TipoEspectaculoId,4,0))}, new string[] {"Gx_mode","TipoEspectaculoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoEspectaculo");
         forbiddenHiddens.Add("TipoEspectaculoId", context.localUtil.Format( (decimal)(A2TipoEspectaculoId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tipoespectaculo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2TipoEspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z12TipoEspectaculoNombre", Z12TipoEspectaculoNombre);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vTIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TipoEspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPOESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipoEspectaculoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CANTIDADESPECTACULOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38CantidadEspectaculos), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
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
         return formatLink("tipoespectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TipoEspectaculoId,4,0))}, new string[] {"Gx_mode","TipoEspectaculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "TipoEspectaculo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo Espectaculo" ;
      }

      protected void InitializeNonKey079( )
      {
         A12TipoEspectaculoNombre = "";
         AssignAttri("", false, "A12TipoEspectaculoNombre", A12TipoEspectaculoNombre);
         A38CantidadEspectaculos = 0;
         n38CantidadEspectaculos = false;
         AssignAttri("", false, "A38CantidadEspectaculos", StringUtil.LTrimStr( (decimal)(A38CantidadEspectaculos), 4, 0));
         Z12TipoEspectaculoNombre = "";
      }

      protected void InitAll079( )
      {
         A2TipoEspectaculoId = 0;
         AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
         InitializeNonKey079( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248121951344", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("tipoespectaculo.js", "?20248121951344", false, true);
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
         edtTipoEspectaculoId_Internalname = "TIPOESPECTACULOID";
         edtTipoEspectaculoNombre_Internalname = "TIPOESPECTACULONOMBRE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tipo Espectaculo";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTipoEspectaculoNombre_Jsonclick = "";
         edtTipoEspectaculoNombre_Enabled = 1;
         edtTipoEspectaculoId_Jsonclick = "";
         edtTipoEspectaculoId_Enabled = 0;
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

      public void Valid_Tipoespectaculoid( )
      {
         n38CantidadEspectaculos = false;
         /* Using cursor T000717 */
         pr_default.execute(11, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A38CantidadEspectaculos = T000717_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = T000717_n38CantidadEspectaculos[0];
         }
         else
         {
            A38CantidadEspectaculos = 0;
            n38CantidadEspectaculos = false;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A38CantidadEspectaculos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38CantidadEspectaculos), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7TipoEspectaculoId","fld":"vTIPOESPECTACULOID","pic":"ZZZ9","hsh":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7TipoEspectaculoId","fld":"vTIPOESPECTACULOID","pic":"ZZZ9","hsh":true},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12072","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true}]}""");
         setEventMetadata("VALID_TIPOESPECTACULOID","""{"handler":"Valid_Tipoespectaculoid","iparms":[{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"},{"av":"A38CantidadEspectaculos","fld":"CANTIDADESPECTACULOS","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_TIPOESPECTACULOID",""","oparms":[{"av":"A38CantidadEspectaculos","fld":"CANTIDADESPECTACULOS","pic":"ZZZ9"}]}""");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z12TipoEspectaculoNombre = "";
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
         A12TipoEspectaculoNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00075_A38CantidadEspectaculos = new short[1] ;
         T00075_n38CantidadEspectaculos = new bool[] {false} ;
         T00077_A2TipoEspectaculoId = new short[1] ;
         T00077_A12TipoEspectaculoNombre = new string[] {""} ;
         T00077_A38CantidadEspectaculos = new short[1] ;
         T00077_n38CantidadEspectaculos = new bool[] {false} ;
         T00079_A38CantidadEspectaculos = new short[1] ;
         T00079_n38CantidadEspectaculos = new bool[] {false} ;
         T000710_A2TipoEspectaculoId = new short[1] ;
         T00073_A2TipoEspectaculoId = new short[1] ;
         T00073_A12TipoEspectaculoNombre = new string[] {""} ;
         T000711_A2TipoEspectaculoId = new short[1] ;
         T000712_A2TipoEspectaculoId = new short[1] ;
         T00072_A2TipoEspectaculoId = new short[1] ;
         T00072_A12TipoEspectaculoNombre = new string[] {""} ;
         T000713_A2TipoEspectaculoId = new short[1] ;
         T000717_A38CantidadEspectaculos = new short[1] ;
         T000717_n38CantidadEspectaculos = new bool[] {false} ;
         T000718_A1EspectaculoId = new short[1] ;
         T000719_A2TipoEspectaculoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipoespectaculo__default(),
            new Object[][] {
                new Object[] {
               T00072_A2TipoEspectaculoId, T00072_A12TipoEspectaculoNombre
               }
               , new Object[] {
               T00073_A2TipoEspectaculoId, T00073_A12TipoEspectaculoNombre
               }
               , new Object[] {
               T00075_A38CantidadEspectaculos, T00075_n38CantidadEspectaculos
               }
               , new Object[] {
               T00077_A2TipoEspectaculoId, T00077_A12TipoEspectaculoNombre, T00077_A38CantidadEspectaculos, T00077_n38CantidadEspectaculos
               }
               , new Object[] {
               T00079_A38CantidadEspectaculos, T00079_n38CantidadEspectaculos
               }
               , new Object[] {
               T000710_A2TipoEspectaculoId
               }
               , new Object[] {
               T000711_A2TipoEspectaculoId
               }
               , new Object[] {
               T000712_A2TipoEspectaculoId
               }
               , new Object[] {
               T000713_A2TipoEspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000717_A38CantidadEspectaculos, T000717_n38CantidadEspectaculos
               }
               , new Object[] {
               T000718_A1EspectaculoId
               }
               , new Object[] {
               T000719_A2TipoEspectaculoId
               }
            }
         );
         AV11Pgmname = "TipoEspectaculo";
      }

      private short wcpOAV7TipoEspectaculoId ;
      private short Z2TipoEspectaculoId ;
      private short GxWebError ;
      private short A2TipoEspectaculoId ;
      private short AV7TipoEspectaculoId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A38CantidadEspectaculos ;
      private short RcdFound9 ;
      private short Z38CantidadEspectaculos ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipoEspectaculoId_Enabled ;
      private int edtTipoEspectaculoNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
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
      private string edtTipoEspectaculoNombre_Internalname ;
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
      private string edtTipoEspectaculoId_Internalname ;
      private string edtTipoEspectaculoId_Jsonclick ;
      private string edtTipoEspectaculoNombre_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n38CantidadEspectaculos ;
      private bool returnInSub ;
      private string Z12TipoEspectaculoNombre ;
      private string A12TipoEspectaculoNombre ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] T00075_A38CantidadEspectaculos ;
      private bool[] T00075_n38CantidadEspectaculos ;
      private short[] T00077_A2TipoEspectaculoId ;
      private string[] T00077_A12TipoEspectaculoNombre ;
      private short[] T00077_A38CantidadEspectaculos ;
      private bool[] T00077_n38CantidadEspectaculos ;
      private short[] T00079_A38CantidadEspectaculos ;
      private bool[] T00079_n38CantidadEspectaculos ;
      private short[] T000710_A2TipoEspectaculoId ;
      private short[] T00073_A2TipoEspectaculoId ;
      private string[] T00073_A12TipoEspectaculoNombre ;
      private short[] T000711_A2TipoEspectaculoId ;
      private short[] T000712_A2TipoEspectaculoId ;
      private short[] T00072_A2TipoEspectaculoId ;
      private string[] T00072_A12TipoEspectaculoNombre ;
      private short[] T000713_A2TipoEspectaculoId ;
      private short[] T000717_A38CantidadEspectaculos ;
      private bool[] T000717_n38CantidadEspectaculos ;
      private short[] T000718_A1EspectaculoId ;
      private short[] T000719_A2TipoEspectaculoId ;
   }

   public class tipoespectaculo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@TipoEspectaculoNombre",GXType.NVarChar,100,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@TipoEspectaculoNombre",GXType.NVarChar,100,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] WITH (UPDLOCK) WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT COALESCE( T1.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T1 WHERE T1.[TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT TM1.[TipoEspectaculoId], TM1.[TipoEspectaculoNombre], COALESCE( T2.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM ([TipoEspectaculo] TM1 LEFT JOIN (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T2 ON T2.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) WHERE TM1.[TipoEspectaculoId] = @TipoEspectaculoId ORDER BY TM1.[TipoEspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT COALESCE( T1.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T1 WHERE T1.[TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000710", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000711", "SELECT TOP 1 [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE ( [TipoEspectaculoId] > @TipoEspectaculoId) ORDER BY [TipoEspectaculoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000712", "SELECT TOP 1 [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE ( [TipoEspectaculoId] < @TipoEspectaculoId) ORDER BY [TipoEspectaculoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000713", "INSERT INTO [TipoEspectaculo]([TipoEspectaculoNombre]) VALUES(@TipoEspectaculoNombre); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000714", "UPDATE [TipoEspectaculo] SET [TipoEspectaculoNombre]=@TipoEspectaculoNombre  WHERE [TipoEspectaculoId] = @TipoEspectaculoId", GxErrorMask.GX_NOMASK,prmT000714)
             ,new CursorDef("T000715", "DELETE FROM [TipoEspectaculo]  WHERE [TipoEspectaculoId] = @TipoEspectaculoId", GxErrorMask.GX_NOMASK,prmT000715)
             ,new CursorDef("T000717", "SELECT COALESCE( T1.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T1 WHERE T1.[TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000718", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000719", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] ORDER BY [TipoEspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000719,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
