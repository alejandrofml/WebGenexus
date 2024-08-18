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
   public class lugar : GXDataArea
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
            A7PaisId = (short)(Math.Round(NumberUtil.Val( GetPar( "PaisId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A7PaisId) ;
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
               AV9LugarId = (short)(Math.Round(NumberUtil.Val( GetPar( "LugarId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9LugarId", StringUtil.LTrimStr( (decimal)(AV9LugarId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9LugarId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Lugar", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLugarNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public lugar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public lugar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_LugarId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV9LugarId = aP1_LugarId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynPaisId = new GXCombobox();
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
         if ( dynPaisId.ItemCount > 0 )
         {
            A7PaisId = (short)(Math.Round(NumberUtil.Val( dynPaisId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynPaisId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0));
            AssignProp("", false, dynPaisId_Internalname, "Values", dynPaisId.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Lugar", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Lugar.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Lugar.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLugarNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLugarNombre_Internalname, A9LugarNombre, StringUtil.RTrim( context.localUtil.Format( A9LugarNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLugarDireccion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarDireccion_Internalname, "Direccion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtLugarDireccion_Internalname, A13LugarDireccion, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A13LugarDireccion), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtLugarDireccion_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynPaisId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynPaisId_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynPaisId, dynPaisId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0)), 1, dynPaisId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynPaisId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Lugar.htm");
         dynPaisId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0));
         AssignProp("", false, dynPaisId_Internalname, "Values", (string)(dynPaisId.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z4LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z4LugarId"), ".", ","), 18, MidpointRounding.ToEven));
               Z9LugarNombre = cgiGet( "Z9LugarNombre");
               Z13LugarDireccion = cgiGet( "Z13LugarDireccion");
               Z7PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z7PaisId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N7PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N7PaisId"), ".", ","), 18, MidpointRounding.ToEven));
               AV9LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vLUGARID"), ".", ","), 18, MidpointRounding.ToEven));
               A4LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "LUGARID"), ".", ","), 18, MidpointRounding.ToEven));
               AV7Insert_PaisId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PAISID"), ".", ","), 18, MidpointRounding.ToEven));
               A22TotalEspectaculos = (short)(Math.Round(context.localUtil.CToN( cgiGet( "TOTALESPECTACULOS"), ".", ","), 18, MidpointRounding.ToEven));
               n22TotalEspectaculos = false;
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A9LugarNombre = cgiGet( edtLugarNombre_Internalname);
               AssignAttri("", false, "A9LugarNombre", A9LugarNombre);
               A13LugarDireccion = cgiGet( edtLugarDireccion_Internalname);
               AssignAttri("", false, "A13LugarDireccion", A13LugarDireccion);
               dynPaisId.CurrentValue = cgiGet( dynPaisId_Internalname);
               A7PaisId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynPaisId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Lugar");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("LugarId", context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("lugar:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A4LugarId = (short)(Math.Round(NumberUtil.Val( GetPar( "LugarId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
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
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll046( ) ;
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
            DisableAttributes046( ) ;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls046( ) ;
            }
            else
            {
               CheckExtendedTable046( ) ;
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV10TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         AV7Insert_PaisId = 0;
         AssignAttri("", false, "AV7Insert_PaisId", StringUtil.LTrimStr( (decimal)(AV7Insert_PaisId), 4, 0));
         if ( ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV10TrnContext.gxTpr_Attributes.Count )
            {
               AV11TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV10TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV11TrnContextAtt.gxTpr_Attributename, "PaisId") == 0 )
               {
                  AV7Insert_PaisId = (short)(Math.Round(NumberUtil.Val( AV11TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7Insert_PaisId", StringUtil.LTrimStr( (decimal)(AV7Insert_PaisId), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            }
         }
      }

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwlugar.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z9LugarNombre = T00043_A9LugarNombre[0];
               Z13LugarDireccion = T00043_A13LugarDireccion[0];
               Z7PaisId = T00043_A7PaisId[0];
            }
            else
            {
               Z9LugarNombre = A9LugarNombre;
               Z13LugarDireccion = A13LugarDireccion;
               Z7PaisId = A7PaisId;
            }
         }
         if ( GX_JID == -7 )
         {
            Z4LugarId = A4LugarId;
            Z9LugarNombre = A9LugarNombre;
            Z13LugarDireccion = A13LugarDireccion;
            Z7PaisId = A7PaisId;
            Z22TotalEspectaculos = A22TotalEspectaculos;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV9LugarId) )
         {
            A4LugarId = AV9LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
         /* Using cursor T00046 */
         pr_default.execute(3, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A22TotalEspectaculos = T00046_A22TotalEspectaculos[0];
            n22TotalEspectaculos = T00046_n22TotalEspectaculos[0];
         }
         else
         {
            A22TotalEspectaculos = 0;
            n22TotalEspectaculos = false;
            AssignAttri("", false, "A22TotalEspectaculos", StringUtil.LTrimStr( (decimal)(A22TotalEspectaculos), 4, 0));
         }
         pr_default.close(3);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_PaisId) )
         {
            dynPaisId.Enabled = 0;
            AssignProp("", false, dynPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynPaisId.Enabled), 5, 0), true);
         }
         else
         {
            dynPaisId.Enabled = 1;
            AssignProp("", false, dynPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynPaisId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV7Insert_PaisId) )
         {
            A7PaisId = AV7Insert_PaisId;
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
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
            AV13Pgmname = "Lugar";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
      }

      protected void Load046( )
      {
         /* Using cursor T00048 */
         pr_default.execute(4, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
            A9LugarNombre = T00048_A9LugarNombre[0];
            AssignAttri("", false, "A9LugarNombre", A9LugarNombre);
            A13LugarDireccion = T00048_A13LugarDireccion[0];
            AssignAttri("", false, "A13LugarDireccion", A13LugarDireccion);
            A7PaisId = T00048_A7PaisId[0];
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
            A22TotalEspectaculos = T00048_A22TotalEspectaculos[0];
            n22TotalEspectaculos = T00048_n22TotalEspectaculos[0];
            ZM046( -7) ;
         }
         pr_default.close(4);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
         AV13Pgmname = "Lugar";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable046( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Lugar";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A7PaisId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = dynPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( short A7PaisId )
      {
         /* Using cursor T00049 */
         pr_default.execute(5, new Object[] {A7PaisId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = dynPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey046( )
      {
         /* Using cursor T000410 */
         pr_default.execute(6, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 7) ;
            RcdFound6 = 1;
            A4LugarId = T00043_A4LugarId[0];
            A9LugarNombre = T00043_A9LugarNombre[0];
            AssignAttri("", false, "A9LugarNombre", A9LugarNombre);
            A13LugarDireccion = T00043_A13LugarDireccion[0];
            AssignAttri("", false, "A13LugarDireccion", A13LugarDireccion);
            A7PaisId = T00043_A7PaisId[0];
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
            Z4LugarId = A4LugarId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000411 */
         pr_default.execute(7, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000411_A4LugarId[0] < A4LugarId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000411_A4LugarId[0] > A4LugarId ) ) )
            {
               A4LugarId = T000411_A4LugarId[0];
               RcdFound6 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000412 */
         pr_default.execute(8, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000412_A4LugarId[0] > A4LugarId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000412_A4LugarId[0] < A4LugarId ) ) )
            {
               A4LugarId = T000412_A4LugarId[0];
               RcdFound6 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLugarNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert046( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A4LugarId != Z4LugarId )
               {
                  A4LugarId = Z4LugarId;
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLugarNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update046( ) ;
                  GX_FocusControl = edtLugarNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4LugarId != Z4LugarId )
               {
                  /* Insert record */
                  GX_FocusControl = edtLugarNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert046( ) ;
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
                     GX_FocusControl = edtLugarNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert046( ) ;
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
         if ( A4LugarId != Z4LugarId )
         {
            A4LugarId = Z4LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLugarNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z9LugarNombre, T00042_A9LugarNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z13LugarDireccion, T00042_A13LugarDireccion[0]) != 0 ) || ( Z7PaisId != T00042_A7PaisId[0] ) )
            {
               if ( StringUtil.StrCmp(Z9LugarNombre, T00042_A9LugarNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"LugarNombre");
                  GXUtil.WriteLogRaw("Old: ",Z9LugarNombre);
                  GXUtil.WriteLogRaw("Current: ",T00042_A9LugarNombre[0]);
               }
               if ( StringUtil.StrCmp(Z13LugarDireccion, T00042_A13LugarDireccion[0]) != 0 )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"LugarDireccion");
                  GXUtil.WriteLogRaw("Old: ",Z13LugarDireccion);
                  GXUtil.WriteLogRaw("Current: ",T00042_A13LugarDireccion[0]);
               }
               if ( Z7PaisId != T00042_A7PaisId[0] )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"PaisId");
                  GXUtil.WriteLogRaw("Old: ",Z7PaisId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A7PaisId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Lugar"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM046( 0) ;
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000413 */
                     pr_default.execute(9, new Object[] {A9LugarNombre, A13LugarDireccion, A7PaisId});
                     A4LugarId = T000413_A4LugarId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Lugar");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption040( ) ;
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
               Load046( ) ;
            }
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void Update046( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable046( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm046( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate046( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000414 */
                     pr_default.execute(10, new Object[] {A9LugarNombre, A13LugarDireccion, A7PaisId, A4LugarId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Lugar");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate046( ) ;
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
            EndLevel046( ) ;
         }
         CloseExtendedTableCursors046( ) ;
      }

      protected void DeferredUpdate046( )
      {
      }

      protected void delete( )
      {
         BeforeValidate046( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency046( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls046( ) ;
            AfterConfirm046( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete046( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000415 */
                  pr_default.execute(11, new Object[] {A4LugarId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Lugar");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel046( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Lugar";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000416 */
            pr_default.execute(12, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sector"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000417 */
            pr_default.execute(13, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Evento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel046( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete046( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("lugar",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("lugar",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart046( )
      {
         /* Scan By routine */
         /* Using cursor T000418 */
         pr_default.execute(14);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound6 = 1;
            A4LugarId = T000418_A4LugarId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound6 = 1;
            A4LugarId = T000418_A4LugarId[0];
         }
      }

      protected void ScanEnd046( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm046( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert046( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate046( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete046( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete046( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate046( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes046( )
      {
         edtLugarNombre_Enabled = 0;
         AssignProp("", false, edtLugarNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarNombre_Enabled), 5, 0), true);
         edtLugarDireccion_Enabled = 0;
         AssignProp("", false, edtLugarDireccion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarDireccion_Enabled), 5, 0), true);
         dynPaisId.Enabled = 0;
         AssignProp("", false, dynPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynPaisId.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("lugar.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV9LugarId,4,0))}, new string[] {"Gx_mode","LugarId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Lugar");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("LugarId", context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("lugar:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9LugarNombre", Z9LugarNombre);
         GxWebStd.gx_hidden_field( context, "Z13LugarDireccion", Z13LugarDireccion);
         GxWebStd.gx_hidden_field( context, "Z7PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7PaisId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N7PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7PaisId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vLUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV9LugarId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Insert_PaisId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TOTALESPECTACULOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22TotalEspectaculos), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
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
         return formatLink("lugar.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV9LugarId,4,0))}, new string[] {"Gx_mode","LugarId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Lugar" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lugar" ;
      }

      protected void InitializeNonKey046( )
      {
         A7PaisId = 0;
         AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
         A9LugarNombre = "";
         AssignAttri("", false, "A9LugarNombre", A9LugarNombre);
         A13LugarDireccion = "";
         AssignAttri("", false, "A13LugarDireccion", A13LugarDireccion);
         Z9LugarNombre = "";
         Z13LugarDireccion = "";
         Z7PaisId = 0;
      }

      protected void InitAll046( )
      {
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         InitializeNonKey046( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248121951335", true, true);
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
         context.AddJavascriptSource("lugar.js", "?20248121951335", false, true);
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
         edtLugarNombre_Internalname = "LUGARNOMBRE";
         edtLugarDireccion_Internalname = "LUGARDIRECCION";
         dynPaisId_Internalname = "PAISID";
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
         Form.Caption = "Lugar";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dynPaisId_Jsonclick = "";
         dynPaisId.Enabled = 1;
         edtLugarDireccion_Enabled = 1;
         edtLugarNombre_Jsonclick = "";
         edtLugarNombre_Enabled = 1;
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

      protected void GXDLAPAISID041( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPAISID_data041( ) ;
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

      protected void GXAPAISID_html041( )
      {
         short gxdynajaxvalue;
         GXDLAPAISID_data041( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynPaisId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynPaisId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAPAISID_data041( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000419 */
         pr_default.execute(15);
         while ( (pr_default.getStatus(15) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000419_A7PaisId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000419_A11PaisNombre[0]);
            pr_default.readNext(15);
         }
         pr_default.close(15);
      }

      protected void init_web_controls( )
      {
         dynPaisId.Name = "PAISID";
         dynPaisId.WebTags = "";
         dynPaisId.removeAllItems();
         /* Using cursor T000420 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            dynPaisId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000420_A7PaisId[0]), 4, 0)), T000420_A11PaisNombre[0], 0);
            pr_default.readNext(16);
         }
         pr_default.close(16);
         if ( dynPaisId.ItemCount > 0 )
         {
            A7PaisId = (short)(Math.Round(NumberUtil.Val( dynPaisId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
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

      public void Valid_Paisid( )
      {
         A7PaisId = (short)(Math.Round(NumberUtil.Val( dynPaisId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000421 */
         pr_default.execute(17, new Object[] {A7PaisId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = dynPaisId_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9LugarId","fld":"vLUGARID","pic":"ZZZ9","hsh":true},{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV9LugarId","fld":"vLUGARID","pic":"ZZZ9","hsh":true},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12042","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV10TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_PAISID","""{"handler":"Valid_Paisid","iparms":[{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_PAISID",""","oparms":[{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]}""");
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
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z9LugarNombre = "";
         Z13LugarDireccion = "";
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
         A9LugarNombre = "";
         A13LugarDireccion = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         T00046_A22TotalEspectaculos = new short[1] ;
         T00046_n22TotalEspectaculos = new bool[] {false} ;
         T00048_A4LugarId = new short[1] ;
         T00048_A9LugarNombre = new string[] {""} ;
         T00048_A13LugarDireccion = new string[] {""} ;
         T00048_A7PaisId = new short[1] ;
         T00048_A22TotalEspectaculos = new short[1] ;
         T00048_n22TotalEspectaculos = new bool[] {false} ;
         T00044_A7PaisId = new short[1] ;
         T00049_A7PaisId = new short[1] ;
         T000410_A4LugarId = new short[1] ;
         T00043_A4LugarId = new short[1] ;
         T00043_A9LugarNombre = new string[] {""} ;
         T00043_A13LugarDireccion = new string[] {""} ;
         T00043_A7PaisId = new short[1] ;
         T000411_A4LugarId = new short[1] ;
         T000412_A4LugarId = new short[1] ;
         T00042_A4LugarId = new short[1] ;
         T00042_A9LugarNombre = new string[] {""} ;
         T00042_A13LugarDireccion = new string[] {""} ;
         T00042_A7PaisId = new short[1] ;
         T000413_A4LugarId = new short[1] ;
         T000416_A5SectorId = new short[1] ;
         T000417_A3EventoId = new short[1] ;
         T000418_A4LugarId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000419_A7PaisId = new short[1] ;
         T000419_A11PaisNombre = new string[] {""} ;
         T000420_A7PaisId = new short[1] ;
         T000420_A11PaisNombre = new string[] {""} ;
         T000421_A7PaisId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.lugar__default(),
            new Object[][] {
                new Object[] {
               T00042_A4LugarId, T00042_A9LugarNombre, T00042_A13LugarDireccion, T00042_A7PaisId
               }
               , new Object[] {
               T00043_A4LugarId, T00043_A9LugarNombre, T00043_A13LugarDireccion, T00043_A7PaisId
               }
               , new Object[] {
               T00044_A7PaisId
               }
               , new Object[] {
               T00046_A22TotalEspectaculos, T00046_n22TotalEspectaculos
               }
               , new Object[] {
               T00048_A4LugarId, T00048_A9LugarNombre, T00048_A13LugarDireccion, T00048_A7PaisId, T00048_A22TotalEspectaculos, T00048_n22TotalEspectaculos
               }
               , new Object[] {
               T00049_A7PaisId
               }
               , new Object[] {
               T000410_A4LugarId
               }
               , new Object[] {
               T000411_A4LugarId
               }
               , new Object[] {
               T000412_A4LugarId
               }
               , new Object[] {
               T000413_A4LugarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000416_A5SectorId
               }
               , new Object[] {
               T000417_A3EventoId
               }
               , new Object[] {
               T000418_A4LugarId
               }
               , new Object[] {
               T000419_A7PaisId, T000419_A11PaisNombre
               }
               , new Object[] {
               T000420_A7PaisId, T000420_A11PaisNombre
               }
               , new Object[] {
               T000421_A7PaisId
               }
            }
         );
         AV13Pgmname = "Lugar";
      }

      private short wcpOAV9LugarId ;
      private short Z4LugarId ;
      private short Z7PaisId ;
      private short N7PaisId ;
      private short GxWebError ;
      private short A7PaisId ;
      private short AV9LugarId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A4LugarId ;
      private short AV7Insert_PaisId ;
      private short A22TotalEspectaculos ;
      private short RcdFound6 ;
      private short Z22TotalEspectaculos ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLugarNombre_Enabled ;
      private int edtLugarDireccion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV14GXV1 ;
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
      private string edtLugarNombre_Internalname ;
      private string dynPaisId_Internalname ;
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
      private string edtLugarNombre_Jsonclick ;
      private string edtLugarDireccion_Internalname ;
      private string dynPaisId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n22TotalEspectaculos ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z9LugarNombre ;
      private string Z13LugarDireccion ;
      private string A9LugarNombre ;
      private string A13LugarDireccion ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynPaisId ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV11TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T00046_A22TotalEspectaculos ;
      private bool[] T00046_n22TotalEspectaculos ;
      private short[] T00048_A4LugarId ;
      private string[] T00048_A9LugarNombre ;
      private string[] T00048_A13LugarDireccion ;
      private short[] T00048_A7PaisId ;
      private short[] T00048_A22TotalEspectaculos ;
      private bool[] T00048_n22TotalEspectaculos ;
      private short[] T00044_A7PaisId ;
      private short[] T00049_A7PaisId ;
      private short[] T000410_A4LugarId ;
      private short[] T00043_A4LugarId ;
      private string[] T00043_A9LugarNombre ;
      private string[] T00043_A13LugarDireccion ;
      private short[] T00043_A7PaisId ;
      private short[] T000411_A4LugarId ;
      private short[] T000412_A4LugarId ;
      private short[] T00042_A4LugarId ;
      private string[] T00042_A9LugarNombre ;
      private string[] T00042_A13LugarDireccion ;
      private short[] T00042_A7PaisId ;
      private short[] T000413_A4LugarId ;
      private short[] T000416_A5SectorId ;
      private short[] T000417_A3EventoId ;
      private short[] T000418_A4LugarId ;
      private short[] T000419_A7PaisId ;
      private string[] T000419_A11PaisNombre ;
      private short[] T000420_A7PaisId ;
      private string[] T000420_A11PaisNombre ;
      private short[] T000421_A7PaisId ;
   }

   public class lugar__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@LugarNombre",GXType.NVarChar,100,0) ,
          new ParDef("@LugarDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@LugarNombre",GXType.NVarChar,100,0) ,
          new ParDef("@LugarDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000418;
          prmT000418 = new Object[] {
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          };
          Object[] prmT000420;
          prmT000420 = new Object[] {
          };
          Object[] prmT000421;
          prmT000421 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [LugarId], [LugarNombre], [LugarDireccion], [PaisId] FROM [Lugar] WITH (UPDLOCK) WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [LugarId], [LugarNombre], [LugarDireccion], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT COALESCE( T1.[TotalEspectaculos], 0) AS TotalEspectaculos FROM (SELECT COUNT(*) AS TotalEspectaculos, [LugarId] FROM [Evento] GROUP BY [LugarId] ) T1 WHERE T1.[LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT TM1.[LugarId], TM1.[LugarNombre], TM1.[LugarDireccion], TM1.[PaisId], COALESCE( T2.[TotalEspectaculos], 0) AS TotalEspectaculos FROM ([Lugar] TM1 LEFT JOIN (SELECT COUNT(*) AS TotalEspectaculos, [LugarId] FROM [Evento] GROUP BY [LugarId] ) T2 ON T2.[LugarId] = TM1.[LugarId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000410", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000411", "SELECT TOP 1 [LugarId] FROM [Lugar] WHERE ( [LugarId] > @LugarId) ORDER BY [LugarId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000412", "SELECT TOP 1 [LugarId] FROM [Lugar] WHERE ( [LugarId] < @LugarId) ORDER BY [LugarId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000413", "INSERT INTO [Lugar]([LugarNombre], [LugarDireccion], [PaisId]) VALUES(@LugarNombre, @LugarDireccion, @PaisId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000414", "UPDATE [Lugar] SET [LugarNombre]=@LugarNombre, [LugarDireccion]=@LugarDireccion, [PaisId]=@PaisId  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmT000414)
             ,new CursorDef("T000415", "DELETE FROM [Lugar]  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmT000415)
             ,new CursorDef("T000416", "SELECT TOP 1 [SectorId] FROM [Sector] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000417", "SELECT TOP 1 [EventoId] FROM [Evento] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000418", "SELECT [LugarId] FROM [Lugar] ORDER BY [LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000419", "SELECT [PaisId], [PaisNombre] FROM [Pais] ORDER BY [PaisNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000420", "SELECT [PaisId], [PaisNombre] FROM [Pais] ORDER BY [PaisNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000421", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
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
             case 9 :
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
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
