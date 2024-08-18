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
   public class sector : GXDataArea
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
            A4LugarId = (short)(Math.Round(NumberUtil.Val( GetPar( "LugarId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A4LugarId) ;
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
               AV7SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7SectorId", StringUtil.LTrimStr( (decimal)(AV7SectorId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSECTORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SectorId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Sector", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSectorNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sector( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public sector( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_SectorId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SectorId = aP1_SectorId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynLugarId = new GXCombobox();
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
         if ( dynLugarId.ItemCount > 0 )
         {
            A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLugarId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0));
            AssignProp("", false, dynLugarId_Internalname, "Values", dynLugarId.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Sector", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Sector.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Sector.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorNombre_Internalname, A10SectorNombre, StringUtil.RTrim( context.localUtil.Format( A10SectorNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorCapacidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorCapacidad_Internalname, "Capacidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorCapacidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SectorCapacidad), 4, 0, ".", "")), StringUtil.LTrim( ((edtSectorCapacidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A20SectorCapacidad), "ZZZ9") : context.localUtil.Format( (decimal)(A20SectorCapacidad), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorCapacidad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorCapacidad_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSectorPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorPrecio_Internalname, "Precio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SectorPrecio), 4, 0, ".", "")), StringUtil.LTrim( ((edtSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A21SectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A21SectorPrecio), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorPrecio_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLugarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynLugarId_Internalname, "Lugar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynLugarId, dynLugarId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0)), 1, dynLugarId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynLugarId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Sector.htm");
         dynLugarId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0));
         AssignProp("", false, dynLugarId_Internalname, "Values", (string)(dynLugarId.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z5SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               Z10SectorNombre = cgiGet( "Z10SectorNombre");
               Z20SectorCapacidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z20SectorCapacidad"), ".", ","), 18, MidpointRounding.ToEven));
               Z21SectorPrecio = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z21SectorPrecio"), ".", ","), 18, MidpointRounding.ToEven));
               Z4LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z4LugarId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N4LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N4LugarId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vSECTORID"), ".", ","), 18, MidpointRounding.ToEven));
               A5SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_LUGARID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A10SectorNombre = cgiGet( edtSectorNombre_Internalname);
               AssignAttri("", false, "A10SectorNombre", A10SectorNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECTORCAPACIDAD");
                  AnyError = 1;
                  GX_FocusControl = edtSectorCapacidad_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A20SectorCapacidad = 0;
                  AssignAttri("", false, "A20SectorCapacidad", StringUtil.LTrimStr( (decimal)(A20SectorCapacidad), 4, 0));
               }
               else
               {
                  A20SectorCapacidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A20SectorCapacidad", StringUtil.LTrimStr( (decimal)(A20SectorCapacidad), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECTORPRECIO");
                  AnyError = 1;
                  GX_FocusControl = edtSectorPrecio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A21SectorPrecio = 0;
                  AssignAttri("", false, "A21SectorPrecio", StringUtil.LTrimStr( (decimal)(A21SectorPrecio), 4, 0));
               }
               else
               {
                  A21SectorPrecio = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A21SectorPrecio", StringUtil.LTrimStr( (decimal)(A21SectorPrecio), 4, 0));
               }
               dynLugarId.CurrentValue = cgiGet( dynLugarId_Internalname);
               A4LugarId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynLugarId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Sector");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("SectorId", context.localUtil.Format( (decimal)(A5SectorId), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("sector:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A5SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll057( ) ;
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
            DisableAttributes057( ) ;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls057( ) ;
            }
            else
            {
               CheckExtendedTable057( ) ;
               CloseExtendedTableCursors057( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_LugarId = 0;
         AssignAttri("", false, "AV11Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV11Insert_LugarId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "LugarId") == 0 )
               {
                  AV11Insert_LugarId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV11Insert_LugarId), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            }
         }
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwsector.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM057( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z10SectorNombre = T00053_A10SectorNombre[0];
               Z20SectorCapacidad = T00053_A20SectorCapacidad[0];
               Z21SectorPrecio = T00053_A21SectorPrecio[0];
               Z4LugarId = T00053_A4LugarId[0];
            }
            else
            {
               Z10SectorNombre = A10SectorNombre;
               Z20SectorCapacidad = A20SectorCapacidad;
               Z21SectorPrecio = A21SectorPrecio;
               Z4LugarId = A4LugarId;
            }
         }
         if ( GX_JID == -7 )
         {
            Z5SectorId = A5SectorId;
            Z10SectorNombre = A10SectorNombre;
            Z20SectorCapacidad = A20SectorCapacidad;
            Z21SectorPrecio = A21SectorPrecio;
            Z4LugarId = A4LugarId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SectorId) )
         {
            A5SectorId = AV7SectorId;
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LugarId) )
         {
            dynLugarId.Enabled = 0;
            AssignProp("", false, dynLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLugarId.Enabled), 5, 0), true);
         }
         else
         {
            dynLugarId.Enabled = 1;
            AssignProp("", false, dynLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLugarId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LugarId) )
         {
            A4LugarId = AV11Insert_LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
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
            AV13Pgmname = "Sector";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
      }

      protected void Load057( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A10SectorNombre = T00055_A10SectorNombre[0];
            AssignAttri("", false, "A10SectorNombre", A10SectorNombre);
            A20SectorCapacidad = T00055_A20SectorCapacidad[0];
            AssignAttri("", false, "A20SectorCapacidad", StringUtil.LTrimStr( (decimal)(A20SectorCapacidad), 4, 0));
            A21SectorPrecio = T00055_A21SectorPrecio[0];
            AssignAttri("", false, "A21SectorPrecio", StringUtil.LTrimStr( (decimal)(A21SectorPrecio), 4, 0));
            A4LugarId = T00055_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            ZM057( -7) ;
         }
         pr_default.close(3);
         OnLoadActions057( ) ;
      }

      protected void OnLoadActions057( )
      {
         AV13Pgmname = "Sector";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable057( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Sector";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = dynLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors057( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( short A4LugarId )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = dynLugarId_Internalname;
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

      protected void GetKey057( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM057( 7) ;
            RcdFound7 = 1;
            A5SectorId = T00053_A5SectorId[0];
            A10SectorNombre = T00053_A10SectorNombre[0];
            AssignAttri("", false, "A10SectorNombre", A10SectorNombre);
            A20SectorCapacidad = T00053_A20SectorCapacidad[0];
            AssignAttri("", false, "A20SectorCapacidad", StringUtil.LTrimStr( (decimal)(A20SectorCapacidad), 4, 0));
            A21SectorPrecio = T00053_A21SectorPrecio[0];
            AssignAttri("", false, "A21SectorPrecio", StringUtil.LTrimStr( (decimal)(A21SectorPrecio), 4, 0));
            A4LugarId = T00053_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            Z5SectorId = A5SectorId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load057( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey057( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey057( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey057( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00058_A5SectorId[0] < A5SectorId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00058_A5SectorId[0] > A5SectorId ) ) )
            {
               A5SectorId = T00058_A5SectorId[0];
               RcdFound7 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00059_A5SectorId[0] > A5SectorId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00059_A5SectorId[0] < A5SectorId ) ) )
            {
               A5SectorId = T00059_A5SectorId[0];
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey057( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSectorNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert057( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A5SectorId != Z5SectorId )
               {
                  A5SectorId = Z5SectorId;
                  AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSectorNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update057( ) ;
                  GX_FocusControl = edtSectorNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A5SectorId != Z5SectorId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSectorNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert057( ) ;
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
                     GX_FocusControl = edtSectorNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert057( ) ;
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
         if ( A5SectorId != Z5SectorId )
         {
            A5SectorId = Z5SectorId;
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSectorNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency057( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A5SectorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Sector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z10SectorNombre, T00052_A10SectorNombre[0]) != 0 ) || ( Z20SectorCapacidad != T00052_A20SectorCapacidad[0] ) || ( Z21SectorPrecio != T00052_A21SectorPrecio[0] ) || ( Z4LugarId != T00052_A4LugarId[0] ) )
            {
               if ( StringUtil.StrCmp(Z10SectorNombre, T00052_A10SectorNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"SectorNombre");
                  GXUtil.WriteLogRaw("Old: ",Z10SectorNombre);
                  GXUtil.WriteLogRaw("Current: ",T00052_A10SectorNombre[0]);
               }
               if ( Z20SectorCapacidad != T00052_A20SectorCapacidad[0] )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"SectorCapacidad");
                  GXUtil.WriteLogRaw("Old: ",Z20SectorCapacidad);
                  GXUtil.WriteLogRaw("Current: ",T00052_A20SectorCapacidad[0]);
               }
               if ( Z21SectorPrecio != T00052_A21SectorPrecio[0] )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"SectorPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z21SectorPrecio);
                  GXUtil.WriteLogRaw("Current: ",T00052_A21SectorPrecio[0]);
               }
               if ( Z4LugarId != T00052_A4LugarId[0] )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"LugarId");
                  GXUtil.WriteLogRaw("Old: ",Z4LugarId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A4LugarId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Sector"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert057( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable057( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM057( 0) ;
            CheckOptimisticConcurrency057( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm057( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert057( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000510 */
                     pr_default.execute(8, new Object[] {A10SectorNombre, A20SectorCapacidad, A21SectorPrecio, A4LugarId});
                     A5SectorId = T000510_A5SectorId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Sector");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load057( ) ;
            }
            EndLevel057( ) ;
         }
         CloseExtendedTableCursors057( ) ;
      }

      protected void Update057( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable057( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency057( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm057( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate057( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000511 */
                     pr_default.execute(9, new Object[] {A10SectorNombre, A20SectorCapacidad, A21SectorPrecio, A4LugarId, A5SectorId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Sector");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Sector"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate057( ) ;
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
            EndLevel057( ) ;
         }
         CloseExtendedTableCursors057( ) ;
      }

      protected void DeferredUpdate057( )
      {
      }

      protected void delete( )
      {
         BeforeValidate057( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency057( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls057( ) ;
            AfterConfirm057( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete057( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000512 */
                  pr_default.execute(10, new Object[] {A5SectorId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Sector");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel057( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls057( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Sector";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000513 */
            pr_default.execute(11, new Object[] {A5SectorId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"EventoSector"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel057( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete057( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sector",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sector",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart057( )
      {
         /* Scan By routine */
         /* Using cursor T000514 */
         pr_default.execute(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A5SectorId = T000514_A5SectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext057( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A5SectorId = T000514_A5SectorId[0];
         }
      }

      protected void ScanEnd057( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm057( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert057( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate057( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete057( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete057( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate057( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes057( )
      {
         edtSectorNombre_Enabled = 0;
         AssignProp("", false, edtSectorNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorNombre_Enabled), 5, 0), true);
         edtSectorCapacidad_Enabled = 0;
         AssignProp("", false, edtSectorCapacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCapacidad_Enabled), 5, 0), true);
         edtSectorPrecio_Enabled = 0;
         AssignProp("", false, edtSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorPrecio_Enabled), 5, 0), true);
         dynLugarId.Enabled = 0;
         AssignProp("", false, dynLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLugarId.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes057( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sector.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SectorId,4,0))}, new string[] {"Gx_mode","SectorId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Sector");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("SectorId", context.localUtil.Format( (decimal)(A5SectorId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("sector:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z5SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5SectorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10SectorNombre", Z10SectorNombre);
         GxWebStd.gx_hidden_field( context, "Z20SectorCapacidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20SectorCapacidad), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21SectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21SectorPrecio), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SectorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECTORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SectorId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SectorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_LugarId), 4, 0, ".", "")));
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
         return formatLink("sector.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SectorId,4,0))}, new string[] {"Gx_mode","SectorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Sector" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sector" ;
      }

      protected void InitializeNonKey057( )
      {
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         A10SectorNombre = "";
         AssignAttri("", false, "A10SectorNombre", A10SectorNombre);
         A20SectorCapacidad = 0;
         AssignAttri("", false, "A20SectorCapacidad", StringUtil.LTrimStr( (decimal)(A20SectorCapacidad), 4, 0));
         A21SectorPrecio = 0;
         AssignAttri("", false, "A21SectorPrecio", StringUtil.LTrimStr( (decimal)(A21SectorPrecio), 4, 0));
         Z10SectorNombre = "";
         Z20SectorCapacidad = 0;
         Z21SectorPrecio = 0;
         Z4LugarId = 0;
      }

      protected void InitAll057( )
      {
         A5SectorId = 0;
         AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         InitializeNonKey057( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481219513227", true, true);
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
         context.AddJavascriptSource("sector.js", "?202481219513227", false, true);
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
         edtSectorNombre_Internalname = "SECTORNOMBRE";
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD";
         edtSectorPrecio_Internalname = "SECTORPRECIO";
         dynLugarId_Internalname = "LUGARID";
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
         Form.Caption = "Sector";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dynLugarId_Jsonclick = "";
         dynLugarId.Enabled = 1;
         edtSectorPrecio_Jsonclick = "";
         edtSectorPrecio_Enabled = 1;
         edtSectorCapacidad_Jsonclick = "";
         edtSectorCapacidad_Enabled = 1;
         edtSectorNombre_Jsonclick = "";
         edtSectorNombre_Enabled = 1;
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

      protected void GXDLALUGARID051( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALUGARID_data051( ) ;
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

      protected void GXALUGARID_html051( )
      {
         short gxdynajaxvalue;
         GXDLALUGARID_data051( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLugarId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynLugarId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLALUGARID_data051( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000515 */
         pr_default.execute(13);
         while ( (pr_default.getStatus(13) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000515_A4LugarId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000515_A9LugarNombre[0]);
            pr_default.readNext(13);
         }
         pr_default.close(13);
      }

      protected void init_web_controls( )
      {
         dynLugarId.Name = "LUGARID";
         dynLugarId.WebTags = "";
         dynLugarId.removeAllItems();
         /* Using cursor T000516 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            dynLugarId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000516_A4LugarId[0]), 4, 0)), T000516_A9LugarNombre[0], 0);
            pr_default.readNext(14);
         }
         pr_default.close(14);
         if ( dynLugarId.ItemCount > 0 )
         {
            A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
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

      public void Valid_Lugarid( )
      {
         A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000517 */
         pr_default.execute(15, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = dynLugarId_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7SectorId","fld":"vSECTORID","pic":"ZZZ9","hsh":true},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7SectorId","fld":"vSECTORID","pic":"ZZZ9","hsh":true},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12052","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_LUGARID","""{"handler":"Valid_Lugarid","iparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_LUGARID",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"}]}""");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z10SectorNombre = "";
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
         A10SectorNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         T00055_A5SectorId = new short[1] ;
         T00055_A10SectorNombre = new string[] {""} ;
         T00055_A20SectorCapacidad = new short[1] ;
         T00055_A21SectorPrecio = new short[1] ;
         T00055_A4LugarId = new short[1] ;
         T00054_A4LugarId = new short[1] ;
         T00056_A4LugarId = new short[1] ;
         T00057_A5SectorId = new short[1] ;
         T00053_A5SectorId = new short[1] ;
         T00053_A10SectorNombre = new string[] {""} ;
         T00053_A20SectorCapacidad = new short[1] ;
         T00053_A21SectorPrecio = new short[1] ;
         T00053_A4LugarId = new short[1] ;
         T00058_A5SectorId = new short[1] ;
         T00059_A5SectorId = new short[1] ;
         T00052_A5SectorId = new short[1] ;
         T00052_A10SectorNombre = new string[] {""} ;
         T00052_A20SectorCapacidad = new short[1] ;
         T00052_A21SectorPrecio = new short[1] ;
         T00052_A4LugarId = new short[1] ;
         T000510_A5SectorId = new short[1] ;
         T000513_A3EventoId = new short[1] ;
         T000513_A5SectorId = new short[1] ;
         T000514_A5SectorId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000515_A4LugarId = new short[1] ;
         T000515_A9LugarNombre = new string[] {""} ;
         T000516_A4LugarId = new short[1] ;
         T000516_A9LugarNombre = new string[] {""} ;
         T000517_A4LugarId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sector__default(),
            new Object[][] {
                new Object[] {
               T00052_A5SectorId, T00052_A10SectorNombre, T00052_A20SectorCapacidad, T00052_A21SectorPrecio, T00052_A4LugarId
               }
               , new Object[] {
               T00053_A5SectorId, T00053_A10SectorNombre, T00053_A20SectorCapacidad, T00053_A21SectorPrecio, T00053_A4LugarId
               }
               , new Object[] {
               T00054_A4LugarId
               }
               , new Object[] {
               T00055_A5SectorId, T00055_A10SectorNombre, T00055_A20SectorCapacidad, T00055_A21SectorPrecio, T00055_A4LugarId
               }
               , new Object[] {
               T00056_A4LugarId
               }
               , new Object[] {
               T00057_A5SectorId
               }
               , new Object[] {
               T00058_A5SectorId
               }
               , new Object[] {
               T00059_A5SectorId
               }
               , new Object[] {
               T000510_A5SectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000513_A3EventoId, T000513_A5SectorId
               }
               , new Object[] {
               T000514_A5SectorId
               }
               , new Object[] {
               T000515_A4LugarId, T000515_A9LugarNombre
               }
               , new Object[] {
               T000516_A4LugarId, T000516_A9LugarNombre
               }
               , new Object[] {
               T000517_A4LugarId
               }
            }
         );
         AV13Pgmname = "Sector";
      }

      private short wcpOAV7SectorId ;
      private short Z5SectorId ;
      private short Z20SectorCapacidad ;
      private short Z21SectorPrecio ;
      private short Z4LugarId ;
      private short N4LugarId ;
      private short GxWebError ;
      private short A4LugarId ;
      private short AV7SectorId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A20SectorCapacidad ;
      private short A21SectorPrecio ;
      private short A5SectorId ;
      private short AV11Insert_LugarId ;
      private short RcdFound7 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSectorNombre_Enabled ;
      private int edtSectorCapacidad_Enabled ;
      private int edtSectorPrecio_Enabled ;
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
      private string edtSectorNombre_Internalname ;
      private string dynLugarId_Internalname ;
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
      private string edtSectorNombre_Jsonclick ;
      private string edtSectorCapacidad_Internalname ;
      private string edtSectorCapacidad_Jsonclick ;
      private string edtSectorPrecio_Internalname ;
      private string edtSectorPrecio_Jsonclick ;
      private string dynLugarId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode7 ;
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
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z10SectorNombre ;
      private string A10SectorNombre ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynLugarId ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T00055_A5SectorId ;
      private string[] T00055_A10SectorNombre ;
      private short[] T00055_A20SectorCapacidad ;
      private short[] T00055_A21SectorPrecio ;
      private short[] T00055_A4LugarId ;
      private short[] T00054_A4LugarId ;
      private short[] T00056_A4LugarId ;
      private short[] T00057_A5SectorId ;
      private short[] T00053_A5SectorId ;
      private string[] T00053_A10SectorNombre ;
      private short[] T00053_A20SectorCapacidad ;
      private short[] T00053_A21SectorPrecio ;
      private short[] T00053_A4LugarId ;
      private short[] T00058_A5SectorId ;
      private short[] T00059_A5SectorId ;
      private short[] T00052_A5SectorId ;
      private string[] T00052_A10SectorNombre ;
      private short[] T00052_A20SectorCapacidad ;
      private short[] T00052_A21SectorPrecio ;
      private short[] T00052_A4LugarId ;
      private short[] T000510_A5SectorId ;
      private short[] T000513_A3EventoId ;
      private short[] T000513_A5SectorId ;
      private short[] T000514_A5SectorId ;
      private short[] T000515_A4LugarId ;
      private string[] T000515_A9LugarNombre ;
      private short[] T000516_A4LugarId ;
      private string[] T000516_A9LugarNombre ;
      private short[] T000517_A4LugarId ;
   }

   public class sector__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@SectorNombre",GXType.NVarChar,100,0) ,
          new ParDef("@SectorCapacidad",GXType.Int16,4,0) ,
          new ParDef("@SectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@SectorNombre",GXType.NVarChar,100,0) ,
          new ParDef("@SectorCapacidad",GXType.Int16,4,0) ,
          new ParDef("@SectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [SectorId], [SectorNombre], [SectorCapacidad], [SectorPrecio], [LugarId] FROM [Sector] WITH (UPDLOCK) WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [SectorId], [SectorNombre], [SectorCapacidad], [SectorPrecio], [LugarId] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT TM1.[SectorId], TM1.[SectorNombre], TM1.[SectorCapacidad], TM1.[SectorPrecio], TM1.[LugarId] FROM [Sector] TM1 WHERE TM1.[SectorId] = @SectorId ORDER BY TM1.[SectorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [SectorId] FROM [Sector] WHERE [SectorId] = @SectorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT TOP 1 [SectorId] FROM [Sector] WHERE ( [SectorId] > @SectorId) ORDER BY [SectorId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00059", "SELECT TOP 1 [SectorId] FROM [Sector] WHERE ( [SectorId] < @SectorId) ORDER BY [SectorId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000510", "INSERT INTO [Sector]([SectorNombre], [SectorCapacidad], [SectorPrecio], [LugarId]) VALUES(@SectorNombre, @SectorCapacidad, @SectorPrecio, @LugarId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000511", "UPDATE [Sector] SET [SectorNombre]=@SectorNombre, [SectorCapacidad]=@SectorCapacidad, [SectorPrecio]=@SectorPrecio, [LugarId]=@LugarId  WHERE [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmT000511)
             ,new CursorDef("T000512", "DELETE FROM [Sector]  WHERE [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmT000512)
             ,new CursorDef("T000513", "SELECT TOP 1 [EventoId], [SectorId] FROM [EventoSector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000514", "SELECT [SectorId] FROM [Sector] ORDER BY [SectorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000515", "SELECT [LugarId], [LugarNombre] FROM [Lugar] ORDER BY [LugarNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000516", "SELECT [LugarId], [LugarNombre] FROM [Lugar] ORDER BY [LugarNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000517", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
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
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
