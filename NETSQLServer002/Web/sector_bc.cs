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
   public class sector_bc : GxSilentTrn, IGxSilentTrn
   {
      public sector_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public sector_bc( IGxContext context )
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
         ReadRow057( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey057( ) ;
         standaloneModal( ) ;
         AddRow057( ) ;
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
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z5SectorId = A5SectorId;
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
               if ( AnyError == 0 )
               {
                  ZM057( 2) ;
               }
               CloseExtendedTableCursors057( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM057( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z10SectorNombre = A10SectorNombre;
            Z20SectorCapacidad = A20SectorCapacidad;
            Z21SectorPrecio = A21SectorPrecio;
            Z4LugarId = A4LugarId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
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
      }

      protected void standaloneModal( )
      {
      }

      protected void Load057( )
      {
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A10SectorNombre = BC00055_A10SectorNombre[0];
            A20SectorCapacidad = BC00055_A20SectorCapacidad[0];
            A21SectorPrecio = BC00055_A21SectorPrecio[0];
            A4LugarId = BC00055_A4LugarId[0];
            ZM057( -1) ;
         }
         pr_default.close(3);
         OnLoadActions057( ) ;
      }

      protected void OnLoadActions057( )
      {
      }

      protected void CheckExtendedTable057( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
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

      protected void GetKey057( )
      {
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM057( 1) ;
            RcdFound7 = 1;
            A5SectorId = BC00053_A5SectorId[0];
            A10SectorNombre = BC00053_A10SectorNombre[0];
            A20SectorCapacidad = BC00053_A20SectorCapacidad[0];
            A21SectorPrecio = BC00053_A21SectorPrecio[0];
            A4LugarId = BC00053_A4LugarId[0];
            Z5SectorId = A5SectorId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load057( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey057( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey057( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey057( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_050( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency057( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A5SectorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Sector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z10SectorNombre, BC00052_A10SectorNombre[0]) != 0 ) || ( Z20SectorCapacidad != BC00052_A20SectorCapacidad[0] ) || ( Z21SectorPrecio != BC00052_A21SectorPrecio[0] ) || ( Z4LugarId != BC00052_A4LugarId[0] ) )
            {
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
                     /* Using cursor BC00057 */
                     pr_default.execute(5, new Object[] {A10SectorNombre, A20SectorCapacidad, A21SectorPrecio, A4LugarId});
                     A5SectorId = BC00057_A5SectorId[0];
                     pr_default.close(5);
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
                     /* Using cursor BC00058 */
                     pr_default.execute(6, new Object[] {A10SectorNombre, A20SectorCapacidad, A21SectorPrecio, A4LugarId, A5SectorId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Sector");
                     if ( (pr_default.getStatus(6) == 103) )
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
            EndLevel057( ) ;
         }
         CloseExtendedTableCursors057( ) ;
      }

      protected void DeferredUpdate057( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
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
                  /* Using cursor BC00059 */
                  pr_default.execute(7, new Object[] {A5SectorId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Sector");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel057( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls057( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000510 */
            pr_default.execute(8, new Object[] {A5SectorId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"EventoSector"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
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

      public void ScanKeyStart057( )
      {
         /* Scan By routine */
         /* Using cursor BC000511 */
         pr_default.execute(9, new Object[] {A5SectorId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A5SectorId = BC000511_A5SectorId[0];
            A10SectorNombre = BC000511_A10SectorNombre[0];
            A20SectorCapacidad = BC000511_A20SectorCapacidad[0];
            A21SectorPrecio = BC000511_A21SectorPrecio[0];
            A4LugarId = BC000511_A4LugarId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext057( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound7 = 0;
         ScanKeyLoad057( ) ;
      }

      protected void ScanKeyLoad057( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A5SectorId = BC000511_A5SectorId[0];
            A10SectorNombre = BC000511_A10SectorNombre[0];
            A20SectorCapacidad = BC000511_A20SectorCapacidad[0];
            A21SectorPrecio = BC000511_A21SectorPrecio[0];
            A4LugarId = BC000511_A4LugarId[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd057( )
      {
         pr_default.close(9);
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
      }

      protected void send_integrity_lvl_hashes057( )
      {
      }

      protected void AddRow057( )
      {
         VarsToRow7( bcSector) ;
      }

      protected void ReadRow057( )
      {
         RowToVars7( bcSector, 1) ;
      }

      protected void InitializeNonKey057( )
      {
         A10SectorNombre = "";
         A20SectorCapacidad = 0;
         A21SectorPrecio = 0;
         A4LugarId = 0;
         Z10SectorNombre = "";
         Z20SectorCapacidad = 0;
         Z21SectorPrecio = 0;
         Z4LugarId = 0;
      }

      protected void InitAll057( )
      {
         A5SectorId = 0;
         InitializeNonKey057( ) ;
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

      public void VarsToRow7( SdtSector obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Sectornombre = A10SectorNombre;
         obj7.gxTpr_Sectorcapacidad = A20SectorCapacidad;
         obj7.gxTpr_Sectorprecio = A21SectorPrecio;
         obj7.gxTpr_Lugarid = A4LugarId;
         obj7.gxTpr_Sectorid = A5SectorId;
         obj7.gxTpr_Sectorid_Z = Z5SectorId;
         obj7.gxTpr_Sectornombre_Z = Z10SectorNombre;
         obj7.gxTpr_Sectorcapacidad_Z = Z20SectorCapacidad;
         obj7.gxTpr_Sectorprecio_Z = Z21SectorPrecio;
         obj7.gxTpr_Lugarid_Z = Z4LugarId;
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( SdtSector obj7 )
      {
         obj7.gxTpr_Sectorid = A5SectorId;
         return  ;
      }

      public void RowToVars7( SdtSector obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A10SectorNombre = obj7.gxTpr_Sectornombre;
         A20SectorCapacidad = obj7.gxTpr_Sectorcapacidad;
         A21SectorPrecio = obj7.gxTpr_Sectorprecio;
         A4LugarId = obj7.gxTpr_Lugarid;
         A5SectorId = obj7.gxTpr_Sectorid;
         Z5SectorId = obj7.gxTpr_Sectorid_Z;
         Z10SectorNombre = obj7.gxTpr_Sectornombre_Z;
         Z20SectorCapacidad = obj7.gxTpr_Sectorcapacidad_Z;
         Z21SectorPrecio = obj7.gxTpr_Sectorprecio_Z;
         Z4LugarId = obj7.gxTpr_Lugarid_Z;
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A5SectorId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey057( ) ;
         ScanKeyStart057( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z5SectorId = A5SectorId;
         }
         ZM057( -1) ;
         OnLoadActions057( ) ;
         AddRow057( ) ;
         ScanKeyEnd057( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcSector, 0) ;
         ScanKeyStart057( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z5SectorId = A5SectorId;
         }
         ZM057( -1) ;
         OnLoadActions057( ) ;
         AddRow057( ) ;
         ScanKeyEnd057( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey057( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert057( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A5SectorId != Z5SectorId )
               {
                  A5SectorId = Z5SectorId;
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
                  Update057( ) ;
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
                  if ( A5SectorId != Z5SectorId )
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
                        Insert057( ) ;
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
                        Insert057( ) ;
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
         RowToVars7( bcSector, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcSector) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcSector, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert057( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcSector) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow7( bcSector) ;
         }
         else
         {
            SdtSector auxBC = new SdtSector(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A5SectorId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSector);
               auxBC.Save();
               bcSector.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars7( bcSector, 1) ;
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
         RowToVars7( bcSector, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert057( ) ;
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
               VarsToRow7( bcSector) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow7( bcSector) ;
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
         RowToVars7( bcSector, 0) ;
         GetKey057( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A5SectorId != Z5SectorId )
            {
               A5SectorId = Z5SectorId;
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
            if ( A5SectorId != Z5SectorId )
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
         context.RollbackDataStores("sector_bc",pr_default);
         VarsToRow7( bcSector) ;
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
         Gx_mode = bcSector.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSector.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSector )
         {
            bcSector = (SdtSector)(sdt);
            if ( StringUtil.StrCmp(bcSector.gxTpr_Mode, "") == 0 )
            {
               bcSector.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcSector) ;
            }
            else
            {
               RowToVars7( bcSector, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSector.gxTpr_Mode, "") == 0 )
            {
               bcSector.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcSector, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSector Sector_BC
      {
         get {
            return bcSector ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z10SectorNombre = "";
         A10SectorNombre = "";
         BC00055_A5SectorId = new short[1] ;
         BC00055_A10SectorNombre = new string[] {""} ;
         BC00055_A20SectorCapacidad = new short[1] ;
         BC00055_A21SectorPrecio = new short[1] ;
         BC00055_A4LugarId = new short[1] ;
         BC00054_A4LugarId = new short[1] ;
         BC00056_A5SectorId = new short[1] ;
         BC00053_A5SectorId = new short[1] ;
         BC00053_A10SectorNombre = new string[] {""} ;
         BC00053_A20SectorCapacidad = new short[1] ;
         BC00053_A21SectorPrecio = new short[1] ;
         BC00053_A4LugarId = new short[1] ;
         sMode7 = "";
         BC00052_A5SectorId = new short[1] ;
         BC00052_A10SectorNombre = new string[] {""} ;
         BC00052_A20SectorCapacidad = new short[1] ;
         BC00052_A21SectorPrecio = new short[1] ;
         BC00052_A4LugarId = new short[1] ;
         BC00057_A5SectorId = new short[1] ;
         BC000510_A3EventoId = new short[1] ;
         BC000510_A5SectorId = new short[1] ;
         BC000511_A5SectorId = new short[1] ;
         BC000511_A10SectorNombre = new string[] {""} ;
         BC000511_A20SectorCapacidad = new short[1] ;
         BC000511_A21SectorPrecio = new short[1] ;
         BC000511_A4LugarId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sector_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A5SectorId, BC00052_A10SectorNombre, BC00052_A20SectorCapacidad, BC00052_A21SectorPrecio, BC00052_A4LugarId
               }
               , new Object[] {
               BC00053_A5SectorId, BC00053_A10SectorNombre, BC00053_A20SectorCapacidad, BC00053_A21SectorPrecio, BC00053_A4LugarId
               }
               , new Object[] {
               BC00054_A4LugarId
               }
               , new Object[] {
               BC00055_A5SectorId, BC00055_A10SectorNombre, BC00055_A20SectorCapacidad, BC00055_A21SectorPrecio, BC00055_A4LugarId
               }
               , new Object[] {
               BC00056_A5SectorId
               }
               , new Object[] {
               BC00057_A5SectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000510_A3EventoId, BC000510_A5SectorId
               }
               , new Object[] {
               BC000511_A5SectorId, BC000511_A10SectorNombre, BC000511_A20SectorCapacidad, BC000511_A21SectorPrecio, BC000511_A4LugarId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z5SectorId ;
      private short A5SectorId ;
      private short Z20SectorCapacidad ;
      private short A20SectorCapacidad ;
      private short Z21SectorPrecio ;
      private short A21SectorPrecio ;
      private short Z4LugarId ;
      private short A4LugarId ;
      private short RcdFound7 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private bool returnInSub ;
      private string Z10SectorNombre ;
      private string A10SectorNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00055_A5SectorId ;
      private string[] BC00055_A10SectorNombre ;
      private short[] BC00055_A20SectorCapacidad ;
      private short[] BC00055_A21SectorPrecio ;
      private short[] BC00055_A4LugarId ;
      private short[] BC00054_A4LugarId ;
      private short[] BC00056_A5SectorId ;
      private short[] BC00053_A5SectorId ;
      private string[] BC00053_A10SectorNombre ;
      private short[] BC00053_A20SectorCapacidad ;
      private short[] BC00053_A21SectorPrecio ;
      private short[] BC00053_A4LugarId ;
      private short[] BC00052_A5SectorId ;
      private string[] BC00052_A10SectorNombre ;
      private short[] BC00052_A20SectorCapacidad ;
      private short[] BC00052_A21SectorPrecio ;
      private short[] BC00052_A4LugarId ;
      private short[] BC00057_A5SectorId ;
      private short[] BC000510_A3EventoId ;
      private short[] BC000510_A5SectorId ;
      private short[] BC000511_A5SectorId ;
      private string[] BC000511_A10SectorNombre ;
      private short[] BC000511_A20SectorCapacidad ;
      private short[] BC000511_A21SectorPrecio ;
      private short[] BC000511_A4LugarId ;
      private SdtSector bcSector ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class sector_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00052;
          prmBC00052 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00053;
          prmBC00053 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00054;
          prmBC00054 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00055;
          prmBC00055 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00056;
          prmBC00056 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00057;
          prmBC00057 = new Object[] {
          new ParDef("@SectorNombre",GXType.NVarChar,100,0) ,
          new ParDef("@SectorCapacidad",GXType.Int16,4,0) ,
          new ParDef("@SectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00058;
          prmBC00058 = new Object[] {
          new ParDef("@SectorNombre",GXType.NVarChar,100,0) ,
          new ParDef("@SectorCapacidad",GXType.Int16,4,0) ,
          new ParDef("@SectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00059;
          prmBC00059 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000510;
          prmBC000510 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000511;
          prmBC000511 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00052", "SELECT [SectorId], [SectorNombre], [SectorCapacidad], [SectorPrecio], [LugarId] FROM [Sector] WITH (UPDLOCK) WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00053", "SELECT [SectorId], [SectorNombre], [SectorCapacidad], [SectorPrecio], [LugarId] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00054", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00055", "SELECT TM1.[SectorId], TM1.[SectorNombre], TM1.[SectorCapacidad], TM1.[SectorPrecio], TM1.[LugarId] FROM [Sector] TM1 WHERE TM1.[SectorId] = @SectorId ORDER BY TM1.[SectorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00056", "SELECT [SectorId] FROM [Sector] WHERE [SectorId] = @SectorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00057", "INSERT INTO [Sector]([SectorNombre], [SectorCapacidad], [SectorPrecio], [LugarId]) VALUES(@SectorNombre, @SectorCapacidad, @SectorPrecio, @LugarId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00058", "UPDATE [Sector] SET [SectorNombre]=@SectorNombre, [SectorCapacidad]=@SectorCapacidad, [SectorPrecio]=@SectorPrecio, [LugarId]=@LugarId  WHERE [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmBC00058)
             ,new CursorDef("BC00059", "DELETE FROM [Sector]  WHERE [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmBC00059)
             ,new CursorDef("BC000510", "SELECT TOP 1 [EventoId], [SectorId] FROM [EventoSector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000511", "SELECT TM1.[SectorId], TM1.[SectorNombre], TM1.[SectorCapacidad], TM1.[SectorPrecio], TM1.[LugarId] FROM [Sector] TM1 WHERE TM1.[SectorId] = @SectorId ORDER BY TM1.[SectorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000511,100, GxCacheFrequency.OFF ,true,false )
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
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
