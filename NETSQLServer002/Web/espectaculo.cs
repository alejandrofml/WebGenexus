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
   public class espectaculo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A2TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A2TipoEspectaculoId) ;
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
               AV7EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7EspectaculoId", StringUtil.LTrimStr( (decimal)(AV7EspectaculoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspectaculoId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Espectaculo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEspectaculoNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public espectaculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public espectaculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EspectaculoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EspectaculoId = aP1_EspectaculoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynTipoEspectaculoId = new GXCombobox();
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
         if ( dynTipoEspectaculoId.ItemCount > 0 )
         {
            A2TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( dynTipoEspectaculoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2TipoEspectaculoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynTipoEspectaculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2TipoEspectaculoId), 4, 0));
            AssignProp("", false, dynTipoEspectaculoId_Internalname, "Values", dynTipoEspectaculoId.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Espectáculo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Espectaculo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoNombre_Internalname, A14EspectaculoNombre, StringUtil.RTrim( context.localUtil.Format( A14EspectaculoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEspectaculoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoDescripcion_Internalname, "Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtEspectaculoDescripcion_Internalname, A15EspectaculoDescripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtEspectaculoDescripcion_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgEspectaculoImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A16EspectaculoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000EspectaculoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A16EspectaculoImagen));
         GxWebStd.gx_bitmap( context, imgEspectaculoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgEspectaculoImagen_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A16EspectaculoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
         AssignProp("", false, imgEspectaculoImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A16EspectaculoImagen)), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A16EspectaculoImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynTipoEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynTipoEspectaculoId_Internalname, "Tipo Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynTipoEspectaculoId, dynTipoEspectaculoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2TipoEspectaculoId), 4, 0)), 1, dynTipoEspectaculoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynTipoEspectaculoId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Espectaculo.htm");
         dynTipoEspectaculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2TipoEspectaculoId), 4, 0));
         AssignProp("", false, dynTipoEspectaculoId_Internalname, "Values", (string)(dynTipoEspectaculoId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
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
               Z1EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EspectaculoId"), ".", ","), 18, MidpointRounding.ToEven));
               Z14EspectaculoNombre = cgiGet( "Z14EspectaculoNombre");
               Z15EspectaculoDescripcion = cgiGet( "Z15EspectaculoDescripcion");
               Z2TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z2TipoEspectaculoId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N2TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N2TipoEspectaculoId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vESPECTACULOID"), ".", ","), 18, MidpointRounding.ToEven));
               A1EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ESPECTACULOID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_TipoEspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TIPOESPECTACULOID"), ".", ","), 18, MidpointRounding.ToEven));
               A40000EspectaculoImagen_GXI = cgiGet( "ESPECTACULOIMAGEN_GXI");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A14EspectaculoNombre = cgiGet( edtEspectaculoNombre_Internalname);
               AssignAttri("", false, "A14EspectaculoNombre", A14EspectaculoNombre);
               A15EspectaculoDescripcion = cgiGet( edtEspectaculoDescripcion_Internalname);
               AssignAttri("", false, "A15EspectaculoDescripcion", A15EspectaculoDescripcion);
               A16EspectaculoImagen = cgiGet( imgEspectaculoImagen_Internalname);
               AssignAttri("", false, "A16EspectaculoImagen", A16EspectaculoImagen);
               dynTipoEspectaculoId.CurrentValue = cgiGet( dynTipoEspectaculoId_Internalname);
               A2TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynTipoEspectaculoId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgEspectaculoImagen_Internalname, ref  A16EspectaculoImagen, ref  A40000EspectaculoImagen_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("espectaculo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
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
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_TipoEspectaculoId = 0;
         AssignAttri("", false, "AV11Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_TipoEspectaculoId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TipoEspectaculoId") == 0 )
               {
                  AV11Insert_TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_TipoEspectaculoId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwespectaculo.aspx") );
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
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z14EspectaculoNombre = T00013_A14EspectaculoNombre[0];
               Z15EspectaculoDescripcion = T00013_A15EspectaculoDescripcion[0];
               Z2TipoEspectaculoId = T00013_A2TipoEspectaculoId[0];
            }
            else
            {
               Z14EspectaculoNombre = A14EspectaculoNombre;
               Z15EspectaculoDescripcion = A15EspectaculoDescripcion;
               Z2TipoEspectaculoId = A2TipoEspectaculoId;
            }
         }
         if ( GX_JID == -7 )
         {
            Z1EspectaculoId = A1EspectaculoId;
            Z14EspectaculoNombre = A14EspectaculoNombre;
            Z15EspectaculoDescripcion = A15EspectaculoDescripcion;
            Z16EspectaculoImagen = A16EspectaculoImagen;
            Z40000EspectaculoImagen_GXI = A40000EspectaculoImagen_GXI;
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EspectaculoId) )
         {
            A1EspectaculoId = AV7EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoEspectaculoId) )
         {
            dynTipoEspectaculoId.Enabled = 0;
            AssignProp("", false, dynTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoEspectaculoId.Enabled), 5, 0), true);
         }
         else
         {
            dynTipoEspectaculoId.Enabled = 1;
            AssignProp("", false, dynTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoEspectaculoId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_TipoEspectaculoId) )
         {
            A2TipoEspectaculoId = AV11Insert_TipoEspectaculoId;
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
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
            AV14Pgmname = "Espectaculo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A14EspectaculoNombre = T00015_A14EspectaculoNombre[0];
            AssignAttri("", false, "A14EspectaculoNombre", A14EspectaculoNombre);
            A15EspectaculoDescripcion = T00015_A15EspectaculoDescripcion[0];
            AssignAttri("", false, "A15EspectaculoDescripcion", A15EspectaculoDescripcion);
            A40000EspectaculoImagen_GXI = T00015_A40000EspectaculoImagen_GXI[0];
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A16EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A16EspectaculoImagen), true);
            A2TipoEspectaculoId = T00015_A2TipoEspectaculoId[0];
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
            A16EspectaculoImagen = T00015_A16EspectaculoImagen[0];
            AssignAttri("", false, "A16EspectaculoImagen", A16EspectaculoImagen);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A16EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A16EspectaculoImagen), true);
            ZM011( -7) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV14Pgmname = "Espectaculo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Espectaculo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = dynTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( short A2TipoEspectaculoId )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = dynTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 7) ;
            RcdFound1 = 1;
            A1EspectaculoId = T00013_A1EspectaculoId[0];
            A14EspectaculoNombre = T00013_A14EspectaculoNombre[0];
            AssignAttri("", false, "A14EspectaculoNombre", A14EspectaculoNombre);
            A15EspectaculoDescripcion = T00013_A15EspectaculoDescripcion[0];
            AssignAttri("", false, "A15EspectaculoDescripcion", A15EspectaculoDescripcion);
            A40000EspectaculoImagen_GXI = T00013_A40000EspectaculoImagen_GXI[0];
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A16EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A16EspectaculoImagen), true);
            A2TipoEspectaculoId = T00013_A2TipoEspectaculoId[0];
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
            A16EspectaculoImagen = T00013_A16EspectaculoImagen[0];
            AssignAttri("", false, "A16EspectaculoImagen", A16EspectaculoImagen);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A16EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A16EspectaculoImagen), true);
            Z1EspectaculoId = A1EspectaculoId;
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
         pr_default.close(1);
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
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EspectaculoId[0] < A1EspectaculoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1EspectaculoId[0] > A1EspectaculoId ) ) )
            {
               A1EspectaculoId = T00018_A1EspectaculoId[0];
               RcdFound1 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EspectaculoId[0] > A1EspectaculoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1EspectaculoId[0] < A1EspectaculoId ) ) )
            {
               A1EspectaculoId = T00019_A1EspectaculoId[0];
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEspectaculoNombre_Internalname;
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
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  A1EspectaculoId = Z1EspectaculoId;
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtEspectaculoNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEspectaculoNombre_Internalname;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                     AnyError = 1;
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEspectaculoNombre_Internalname;
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
         if ( A1EspectaculoId != Z1EspectaculoId )
         {
            A1EspectaculoId = Z1EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEspectaculoNombre_Internalname;
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
            pr_default.execute(0, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z14EspectaculoNombre, T00012_A14EspectaculoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z15EspectaculoDescripcion, T00012_A15EspectaculoDescripcion[0]) != 0 ) || ( Z2TipoEspectaculoId != T00012_A2TipoEspectaculoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z14EspectaculoNombre, T00012_A14EspectaculoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z14EspectaculoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00012_A14EspectaculoNombre[0]);
               }
               if ( StringUtil.StrCmp(Z15EspectaculoDescripcion, T00012_A15EspectaculoDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z15EspectaculoDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T00012_A15EspectaculoDescripcion[0]);
               }
               if ( Z2TipoEspectaculoId != T00012_A2TipoEspectaculoId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"TipoEspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z2TipoEspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2TipoEspectaculoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Espectaculo"}), "RecordWasChanged", 1, "");
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
                     /* Using cursor T000110 */
                     pr_default.execute(8, new Object[] {A14EspectaculoNombre, A15EspectaculoDescripcion, A16EspectaculoImagen, A40000EspectaculoImagen_GXI, A2TipoEspectaculoId});
                     A1EspectaculoId = T000110_A1EspectaculoId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
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
                     /* Using cursor T000111 */
                     pr_default.execute(9, new Object[] {A14EspectaculoNombre, A15EspectaculoDescripcion, A2TipoEspectaculoId, A1EspectaculoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
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
         if ( AnyError == 0 )
         {
            /* Using cursor T000112 */
            pr_default.execute(10, new Object[] {A16EspectaculoImagen, A40000EspectaculoImagen_GXI, A1EspectaculoId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
         }
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
                  /* Using cursor T000113 */
                  pr_default.execute(11, new Object[] {A1EspectaculoId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
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
            AV14Pgmname = "Espectaculo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Evento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("espectaculo",pr_default);
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
            pr_default.close(1);
            context.RollbackDataStores("espectaculo",pr_default);
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
         /* Using cursor T000115 */
         pr_default.execute(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1EspectaculoId = T000115_A1EspectaculoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1EspectaculoId = T000115_A1EspectaculoId[0];
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(13);
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
         edtEspectaculoNombre_Enabled = 0;
         AssignProp("", false, edtEspectaculoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoNombre_Enabled), 5, 0), true);
         edtEspectaculoDescripcion_Enabled = 0;
         AssignProp("", false, edtEspectaculoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoDescripcion_Enabled), 5, 0), true);
         imgEspectaculoImagen_Enabled = 0;
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgEspectaculoImagen_Enabled), 5, 0), true);
         dynTipoEspectaculoId.Enabled = 0;
         AssignProp("", false, dynTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynTipoEspectaculoId.Enabled), 5, 0), true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("espectaculo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z14EspectaculoNombre", Z14EspectaculoNombre);
         GxWebStd.gx_hidden_field( context, "Z15EspectaculoDescripcion", Z15EspectaculoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z2TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2TipoEspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N2TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2TipoEspectaculoId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspectaculoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_TipoEspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOIMAGEN_GXI", A40000EspectaculoImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "ESPECTACULOIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A16EspectaculoImagen);
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
         return formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Espectaculo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Espectaculo" ;
      }

      protected void InitializeNonKey011( )
      {
         A2TipoEspectaculoId = 0;
         AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
         A14EspectaculoNombre = "";
         AssignAttri("", false, "A14EspectaculoNombre", A14EspectaculoNombre);
         A15EspectaculoDescripcion = "";
         AssignAttri("", false, "A15EspectaculoDescripcion", A15EspectaculoDescripcion);
         A16EspectaculoImagen = "";
         AssignAttri("", false, "A16EspectaculoImagen", A16EspectaculoImagen);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A16EspectaculoImagen))), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A16EspectaculoImagen), true);
         A40000EspectaculoImagen_GXI = "";
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A16EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A16EspectaculoImagen))), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A16EspectaculoImagen), true);
         Z14EspectaculoNombre = "";
         Z15EspectaculoDescripcion = "";
         Z2TipoEspectaculoId = 0;
      }

      protected void InitAll011( )
      {
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         InitializeNonKey011( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481219512549", true, true);
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
         context.AddJavascriptSource("espectaculo.js", "?202481219512550", false, true);
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
         edtEspectaculoNombre_Internalname = "ESPECTACULONOMBRE";
         edtEspectaculoDescripcion_Internalname = "ESPECTACULODESCRIPCION";
         imgEspectaculoImagen_Internalname = "ESPECTACULOIMAGEN";
         dynTipoEspectaculoId_Internalname = "TIPOESPECTACULOID";
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
         Form.Caption = "Espectaculo";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dynTipoEspectaculoId_Jsonclick = "";
         dynTipoEspectaculoId.Enabled = 1;
         imgEspectaculoImagen_Enabled = 1;
         edtEspectaculoDescripcion_Enabled = 1;
         edtEspectaculoNombre_Jsonclick = "";
         edtEspectaculoNombre_Enabled = 1;
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

      protected void GXDLATIPOESPECTACULOID011( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLATIPOESPECTACULOID_data011( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXATIPOESPECTACULOID_html011( )
      {
         short gxdynajaxvalue;
         GXDLATIPOESPECTACULOID_data011( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynTipoEspectaculoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynTipoEspectaculoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLATIPOESPECTACULOID_data011( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000116 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000116_A2TipoEspectaculoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000116_A12TipoEspectaculoNombre[0]);
            pr_default.readNext(14);
         }
         pr_default.close(14);
      }

      protected void init_web_controls( )
      {
         dynTipoEspectaculoId.Name = "TIPOESPECTACULOID";
         dynTipoEspectaculoId.WebTags = "";
         dynTipoEspectaculoId.removeAllItems();
         /* Using cursor T000117 */
         pr_default.execute(15);
         while ( (pr_default.getStatus(15) != 101) )
         {
            dynTipoEspectaculoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000117_A2TipoEspectaculoId[0]), 4, 0)), T000117_A12TipoEspectaculoNombre[0], 0);
            pr_default.readNext(15);
         }
         pr_default.close(15);
         if ( dynTipoEspectaculoId.ItemCount > 0 )
         {
            A2TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( dynTipoEspectaculoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2TipoEspectaculoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A2TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A2TipoEspectaculoId), 4, 0));
         }
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
         A2TipoEspectaculoId = (short)(Math.Round(NumberUtil.Val( dynTipoEspectaculoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000118 */
         pr_default.execute(16, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = dynTipoEspectaculoId_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EspectaculoId","fld":"vESPECTACULOID","pic":"ZZZ9","hsh":true},{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EspectaculoId","fld":"vESPECTACULOID","pic":"ZZZ9","hsh":true},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"},{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12012","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_TIPOESPECTACULOID","""{"handler":"Valid_Tipoespectaculoid","iparms":[{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_TIPOESPECTACULOID",""","oparms":[{"av":"dynTipoEspectaculoId"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"}]}""");
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
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z14EspectaculoNombre = "";
         Z15EspectaculoDescripcion = "";
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
         A14EspectaculoNombre = "";
         A15EspectaculoDescripcion = "";
         A16EspectaculoImagen = "";
         A40000EspectaculoImagen_GXI = "";
         sImgUrl = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z16EspectaculoImagen = "";
         Z40000EspectaculoImagen_GXI = "";
         T00015_A1EspectaculoId = new short[1] ;
         T00015_A14EspectaculoNombre = new string[] {""} ;
         T00015_A15EspectaculoDescripcion = new string[] {""} ;
         T00015_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T00015_A2TipoEspectaculoId = new short[1] ;
         T00015_A16EspectaculoImagen = new string[] {""} ;
         T00014_A2TipoEspectaculoId = new short[1] ;
         T00016_A2TipoEspectaculoId = new short[1] ;
         T00017_A1EspectaculoId = new short[1] ;
         T00013_A1EspectaculoId = new short[1] ;
         T00013_A14EspectaculoNombre = new string[] {""} ;
         T00013_A15EspectaculoDescripcion = new string[] {""} ;
         T00013_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T00013_A2TipoEspectaculoId = new short[1] ;
         T00013_A16EspectaculoImagen = new string[] {""} ;
         T00018_A1EspectaculoId = new short[1] ;
         T00019_A1EspectaculoId = new short[1] ;
         T00012_A1EspectaculoId = new short[1] ;
         T00012_A14EspectaculoNombre = new string[] {""} ;
         T00012_A15EspectaculoDescripcion = new string[] {""} ;
         T00012_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T00012_A2TipoEspectaculoId = new short[1] ;
         T00012_A16EspectaculoImagen = new string[] {""} ;
         T000110_A1EspectaculoId = new short[1] ;
         T000114_A3EventoId = new short[1] ;
         T000115_A1EspectaculoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000116_A2TipoEspectaculoId = new short[1] ;
         T000116_A12TipoEspectaculoNombre = new string[] {""} ;
         T000117_A2TipoEspectaculoId = new short[1] ;
         T000117_A12TipoEspectaculoNombre = new string[] {""} ;
         T000118_A2TipoEspectaculoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.espectaculo__default(),
            new Object[][] {
                new Object[] {
               T00012_A1EspectaculoId, T00012_A14EspectaculoNombre, T00012_A15EspectaculoDescripcion, T00012_A40000EspectaculoImagen_GXI, T00012_A2TipoEspectaculoId, T00012_A16EspectaculoImagen
               }
               , new Object[] {
               T00013_A1EspectaculoId, T00013_A14EspectaculoNombre, T00013_A15EspectaculoDescripcion, T00013_A40000EspectaculoImagen_GXI, T00013_A2TipoEspectaculoId, T00013_A16EspectaculoImagen
               }
               , new Object[] {
               T00014_A2TipoEspectaculoId
               }
               , new Object[] {
               T00015_A1EspectaculoId, T00015_A14EspectaculoNombre, T00015_A15EspectaculoDescripcion, T00015_A40000EspectaculoImagen_GXI, T00015_A2TipoEspectaculoId, T00015_A16EspectaculoImagen
               }
               , new Object[] {
               T00016_A2TipoEspectaculoId
               }
               , new Object[] {
               T00017_A1EspectaculoId
               }
               , new Object[] {
               T00018_A1EspectaculoId
               }
               , new Object[] {
               T00019_A1EspectaculoId
               }
               , new Object[] {
               T000110_A1EspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000114_A3EventoId
               }
               , new Object[] {
               T000115_A1EspectaculoId
               }
               , new Object[] {
               T000116_A2TipoEspectaculoId, T000116_A12TipoEspectaculoNombre
               }
               , new Object[] {
               T000117_A2TipoEspectaculoId, T000117_A12TipoEspectaculoNombre
               }
               , new Object[] {
               T000118_A2TipoEspectaculoId
               }
            }
         );
         AV14Pgmname = "Espectaculo";
      }

      private short wcpOAV7EspectaculoId ;
      private short Z1EspectaculoId ;
      private short Z2TipoEspectaculoId ;
      private short N2TipoEspectaculoId ;
      private short GxWebError ;
      private short A2TipoEspectaculoId ;
      private short AV7EspectaculoId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A1EspectaculoId ;
      private short AV11Insert_TipoEspectaculoId ;
      private short RcdFound1 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEspectaculoNombre_Enabled ;
      private int edtEspectaculoDescripcion_Enabled ;
      private int imgEspectaculoImagen_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV15GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEspectaculoNombre_Internalname ;
      private string dynTipoEspectaculoId_Internalname ;
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
      private string edtEspectaculoNombre_Jsonclick ;
      private string edtEspectaculoDescripcion_Internalname ;
      private string imgEspectaculoImagen_Internalname ;
      private string sImgUrl ;
      private string dynTipoEspectaculoId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
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
      private string GXCCtlgxBlob ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A16EspectaculoImagen_IsBlob ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z14EspectaculoNombre ;
      private string Z15EspectaculoDescripcion ;
      private string A14EspectaculoNombre ;
      private string A15EspectaculoDescripcion ;
      private string A40000EspectaculoImagen_GXI ;
      private string Z40000EspectaculoImagen_GXI ;
      private string A16EspectaculoImagen ;
      private string Z16EspectaculoImagen ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynTipoEspectaculoId ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T00015_A1EspectaculoId ;
      private string[] T00015_A14EspectaculoNombre ;
      private string[] T00015_A15EspectaculoDescripcion ;
      private string[] T00015_A40000EspectaculoImagen_GXI ;
      private short[] T00015_A2TipoEspectaculoId ;
      private string[] T00015_A16EspectaculoImagen ;
      private short[] T00014_A2TipoEspectaculoId ;
      private short[] T00016_A2TipoEspectaculoId ;
      private short[] T00017_A1EspectaculoId ;
      private short[] T00013_A1EspectaculoId ;
      private string[] T00013_A14EspectaculoNombre ;
      private string[] T00013_A15EspectaculoDescripcion ;
      private string[] T00013_A40000EspectaculoImagen_GXI ;
      private short[] T00013_A2TipoEspectaculoId ;
      private string[] T00013_A16EspectaculoImagen ;
      private short[] T00018_A1EspectaculoId ;
      private short[] T00019_A1EspectaculoId ;
      private short[] T00012_A1EspectaculoId ;
      private string[] T00012_A14EspectaculoNombre ;
      private string[] T00012_A15EspectaculoDescripcion ;
      private string[] T00012_A40000EspectaculoImagen_GXI ;
      private short[] T00012_A2TipoEspectaculoId ;
      private string[] T00012_A16EspectaculoImagen ;
      private short[] T000110_A1EspectaculoId ;
      private short[] T000114_A3EventoId ;
      private short[] T000115_A1EspectaculoId ;
      private short[] T000116_A2TipoEspectaculoId ;
      private string[] T000116_A12TipoEspectaculoNombre ;
      private short[] T000117_A2TipoEspectaculoId ;
      private string[] T000117_A12TipoEspectaculoNombre ;
      private short[] T000118_A2TipoEspectaculoId ;
   }

   public class espectaculo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NVarChar,100,0) ,
          new ParDef("@EspectaculoDescripcion",GXType.NVarChar,500,0) ,
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NVarChar,100,0) ,
          new ParDef("@EspectaculoDescripcion",GXType.NVarChar,500,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          };
          Object[] prmT000116;
          prmT000116 = new Object[] {
          };
          Object[] prmT000117;
          prmT000117 = new Object[] {
          };
          Object[] prmT000118;
          prmT000118 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [EspectaculoId], [EspectaculoNombre], [EspectaculoDescripcion], [EspectaculoImagen_GXI], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [EspectaculoId], [EspectaculoNombre], [EspectaculoDescripcion], [EspectaculoImagen_GXI], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT TM1.[EspectaculoId], TM1.[EspectaculoNombre], TM1.[EspectaculoDescripcion], TM1.[EspectaculoImagen_GXI], TM1.[TipoEspectaculoId], TM1.[EspectaculoImagen] FROM [Espectaculo] TM1 WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] > @EspectaculoId) ORDER BY [EspectaculoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00019", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] < @EspectaculoId) ORDER BY [EspectaculoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000110", "INSERT INTO [Espectaculo]([EspectaculoNombre], [EspectaculoDescripcion], [EspectaculoImagen], [EspectaculoImagen_GXI], [TipoEspectaculoId]) VALUES(@EspectaculoNombre, @EspectaculoDescripcion, @EspectaculoImagen, @EspectaculoImagen_GXI, @TipoEspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000111", "UPDATE [Espectaculo] SET [EspectaculoNombre]=@EspectaculoNombre, [EspectaculoDescripcion]=@EspectaculoDescripcion, [TipoEspectaculoId]=@TipoEspectaculoId  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000111)
             ,new CursorDef("T000112", "UPDATE [Espectaculo] SET [EspectaculoImagen]=@EspectaculoImagen, [EspectaculoImagen_GXI]=@EspectaculoImagen_GXI  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000112)
             ,new CursorDef("T000113", "DELETE FROM [Espectaculo]  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000113)
             ,new CursorDef("T000114", "SELECT TOP 1 [EventoId] FROM [Evento] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000115", "SELECT [EspectaculoId] FROM [Espectaculo] ORDER BY [EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000116", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] ORDER BY [TipoEspectaculoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000117", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] ORDER BY [TipoEspectaculoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000118", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000118,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
