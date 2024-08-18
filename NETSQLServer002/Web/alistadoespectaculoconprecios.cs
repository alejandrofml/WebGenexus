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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class alistadoespectaculoconprecios : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("TallerGeneXus", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public alistadoespectaculoconprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public alistadoespectaculoconprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("ListadoEspectaculosConPrecios");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV8EspectaculoNombre = "";
            AV9LugarNombre = "";
            AV10SectorPrecio = 0;
            AV11SectorCapacidad = 0;
            AV13SectorCupoActual = 0;
            H0L0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 25, true, false, false, false, 0, 0, 0, 0, 1, 255, 192, 203) ;
            getPrinter().GxDrawText("Espectáculos", 0, Gx_line+0, 827, Gx_line+53, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
            /* Using cursor P000L2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1EspectaculoId = P000L2_A1EspectaculoId[0];
               A4LugarId = P000L2_A4LugarId[0];
               A14EspectaculoNombre = P000L2_A14EspectaculoNombre[0];
               A9LugarNombre = P000L2_A9LugarNombre[0];
               A3EventoId = P000L2_A3EventoId[0];
               A14EspectaculoNombre = P000L2_A14EspectaculoNombre[0];
               A9LugarNombre = P000L2_A9LugarNombre[0];
               AV8EspectaculoNombre = A14EspectaculoNombre;
               AV9LugarNombre = A9LugarNombre;
               H0L0( false, 70) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 1, 144, 238, 144) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A9LugarNombre, "")), 293, Gx_line+40, 686, Gx_line+67, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 1, 144, 238, 144) ;
               getPrinter().GxDrawText("Espectaculo:", 140, Gx_line+13, 293, Gx_line+40, 2, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 1, 144, 238, 144) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8EspectaculoNombre, "")), 293, Gx_line+13, 686, Gx_line+40, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 1, 144, 238, 144) ;
               getPrinter().GxDrawText("Lugar:", 140, Gx_line+40, 293, Gx_line+67, 2, 0, 0, 1) ;
               getPrinter().GxDrawLine(140, Gx_line+68, 687, Gx_line+68, 3, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(140, Gx_line+14, 687, Gx_line+14, 3, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+70);
               /* Using cursor P000L3 */
               pr_default.execute(1, new Object[] {A4LugarId, A3EventoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A21SectorPrecio = P000L3_A21SectorPrecio[0];
                  A20SectorCapacidad = P000L3_A20SectorCapacidad[0];
                  A10SectorNombre = P000L3_A10SectorNombre[0];
                  A5SectorId = P000L3_A5SectorId[0];
                  AV10SectorPrecio = A21SectorPrecio;
                  AV11SectorCapacidad = A20SectorCapacidad;
                  AV13SectorCupoActual = A25SectorCupoActual;
                  AV12SectorNombre = A10SectorNombre;
                  H0L0( false, 54) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 1, 240, 255, 240) ;
                  getPrinter().GxDrawText("Sector:", 140, Gx_line+0, 293, Gx_line+27, 2, 0, 0, 1) ;
                  getPrinter().GxDrawLine(493, Gx_line+27, 493, Gx_line+54, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(567, Gx_line+27, 567, Gx_line+54, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(367, Gx_line+27, 367, Gx_line+54, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(293, Gx_line+27, 686, Gx_line+27, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 1, 240, 255, 240) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12SectorNombre, "")), 293, Gx_line+0, 686, Gx_line+27, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13SectorCupoActual), "ZZZ9")), 567, Gx_line+27, 687, Gx_line+54, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10SectorPrecio), "ZZZ9")), 367, Gx_line+27, 494, Gx_line+54, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 1, 240, 255, 240) ;
                  getPrinter().GxDrawText("Cupos:", 493, Gx_line+27, 566, Gx_line+54, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Precio:", 140, Gx_line+27, 367, Gx_line+54, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+54);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0L0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void H0L0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV8EspectaculoNombre = "";
         AV9LugarNombre = "";
         P000L2_A1EspectaculoId = new short[1] ;
         P000L2_A4LugarId = new short[1] ;
         P000L2_A14EspectaculoNombre = new string[] {""} ;
         P000L2_A9LugarNombre = new string[] {""} ;
         P000L2_A3EventoId = new short[1] ;
         A14EspectaculoNombre = "";
         A9LugarNombre = "";
         P000L3_A4LugarId = new short[1] ;
         P000L3_A21SectorPrecio = new short[1] ;
         P000L3_A20SectorCapacidad = new short[1] ;
         P000L3_A10SectorNombre = new string[] {""} ;
         P000L3_A5SectorId = new short[1] ;
         A10SectorNombre = "";
         AV12SectorNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistadoespectaculoconprecios__default(),
            new Object[][] {
                new Object[] {
               P000L2_A1EspectaculoId, P000L2_A4LugarId, P000L2_A14EspectaculoNombre, P000L2_A9LugarNombre, P000L2_A3EventoId
               }
               , new Object[] {
               P000L3_A4LugarId, P000L3_A21SectorPrecio, P000L3_A20SectorCapacidad, P000L3_A10SectorNombre, P000L3_A5SectorId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV10SectorPrecio ;
      private short AV11SectorCapacidad ;
      private short AV13SectorCupoActual ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short A3EventoId ;
      private short A21SectorPrecio ;
      private short A20SectorCapacidad ;
      private short A5SectorId ;
      private short A25SectorCupoActual ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private string AV8EspectaculoNombre ;
      private string AV9LugarNombre ;
      private string A14EspectaculoNombre ;
      private string A9LugarNombre ;
      private string A10SectorNombre ;
      private string AV12SectorNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000L2_A1EspectaculoId ;
      private short[] P000L2_A4LugarId ;
      private string[] P000L2_A14EspectaculoNombre ;
      private string[] P000L2_A9LugarNombre ;
      private short[] P000L2_A3EventoId ;
      private short[] P000L3_A4LugarId ;
      private short[] P000L3_A21SectorPrecio ;
      private short[] P000L3_A20SectorCapacidad ;
      private string[] P000L3_A10SectorNombre ;
      private short[] P000L3_A5SectorId ;
   }

   public class alistadoespectaculoconprecios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000L2;
          prmP000L2 = new Object[] {
          };
          Object[] prmP000L3;
          prmP000L3 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000L2", "SELECT T1.[EspectaculoId], T1.[LugarId], T2.[EspectaculoNombre], T3.[LugarNombre], T1.[EventoId] FROM (([Evento] T1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = T1.[EspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T1.[LugarId]) ORDER BY T1.[EventoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000L2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000L3", "SELECT [LugarId], [SectorPrecio], [SectorCapacidad], [SectorNombre], [SectorId] FROM [Sector] WHERE ([LugarId] = @LugarId) AND (@EventoId = @EventoId) ORDER BY [LugarId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000L3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
