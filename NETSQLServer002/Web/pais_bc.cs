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
   public class pais_bc : GxSilentTrn, IGxSilentTrn
   {
      public pais_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public pais_bc( IGxContext context )
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
         ReadRow068( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey068( ) ;
         standaloneModal( ) ;
         AddRow068( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z7PaisId = A7PaisId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls068( ) ;
            }
            else
            {
               CheckExtendedTable068( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors068( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM068( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z11PaisNombre = A11PaisNombre;
         }
         if ( GX_JID == -1 )
         {
            Z7PaisId = A7PaisId;
            Z11PaisNombre = A11PaisNombre;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load068( )
      {
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A7PaisId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound8 = 1;
            A11PaisNombre = BC00064_A11PaisNombre[0];
            ZM068( -1) ;
         }
         pr_default.close(2);
         OnLoadActions068( ) ;
      }

      protected void OnLoadActions068( )
      {
      }

      protected void CheckExtendedTable068( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors068( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey068( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A7PaisId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A7PaisId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM068( 1) ;
            RcdFound8 = 1;
            A7PaisId = BC00063_A7PaisId[0];
            A11PaisNombre = BC00063_A11PaisNombre[0];
            Z7PaisId = A7PaisId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load068( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey068( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey068( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey068( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_060( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency068( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A7PaisId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z11PaisNombre, BC00062_A11PaisNombre[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Pais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM068( 0) ;
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00066 */
                     pr_default.execute(4, new Object[] {A11PaisNombre});
                     A7PaisId = BC00066_A7PaisId[0];
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
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
               Load068( ) ;
            }
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void Update068( )
      {
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable068( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm068( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate068( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00067 */
                     pr_default.execute(5, new Object[] {A11PaisNombre, A7PaisId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate068( ) ;
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
            EndLevel068( ) ;
         }
         CloseExtendedTableCursors068( ) ;
      }

      protected void DeferredUpdate068( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate068( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency068( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls068( ) ;
            AfterConfirm068( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete068( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00068 */
                  pr_default.execute(6, new Object[] {A7PaisId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Pais");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel068( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls068( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00069 */
            pr_default.execute(7, new Object[] {A7PaisId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lugar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel068( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete068( ) ;
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

      public void ScanKeyStart068( )
      {
         /* Scan By routine */
         /* Using cursor BC000610 */
         pr_default.execute(8, new Object[] {A7PaisId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound8 = 1;
            A7PaisId = BC000610_A7PaisId[0];
            A11PaisNombre = BC000610_A11PaisNombre[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext068( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound8 = 0;
         ScanKeyLoad068( ) ;
      }

      protected void ScanKeyLoad068( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound8 = 1;
            A7PaisId = BC000610_A7PaisId[0];
            A11PaisNombre = BC000610_A11PaisNombre[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd068( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm068( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert068( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate068( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete068( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete068( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate068( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes068( )
      {
      }

      protected void send_integrity_lvl_hashes068( )
      {
      }

      protected void AddRow068( )
      {
         VarsToRow8( bcPais) ;
      }

      protected void ReadRow068( )
      {
         RowToVars8( bcPais, 1) ;
      }

      protected void InitializeNonKey068( )
      {
         A11PaisNombre = "";
         Z11PaisNombre = "";
      }

      protected void InitAll068( )
      {
         A7PaisId = 0;
         InitializeNonKey068( ) ;
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

      public void VarsToRow8( SdtPais obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Paisnombre = A11PaisNombre;
         obj8.gxTpr_Paisid = A7PaisId;
         obj8.gxTpr_Paisid_Z = Z7PaisId;
         obj8.gxTpr_Paisnombre_Z = Z11PaisNombre;
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( SdtPais obj8 )
      {
         obj8.gxTpr_Paisid = A7PaisId;
         return  ;
      }

      public void RowToVars8( SdtPais obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A11PaisNombre = obj8.gxTpr_Paisnombre;
         A7PaisId = obj8.gxTpr_Paisid;
         Z7PaisId = obj8.gxTpr_Paisid_Z;
         Z11PaisNombre = obj8.gxTpr_Paisnombre_Z;
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A7PaisId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey068( ) ;
         ScanKeyStart068( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7PaisId = A7PaisId;
         }
         ZM068( -1) ;
         OnLoadActions068( ) ;
         AddRow068( ) ;
         ScanKeyEnd068( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcPais, 0) ;
         ScanKeyStart068( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7PaisId = A7PaisId;
         }
         ZM068( -1) ;
         OnLoadActions068( ) ;
         AddRow068( ) ;
         ScanKeyEnd068( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey068( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert068( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A7PaisId != Z7PaisId )
               {
                  A7PaisId = Z7PaisId;
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
                  Update068( ) ;
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
                  if ( A7PaisId != Z7PaisId )
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
                        Insert068( ) ;
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
                        Insert068( ) ;
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
         RowToVars8( bcPais, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars8( bcPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert068( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow8( bcPais) ;
         }
         else
         {
            SdtPais auxBC = new SdtPais(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A7PaisId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPais);
               auxBC.Save();
               bcPais.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars8( bcPais, 1) ;
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
         RowToVars8( bcPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert068( ) ;
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
               VarsToRow8( bcPais) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow8( bcPais) ;
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
         RowToVars8( bcPais, 0) ;
         GetKey068( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A7PaisId != Z7PaisId )
            {
               A7PaisId = Z7PaisId;
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
            if ( A7PaisId != Z7PaisId )
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
         context.RollbackDataStores("pais_bc",pr_default);
         VarsToRow8( bcPais) ;
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
         Gx_mode = bcPais.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPais.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPais )
         {
            bcPais = (SdtPais)(sdt);
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcPais) ;
            }
            else
            {
               RowToVars8( bcPais, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcPais, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPais Pais_BC
      {
         get {
            return bcPais ;
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
         Z11PaisNombre = "";
         A11PaisNombre = "";
         BC00064_A7PaisId = new short[1] ;
         BC00064_A11PaisNombre = new string[] {""} ;
         BC00065_A7PaisId = new short[1] ;
         BC00063_A7PaisId = new short[1] ;
         BC00063_A11PaisNombre = new string[] {""} ;
         sMode8 = "";
         BC00062_A7PaisId = new short[1] ;
         BC00062_A11PaisNombre = new string[] {""} ;
         BC00066_A7PaisId = new short[1] ;
         BC00069_A4LugarId = new short[1] ;
         BC000610_A7PaisId = new short[1] ;
         BC000610_A11PaisNombre = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pais_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A7PaisId, BC00062_A11PaisNombre
               }
               , new Object[] {
               BC00063_A7PaisId, BC00063_A11PaisNombre
               }
               , new Object[] {
               BC00064_A7PaisId, BC00064_A11PaisNombre
               }
               , new Object[] {
               BC00065_A7PaisId
               }
               , new Object[] {
               BC00066_A7PaisId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00069_A4LugarId
               }
               , new Object[] {
               BC000610_A7PaisId, BC000610_A11PaisNombre
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z7PaisId ;
      private short A7PaisId ;
      private short RcdFound8 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode8 ;
      private bool returnInSub ;
      private string Z11PaisNombre ;
      private string A11PaisNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00064_A7PaisId ;
      private string[] BC00064_A11PaisNombre ;
      private short[] BC00065_A7PaisId ;
      private short[] BC00063_A7PaisId ;
      private string[] BC00063_A11PaisNombre ;
      private short[] BC00062_A7PaisId ;
      private string[] BC00062_A11PaisNombre ;
      private short[] BC00066_A7PaisId ;
      private short[] BC00069_A4LugarId ;
      private short[] BC000610_A7PaisId ;
      private string[] BC000610_A11PaisNombre ;
      private SdtPais bcPais ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class pais_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@PaisNombre",GXType.NVarChar,100,0)
          };
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@PaisNombre",GXType.NVarChar,100,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00069;
          prmBC00069 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [PaisId], [PaisNombre] FROM [Pais] WITH (UPDLOCK) WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [PaisId], [PaisNombre] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT TM1.[PaisId], TM1.[PaisNombre] FROM [Pais] TM1 WHERE TM1.[PaisId] = @PaisId ORDER BY TM1.[PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "INSERT INTO [Pais]([PaisNombre]) VALUES(@PaisNombre); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00067", "UPDATE [Pais] SET [PaisNombre]=@PaisNombre  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC00067)
             ,new CursorDef("BC00068", "DELETE FROM [Pais]  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC00068)
             ,new CursorDef("BC00069", "SELECT TOP 1 [LugarId] FROM [Lugar] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00069,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000610", "SELECT TM1.[PaisId], TM1.[PaisNombre] FROM [Pais] TM1 WHERE TM1.[PaisId] = @PaisId ORDER BY TM1.[PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
