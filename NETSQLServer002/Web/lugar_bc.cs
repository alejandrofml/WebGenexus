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
   public class lugar_bc : GxSilentTrn, IGxSilentTrn
   {
      public lugar_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public lugar_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow046( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey046( ) ;
         standaloneModal( ) ;
         AddRow046( ) ;
         Gx_mode = "INS";
         return  ;
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
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z4LugarId = A4LugarId;
               SetMode( "UPD") ;
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

      public bool Reindex( )
      {
         return true ;
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
               if ( AnyError == 0 )
               {
                  ZM046( 2) ;
                  ZM046( 3) ;
               }
               CloseExtendedTableCursors046( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12042( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM046( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z9LugarNombre = A9LugarNombre;
            Z13LugarDireccion = A13LugarDireccion;
            Z7PaisId = A7PaisId;
            Z22TotalEspectaculos = A22TotalEspectaculos;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z22TotalEspectaculos = A22TotalEspectaculos;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z22TotalEspectaculos = A22TotalEspectaculos;
         }
         if ( GX_JID == -1 )
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
      }

      protected void standaloneModal( )
      {
      }

      protected void Load046( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(4, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
            A9LugarNombre = BC00048_A9LugarNombre[0];
            A13LugarDireccion = BC00048_A13LugarDireccion[0];
            A7PaisId = BC00048_A7PaisId[0];
            A22TotalEspectaculos = BC00048_A22TotalEspectaculos[0];
            n22TotalEspectaculos = BC00048_n22TotalEspectaculos[0];
            ZM046( -1) ;
         }
         pr_default.close(4);
         OnLoadActions046( ) ;
      }

      protected void OnLoadActions046( )
      {
      }

      protected void CheckExtendedTable046( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00046 */
         pr_default.execute(3, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A22TotalEspectaculos = BC00046_A22TotalEspectaculos[0];
            n22TotalEspectaculos = BC00046_n22TotalEspectaculos[0];
         }
         else
         {
            A22TotalEspectaculos = 0;
            n22TotalEspectaculos = false;
         }
         pr_default.close(3);
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A7PaisId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors046( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey046( )
      {
         /* Using cursor BC00049 */
         pr_default.execute(5, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM046( 1) ;
            RcdFound6 = 1;
            A4LugarId = BC00043_A4LugarId[0];
            A9LugarNombre = BC00043_A9LugarNombre[0];
            A13LugarDireccion = BC00043_A13LugarDireccion[0];
            A7PaisId = BC00043_A7PaisId[0];
            Z4LugarId = A4LugarId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load046( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey046( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey046( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_040( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency046( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z9LugarNombre, BC00042_A9LugarNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z13LugarDireccion, BC00042_A13LugarDireccion[0]) != 0 ) || ( Z7PaisId != BC00042_A7PaisId[0] ) )
            {
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
                     /* Using cursor BC000410 */
                     pr_default.execute(6, new Object[] {A9LugarNombre, A13LugarDireccion, A7PaisId});
                     A4LugarId = BC000410_A4LugarId[0];
                     pr_default.close(6);
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
                     /* Using cursor BC000411 */
                     pr_default.execute(7, new Object[] {A9LugarNombre, A13LugarDireccion, A7PaisId, A4LugarId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Lugar");
                     if ( (pr_default.getStatus(7) == 103) )
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
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
         Gx_mode = "DLT";
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
                  /* Using cursor BC000412 */
                  pr_default.execute(8, new Object[] {A4LugarId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Lugar");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
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
         EndLevel046( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls046( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000414 */
            pr_default.execute(9, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               A22TotalEspectaculos = BC000414_A22TotalEspectaculos[0];
               n22TotalEspectaculos = BC000414_n22TotalEspectaculos[0];
            }
            else
            {
               A22TotalEspectaculos = 0;
               n22TotalEspectaculos = false;
            }
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000415 */
            pr_default.execute(10, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sector"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000416 */
            pr_default.execute(11, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Evento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
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
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart046( )
      {
         /* Scan By routine */
         /* Using cursor BC000418 */
         pr_default.execute(12, new Object[] {A4LugarId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A4LugarId = BC000418_A4LugarId[0];
            A9LugarNombre = BC000418_A9LugarNombre[0];
            A13LugarDireccion = BC000418_A13LugarDireccion[0];
            A7PaisId = BC000418_A7PaisId[0];
            A22TotalEspectaculos = BC000418_A22TotalEspectaculos[0];
            n22TotalEspectaculos = BC000418_n22TotalEspectaculos[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext046( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound6 = 0;
         ScanKeyLoad046( ) ;
      }

      protected void ScanKeyLoad046( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A4LugarId = BC000418_A4LugarId[0];
            A9LugarNombre = BC000418_A9LugarNombre[0];
            A13LugarDireccion = BC000418_A13LugarDireccion[0];
            A7PaisId = BC000418_A7PaisId[0];
            A22TotalEspectaculos = BC000418_A22TotalEspectaculos[0];
            n22TotalEspectaculos = BC000418_n22TotalEspectaculos[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd046( )
      {
         pr_default.close(12);
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
      }

      protected void send_integrity_lvl_hashes046( )
      {
      }

      protected void AddRow046( )
      {
         VarsToRow6( bcLugar) ;
      }

      protected void ReadRow046( )
      {
         RowToVars6( bcLugar, 1) ;
      }

      protected void InitializeNonKey046( )
      {
         A9LugarNombre = "";
         A13LugarDireccion = "";
         A7PaisId = 0;
         A22TotalEspectaculos = 0;
         n22TotalEspectaculos = false;
         Z9LugarNombre = "";
         Z13LugarDireccion = "";
         Z7PaisId = 0;
      }

      protected void InitAll046( )
      {
         A4LugarId = 0;
         InitializeNonKey046( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow6( SdtLugar obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Lugarnombre = A9LugarNombre;
         obj6.gxTpr_Lugardireccion = A13LugarDireccion;
         obj6.gxTpr_Paisid = A7PaisId;
         obj6.gxTpr_Totalespectaculos = A22TotalEspectaculos;
         obj6.gxTpr_Lugarid = A4LugarId;
         obj6.gxTpr_Lugarid_Z = Z4LugarId;
         obj6.gxTpr_Lugarnombre_Z = Z9LugarNombre;
         obj6.gxTpr_Lugardireccion_Z = Z13LugarDireccion;
         obj6.gxTpr_Paisid_Z = Z7PaisId;
         obj6.gxTpr_Totalespectaculos_Z = Z22TotalEspectaculos;
         obj6.gxTpr_Totalespectaculos_N = (short)(Convert.ToInt16(n22TotalEspectaculos));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtLugar obj6 )
      {
         obj6.gxTpr_Lugarid = A4LugarId;
         return  ;
      }

      public void RowToVars6( SdtLugar obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A9LugarNombre = obj6.gxTpr_Lugarnombre;
         A13LugarDireccion = obj6.gxTpr_Lugardireccion;
         A7PaisId = obj6.gxTpr_Paisid;
         A22TotalEspectaculos = obj6.gxTpr_Totalespectaculos;
         n22TotalEspectaculos = false;
         A4LugarId = obj6.gxTpr_Lugarid;
         Z4LugarId = obj6.gxTpr_Lugarid_Z;
         Z9LugarNombre = obj6.gxTpr_Lugarnombre_Z;
         Z13LugarDireccion = obj6.gxTpr_Lugardireccion_Z;
         Z7PaisId = obj6.gxTpr_Paisid_Z;
         Z22TotalEspectaculos = obj6.gxTpr_Totalespectaculos_Z;
         n22TotalEspectaculos = (bool)(Convert.ToBoolean(obj6.gxTpr_Totalespectaculos_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A4LugarId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey046( ) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4LugarId = A4LugarId;
         }
         ZM046( -1) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars6( bcLugar, 0) ;
         ScanKeyStart046( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4LugarId = A4LugarId;
         }
         ZM046( -1) ;
         OnLoadActions046( ) ;
         AddRow046( ) ;
         ScanKeyEnd046( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey046( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert046( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A4LugarId != Z4LugarId )
               {
                  A4LugarId = Z4LugarId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update046( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A4LugarId != Z4LugarId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert046( ) ;
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
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert046( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcLugar, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcLugar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcLugar) ;
         }
         else
         {
            SdtLugar auxBC = new SdtLugar(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A4LugarId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLugar);
               auxBC.Save();
               bcLugar.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcLugar, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcLugar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert046( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow6( bcLugar) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcLugar) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcLugar, 0) ;
         GetKey046( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A4LugarId != Z4LugarId )
            {
               A4LugarId = Z4LugarId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A4LugarId != Z4LugarId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(9);
         context.RollbackDataStores("lugar_bc",pr_default);
         VarsToRow6( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcLugar.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLugar.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLugar )
         {
            bcLugar = (SdtLugar)(sdt);
            if ( StringUtil.StrCmp(bcLugar.gxTpr_Mode, "") == 0 )
            {
               bcLugar.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcLugar) ;
            }
            else
            {
               RowToVars6( bcLugar, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLugar.gxTpr_Mode, "") == 0 )
            {
               bcLugar.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcLugar, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtLugar Lugar_BC
      {
         get {
            return bcLugar ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z9LugarNombre = "";
         A9LugarNombre = "";
         Z13LugarDireccion = "";
         A13LugarDireccion = "";
         BC00048_A4LugarId = new short[1] ;
         BC00048_A9LugarNombre = new string[] {""} ;
         BC00048_A13LugarDireccion = new string[] {""} ;
         BC00048_A7PaisId = new short[1] ;
         BC00048_A22TotalEspectaculos = new short[1] ;
         BC00048_n22TotalEspectaculos = new bool[] {false} ;
         BC00046_A22TotalEspectaculos = new short[1] ;
         BC00046_n22TotalEspectaculos = new bool[] {false} ;
         BC00044_A7PaisId = new short[1] ;
         BC00049_A4LugarId = new short[1] ;
         BC00043_A4LugarId = new short[1] ;
         BC00043_A9LugarNombre = new string[] {""} ;
         BC00043_A13LugarDireccion = new string[] {""} ;
         BC00043_A7PaisId = new short[1] ;
         sMode6 = "";
         BC00042_A4LugarId = new short[1] ;
         BC00042_A9LugarNombre = new string[] {""} ;
         BC00042_A13LugarDireccion = new string[] {""} ;
         BC00042_A7PaisId = new short[1] ;
         BC000410_A4LugarId = new short[1] ;
         BC000414_A22TotalEspectaculos = new short[1] ;
         BC000414_n22TotalEspectaculos = new bool[] {false} ;
         BC000415_A5SectorId = new short[1] ;
         BC000416_A3EventoId = new short[1] ;
         BC000418_A4LugarId = new short[1] ;
         BC000418_A9LugarNombre = new string[] {""} ;
         BC000418_A13LugarDireccion = new string[] {""} ;
         BC000418_A7PaisId = new short[1] ;
         BC000418_A22TotalEspectaculos = new short[1] ;
         BC000418_n22TotalEspectaculos = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.lugar_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A4LugarId, BC00042_A9LugarNombre, BC00042_A13LugarDireccion, BC00042_A7PaisId
               }
               , new Object[] {
               BC00043_A4LugarId, BC00043_A9LugarNombre, BC00043_A13LugarDireccion, BC00043_A7PaisId
               }
               , new Object[] {
               BC00044_A7PaisId
               }
               , new Object[] {
               BC00046_A22TotalEspectaculos, BC00046_n22TotalEspectaculos
               }
               , new Object[] {
               BC00048_A4LugarId, BC00048_A9LugarNombre, BC00048_A13LugarDireccion, BC00048_A7PaisId, BC00048_A22TotalEspectaculos, BC00048_n22TotalEspectaculos
               }
               , new Object[] {
               BC00049_A4LugarId
               }
               , new Object[] {
               BC000410_A4LugarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000414_A22TotalEspectaculos, BC000414_n22TotalEspectaculos
               }
               , new Object[] {
               BC000415_A5SectorId
               }
               , new Object[] {
               BC000416_A3EventoId
               }
               , new Object[] {
               BC000418_A4LugarId, BC000418_A9LugarNombre, BC000418_A13LugarDireccion, BC000418_A7PaisId, BC000418_A22TotalEspectaculos, BC000418_n22TotalEspectaculos
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z4LugarId ;
      private short A4LugarId ;
      private short Z7PaisId ;
      private short A7PaisId ;
      private short Z22TotalEspectaculos ;
      private short A22TotalEspectaculos ;
      private short RcdFound6 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode6 ;
      private bool returnInSub ;
      private bool n22TotalEspectaculos ;
      private string Z9LugarNombre ;
      private string A9LugarNombre ;
      private string Z13LugarDireccion ;
      private string A13LugarDireccion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00048_A4LugarId ;
      private string[] BC00048_A9LugarNombre ;
      private string[] BC00048_A13LugarDireccion ;
      private short[] BC00048_A7PaisId ;
      private short[] BC00048_A22TotalEspectaculos ;
      private bool[] BC00048_n22TotalEspectaculos ;
      private short[] BC00046_A22TotalEspectaculos ;
      private bool[] BC00046_n22TotalEspectaculos ;
      private short[] BC00044_A7PaisId ;
      private short[] BC00049_A4LugarId ;
      private short[] BC00043_A4LugarId ;
      private string[] BC00043_A9LugarNombre ;
      private string[] BC00043_A13LugarDireccion ;
      private short[] BC00043_A7PaisId ;
      private short[] BC00042_A4LugarId ;
      private string[] BC00042_A9LugarNombre ;
      private string[] BC00042_A13LugarDireccion ;
      private short[] BC00042_A7PaisId ;
      private short[] BC000410_A4LugarId ;
      private short[] BC000414_A22TotalEspectaculos ;
      private bool[] BC000414_n22TotalEspectaculos ;
      private short[] BC000415_A5SectorId ;
      private short[] BC000416_A3EventoId ;
      private short[] BC000418_A4LugarId ;
      private string[] BC000418_A9LugarNombre ;
      private string[] BC000418_A13LugarDireccion ;
      private short[] BC000418_A7PaisId ;
      private short[] BC000418_A22TotalEspectaculos ;
      private bool[] BC000418_n22TotalEspectaculos ;
      private SdtLugar bcLugar ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class lugar_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00042;
          prmBC00042 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00043;
          prmBC00043 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00044;
          prmBC00044 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00046;
          prmBC00046 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00048;
          prmBC00048 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00049;
          prmBC00049 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000410;
          prmBC000410 = new Object[] {
          new ParDef("@LugarNombre",GXType.NVarChar,100,0) ,
          new ParDef("@LugarDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000411;
          prmBC000411 = new Object[] {
          new ParDef("@LugarNombre",GXType.NVarChar,100,0) ,
          new ParDef("@LugarDireccion",GXType.NVarChar,1024,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000412;
          prmBC000412 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000414;
          prmBC000414 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000415;
          prmBC000415 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000416;
          prmBC000416 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000418;
          prmBC000418 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00042", "SELECT [LugarId], [LugarNombre], [LugarDireccion], [PaisId] FROM [Lugar] WITH (UPDLOCK) WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00043", "SELECT [LugarId], [LugarNombre], [LugarDireccion], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00044", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00046", "SELECT COALESCE( T1.[TotalEspectaculos], 0) AS TotalEspectaculos FROM (SELECT COUNT(*) AS TotalEspectaculos, [LugarId] FROM [Evento] GROUP BY [LugarId] ) T1 WHERE T1.[LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00048", "SELECT TM1.[LugarId], TM1.[LugarNombre], TM1.[LugarDireccion], TM1.[PaisId], COALESCE( T2.[TotalEspectaculos], 0) AS TotalEspectaculos FROM ([Lugar] TM1 LEFT JOIN (SELECT COUNT(*) AS TotalEspectaculos, [LugarId] FROM [Evento] GROUP BY [LugarId] ) T2 ON T2.[LugarId] = TM1.[LugarId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00049", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00049,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000410", "INSERT INTO [Lugar]([LugarNombre], [LugarDireccion], [PaisId]) VALUES(@LugarNombre, @LugarDireccion, @PaisId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000410,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000411", "UPDATE [Lugar] SET [LugarNombre]=@LugarNombre, [LugarDireccion]=@LugarDireccion, [PaisId]=@PaisId  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmBC000411)
             ,new CursorDef("BC000412", "DELETE FROM [Lugar]  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmBC000412)
             ,new CursorDef("BC000414", "SELECT COALESCE( T1.[TotalEspectaculos], 0) AS TotalEspectaculos FROM (SELECT COUNT(*) AS TotalEspectaculos, [LugarId] FROM [Evento] GROUP BY [LugarId] ) T1 WHERE T1.[LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000415", "SELECT TOP 1 [SectorId] FROM [Sector] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000416", "SELECT TOP 1 [EventoId] FROM [Evento] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000418", "SELECT TM1.[LugarId], TM1.[LugarNombre], TM1.[LugarDireccion], TM1.[PaisId], COALESCE( T2.[TotalEspectaculos], 0) AS TotalEspectaculos FROM ([Lugar] TM1 LEFT JOIN (SELECT COUNT(*) AS TotalEspectaculos, [LugarId] FROM [Evento] GROUP BY [LugarId] ) T2 ON T2.[LugarId] = TM1.[LugarId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000418,100, GxCacheFrequency.OFF ,true,false )
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
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
