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
   public class invitacion_bc : GxSilentTrn, IGxSilentTrn
   {
      public invitacion_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public invitacion_bc( IGxContext context )
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
         ReadRow035( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey035( ) ;
         standaloneModal( ) ;
         AddRow035( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z6InvitacionId = A6InvitacionId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls035( ) ;
            }
            else
            {
               CheckExtendedTable035( ) ;
               if ( AnyError == 0 )
               {
                  ZM035( 2) ;
               }
               CloseExtendedTableCursors035( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM035( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z18InvitacionNombre = A18InvitacionNombre;
            Z19InvitacionNominada = A19InvitacionNominada;
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z6InvitacionId = A6InvitacionId;
            Z18InvitacionNombre = A18InvitacionNombre;
            Z19InvitacionNominada = A19InvitacionNominada;
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load035( )
      {
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A18InvitacionNombre = BC00035_A18InvitacionNombre[0];
            A19InvitacionNominada = BC00035_A19InvitacionNominada[0];
            A3EventoId = BC00035_A3EventoId[0];
            A5SectorId = BC00035_A5SectorId[0];
            ZM035( -1) ;
         }
         pr_default.close(3);
         OnLoadActions035( ) ;
      }

      protected void OnLoadActions035( )
      {
      }

      protected void CheckExtendedTable035( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'EventoSector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors035( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey035( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM035( 1) ;
            RcdFound5 = 1;
            A6InvitacionId = BC00033_A6InvitacionId[0];
            A18InvitacionNombre = BC00033_A18InvitacionNombre[0];
            A19InvitacionNominada = BC00033_A19InvitacionNominada[0];
            A3EventoId = BC00033_A3EventoId[0];
            A5SectorId = BC00033_A5SectorId[0];
            Z6InvitacionId = A6InvitacionId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load035( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey035( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey035( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey035( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_030( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency035( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A6InvitacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18InvitacionNombre, BC00032_A18InvitacionNombre[0]) != 0 ) || ( Z19InvitacionNominada != BC00032_A19InvitacionNominada[0] ) || ( Z3EventoId != BC00032_A3EventoId[0] ) || ( Z5SectorId != BC00032_A5SectorId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM035( 0) ;
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00037 */
                     pr_default.execute(5, new Object[] {A18InvitacionNombre, A19InvitacionNominada, A3EventoId, A5SectorId});
                     A6InvitacionId = BC00037_A6InvitacionId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
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
               Load035( ) ;
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void Update035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A18InvitacionNombre, A19InvitacionNominada, A3EventoId, A5SectorId, A6InvitacionId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate035( ) ;
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
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void DeferredUpdate035( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls035( ) ;
            AfterConfirm035( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete035( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00039 */
                  pr_default.execute(7, new Object[] {A6InvitacionId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Invitacion");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel035( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls035( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel035( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete035( ) ;
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

      public void ScanKeyStart035( )
      {
         /* Scan By routine */
         /* Using cursor BC000310 */
         pr_default.execute(8, new Object[] {A6InvitacionId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = BC000310_A6InvitacionId[0];
            A18InvitacionNombre = BC000310_A18InvitacionNombre[0];
            A19InvitacionNominada = BC000310_A19InvitacionNominada[0];
            A3EventoId = BC000310_A3EventoId[0];
            A5SectorId = BC000310_A5SectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext035( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound5 = 0;
         ScanKeyLoad035( ) ;
      }

      protected void ScanKeyLoad035( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = BC000310_A6InvitacionId[0];
            A18InvitacionNombre = BC000310_A18InvitacionNombre[0];
            A19InvitacionNominada = BC000310_A19InvitacionNominada[0];
            A3EventoId = BC000310_A3EventoId[0];
            A5SectorId = BC000310_A5SectorId[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd035( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm035( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert035( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate035( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete035( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete035( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate035( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes035( )
      {
      }

      protected void send_integrity_lvl_hashes035( )
      {
      }

      protected void AddRow035( )
      {
         VarsToRow5( bcInvitacion) ;
      }

      protected void ReadRow035( )
      {
         RowToVars5( bcInvitacion, 1) ;
      }

      protected void InitializeNonKey035( )
      {
         A18InvitacionNombre = "";
         A19InvitacionNominada = false;
         A3EventoId = 0;
         A5SectorId = 0;
         Z18InvitacionNombre = "";
         Z19InvitacionNominada = false;
         Z3EventoId = 0;
         Z5SectorId = 0;
      }

      protected void InitAll035( )
      {
         A6InvitacionId = 0;
         InitializeNonKey035( ) ;
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

      public void VarsToRow5( SdtInvitacion obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Invitacionnombre = A18InvitacionNombre;
         obj5.gxTpr_Invitacionnominada = A19InvitacionNominada;
         obj5.gxTpr_Eventoid = A3EventoId;
         obj5.gxTpr_Sectorid = A5SectorId;
         obj5.gxTpr_Invitacionid = A6InvitacionId;
         obj5.gxTpr_Invitacionid_Z = Z6InvitacionId;
         obj5.gxTpr_Invitacionnombre_Z = Z18InvitacionNombre;
         obj5.gxTpr_Invitacionnominada_Z = Z19InvitacionNominada;
         obj5.gxTpr_Eventoid_Z = Z3EventoId;
         obj5.gxTpr_Sectorid_Z = Z5SectorId;
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtInvitacion obj5 )
      {
         obj5.gxTpr_Invitacionid = A6InvitacionId;
         return  ;
      }

      public void RowToVars5( SdtInvitacion obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A18InvitacionNombre = obj5.gxTpr_Invitacionnombre;
         A19InvitacionNominada = obj5.gxTpr_Invitacionnominada;
         A3EventoId = obj5.gxTpr_Eventoid;
         A5SectorId = obj5.gxTpr_Sectorid;
         A6InvitacionId = obj5.gxTpr_Invitacionid;
         Z6InvitacionId = obj5.gxTpr_Invitacionid_Z;
         Z18InvitacionNombre = obj5.gxTpr_Invitacionnombre_Z;
         Z19InvitacionNominada = obj5.gxTpr_Invitacionnominada_Z;
         Z3EventoId = obj5.gxTpr_Eventoid_Z;
         Z5SectorId = obj5.gxTpr_Sectorid_Z;
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A6InvitacionId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey035( ) ;
         ScanKeyStart035( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6InvitacionId = A6InvitacionId;
         }
         ZM035( -1) ;
         OnLoadActions035( ) ;
         AddRow035( ) ;
         ScanKeyEnd035( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcInvitacion, 0) ;
         ScanKeyStart035( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z6InvitacionId = A6InvitacionId;
         }
         ZM035( -1) ;
         OnLoadActions035( ) ;
         AddRow035( ) ;
         ScanKeyEnd035( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey035( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert035( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A6InvitacionId != Z6InvitacionId )
               {
                  A6InvitacionId = Z6InvitacionId;
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
                  Update035( ) ;
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
                  if ( A6InvitacionId != Z6InvitacionId )
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
                        Insert035( ) ;
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
                        Insert035( ) ;
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
         RowToVars5( bcInvitacion, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcInvitacion) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcInvitacion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert035( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcInvitacion) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow5( bcInvitacion) ;
         }
         else
         {
            SdtInvitacion auxBC = new SdtInvitacion(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A6InvitacionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcInvitacion);
               auxBC.Save();
               bcInvitacion.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars5( bcInvitacion, 1) ;
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
         RowToVars5( bcInvitacion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert035( ) ;
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
               VarsToRow5( bcInvitacion) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow5( bcInvitacion) ;
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
         RowToVars5( bcInvitacion, 0) ;
         GetKey035( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A6InvitacionId != Z6InvitacionId )
            {
               A6InvitacionId = Z6InvitacionId;
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
            if ( A6InvitacionId != Z6InvitacionId )
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
         context.RollbackDataStores("invitacion_bc",pr_default);
         VarsToRow5( bcInvitacion) ;
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
         Gx_mode = bcInvitacion.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcInvitacion.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcInvitacion )
         {
            bcInvitacion = (SdtInvitacion)(sdt);
            if ( StringUtil.StrCmp(bcInvitacion.gxTpr_Mode, "") == 0 )
            {
               bcInvitacion.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcInvitacion) ;
            }
            else
            {
               RowToVars5( bcInvitacion, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcInvitacion.gxTpr_Mode, "") == 0 )
            {
               bcInvitacion.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcInvitacion, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtInvitacion Invitacion_BC
      {
         get {
            return bcInvitacion ;
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
         Z18InvitacionNombre = "";
         A18InvitacionNombre = "";
         BC00035_A6InvitacionId = new short[1] ;
         BC00035_A18InvitacionNombre = new string[] {""} ;
         BC00035_A19InvitacionNominada = new bool[] {false} ;
         BC00035_A3EventoId = new short[1] ;
         BC00035_A5SectorId = new short[1] ;
         BC00034_A3EventoId = new short[1] ;
         BC00036_A6InvitacionId = new short[1] ;
         BC00033_A6InvitacionId = new short[1] ;
         BC00033_A18InvitacionNombre = new string[] {""} ;
         BC00033_A19InvitacionNominada = new bool[] {false} ;
         BC00033_A3EventoId = new short[1] ;
         BC00033_A5SectorId = new short[1] ;
         sMode5 = "";
         BC00032_A6InvitacionId = new short[1] ;
         BC00032_A18InvitacionNombre = new string[] {""} ;
         BC00032_A19InvitacionNominada = new bool[] {false} ;
         BC00032_A3EventoId = new short[1] ;
         BC00032_A5SectorId = new short[1] ;
         BC00037_A6InvitacionId = new short[1] ;
         BC000310_A6InvitacionId = new short[1] ;
         BC000310_A18InvitacionNombre = new string[] {""} ;
         BC000310_A19InvitacionNominada = new bool[] {false} ;
         BC000310_A3EventoId = new short[1] ;
         BC000310_A5SectorId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invitacion_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A6InvitacionId, BC00032_A18InvitacionNombre, BC00032_A19InvitacionNominada, BC00032_A3EventoId, BC00032_A5SectorId
               }
               , new Object[] {
               BC00033_A6InvitacionId, BC00033_A18InvitacionNombre, BC00033_A19InvitacionNominada, BC00033_A3EventoId, BC00033_A5SectorId
               }
               , new Object[] {
               BC00034_A3EventoId
               }
               , new Object[] {
               BC00035_A6InvitacionId, BC00035_A18InvitacionNombre, BC00035_A19InvitacionNominada, BC00035_A3EventoId, BC00035_A5SectorId
               }
               , new Object[] {
               BC00036_A6InvitacionId
               }
               , new Object[] {
               BC00037_A6InvitacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000310_A6InvitacionId, BC000310_A18InvitacionNombre, BC000310_A19InvitacionNominada, BC000310_A3EventoId, BC000310_A5SectorId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z6InvitacionId ;
      private short A6InvitacionId ;
      private short Z3EventoId ;
      private short A3EventoId ;
      private short Z5SectorId ;
      private short A5SectorId ;
      private short RcdFound5 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode5 ;
      private bool returnInSub ;
      private bool Z19InvitacionNominada ;
      private bool A19InvitacionNominada ;
      private string Z18InvitacionNombre ;
      private string A18InvitacionNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00035_A6InvitacionId ;
      private string[] BC00035_A18InvitacionNombre ;
      private bool[] BC00035_A19InvitacionNominada ;
      private short[] BC00035_A3EventoId ;
      private short[] BC00035_A5SectorId ;
      private short[] BC00034_A3EventoId ;
      private short[] BC00036_A6InvitacionId ;
      private short[] BC00033_A6InvitacionId ;
      private string[] BC00033_A18InvitacionNombre ;
      private bool[] BC00033_A19InvitacionNominada ;
      private short[] BC00033_A3EventoId ;
      private short[] BC00033_A5SectorId ;
      private short[] BC00032_A6InvitacionId ;
      private string[] BC00032_A18InvitacionNombre ;
      private bool[] BC00032_A19InvitacionNominada ;
      private short[] BC00032_A3EventoId ;
      private short[] BC00032_A5SectorId ;
      private short[] BC00037_A6InvitacionId ;
      private short[] BC000310_A6InvitacionId ;
      private string[] BC000310_A18InvitacionNombre ;
      private bool[] BC000310_A19InvitacionNominada ;
      private short[] BC000310_A3EventoId ;
      private short[] BC000310_A5SectorId ;
      private SdtInvitacion bcInvitacion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class invitacion_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00032;
          prmBC00032 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00033;
          prmBC00033 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00034;
          prmBC00034 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00035;
          prmBC00035 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00036;
          prmBC00036 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00037;
          prmBC00037 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00038;
          prmBC00038 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00039;
          prmBC00039 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC000310;
          prmBC000310 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00032", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId] FROM [Invitacion] WITH (UPDLOCK) WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00033", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00034", "SELECT [EventoId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00035", "SELECT TM1.[InvitacionId], TM1.[InvitacionNombre], TM1.[InvitacionNominada], TM1.[EventoId], TM1.[SectorId] FROM [Invitacion] TM1 WHERE TM1.[InvitacionId] = @InvitacionId ORDER BY TM1.[InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00036", "SELECT [InvitacionId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00037", "INSERT INTO [Invitacion]([InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId]) VALUES(@InvitacionNombre, @InvitacionNominada, @EventoId, @SectorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00038", "UPDATE [Invitacion] SET [InvitacionNombre]=@InvitacionNombre, [InvitacionNominada]=@InvitacionNominada, [EventoId]=@EventoId, [SectorId]=@SectorId  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmBC00038)
             ,new CursorDef("BC00039", "DELETE FROM [Invitacion]  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmBC00039)
             ,new CursorDef("BC000310", "SELECT TM1.[InvitacionId], TM1.[InvitacionNombre], TM1.[InvitacionNominada], TM1.[EventoId], TM1.[SectorId] FROM [Invitacion] TM1 WHERE TM1.[InvitacionId] = @InvitacionId ORDER BY TM1.[InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
