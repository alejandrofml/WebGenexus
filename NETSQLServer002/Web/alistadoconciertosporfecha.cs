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
   public class alistadoconciertosporfecha : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "Fecha");
            if ( ! entryPointCalled )
            {
               AV13Fecha = context.localUtil.ParseDateParm( gxfirstwebparm);
            }
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public alistadoconciertosporfecha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public alistadoconciertosporfecha( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_Fecha )
      {
         this.AV13Fecha = aP0_Fecha;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( DateTime aP0_Fecha )
      {
         this.AV13Fecha = aP0_Fecha;
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
         setOutputFileName("ListadoConciertosPorFecha");
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
            AV11TipoEspectaculoNombre = "";
            AV8EspectaculoNombre = "";
            AV10EventoHoraFecha = DateTimeUtil.Now( context);
            H0M0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 25, true, false, false, false, 0, 0, 0, 0, 1, 255, 192, 203) ;
            getPrinter().GxDrawText("Conciertos por fecha", 0, Gx_line+0, 827, Gx_line+53, 1, 0, 0, 1) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
            /* Using cursor P000M2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A12TipoEspectaculoNombre = P000M2_A12TipoEspectaculoNombre[0];
               A2TipoEspectaculoId = P000M2_A2TipoEspectaculoId[0];
               AV12TipoId = A2TipoEspectaculoId;
               /* Using cursor P000M3 */
               pr_default.execute(1, new Object[] {AV12TipoId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A2TipoEspectaculoId = P000M3_A2TipoEspectaculoId[0];
                  A14EspectaculoNombre = P000M3_A14EspectaculoNombre[0];
                  A1EspectaculoId = P000M3_A1EspectaculoId[0];
                  AV8EspectaculoNombre = A14EspectaculoNombre;
                  AV9EspId = A1EspectaculoId;
                  /* Using cursor P000M4 */
                  pr_default.execute(2, new Object[] {AV9EspId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     BRK0M4 = false;
                     A1EspectaculoId = P000M4_A1EspectaculoId[0];
                     A17EventoHoraFecha = P000M4_A17EventoHoraFecha[0];
                     A3EventoId = P000M4_A3EventoId[0];
                     while ( (pr_default.getStatus(2) != 101) && ( P000M4_A1EspectaculoId[0] == A1EspectaculoId ) )
                     {
                        BRK0M4 = false;
                        A17EventoHoraFecha = P000M4_A17EventoHoraFecha[0];
                        A3EventoId = P000M4_A3EventoId[0];
                        if ( DateTimeUtil.ResetTime ( DateTimeUtil.ResetTime( A17EventoHoraFecha) ) >= DateTimeUtil.ResetTime ( AV13Fecha ) )
                        {
                           AV10EventoHoraFecha = A17EventoHoraFecha;
                           H0M0( false, 81) ;
                           getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 1, 255, 245, 238) ;
                           getPrinter().GxDrawText("Fecha y hora:", 167, Gx_line+40, 320, Gx_line+67, 2, 0, 0, 1) ;
                           getPrinter().GxDrawText("Espectaculo:", 167, Gx_line+13, 320, Gx_line+40, 2, 0, 0, 1) ;
                           getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 1, 255, 245, 238) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8EspectaculoNombre, "")), 320, Gx_line+13, 667, Gx_line+40, 1, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV10EventoHoraFecha, "99/99/99 99:99"), 320, Gx_line+40, 667, Gx_line+67, 1, 0, 0, 1) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+81);
                        }
                        BRK0M4 = true;
                        pr_default.readNext(2);
                     }
                     if ( ! BRK0M4 )
                     {
                        BRK0M4 = true;
                        pr_default.readNext(2);
                     }
                  }
                  pr_default.close(2);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0M0( true, 0) ;
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

      protected void H0M0( bool bFoot ,
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
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
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
         AV11TipoEspectaculoNombre = "";
         AV8EspectaculoNombre = "";
         AV10EventoHoraFecha = (DateTime)(DateTime.MinValue);
         P000M2_A12TipoEspectaculoNombre = new string[] {""} ;
         P000M2_A2TipoEspectaculoId = new short[1] ;
         A12TipoEspectaculoNombre = "";
         P000M3_A2TipoEspectaculoId = new short[1] ;
         P000M3_A14EspectaculoNombre = new string[] {""} ;
         P000M3_A1EspectaculoId = new short[1] ;
         A14EspectaculoNombre = "";
         P000M4_A1EspectaculoId = new short[1] ;
         P000M4_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         P000M4_A3EventoId = new short[1] ;
         A17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistadoconciertosporfecha__default(),
            new Object[][] {
                new Object[] {
               P000M2_A12TipoEspectaculoNombre, P000M2_A2TipoEspectaculoId
               }
               , new Object[] {
               P000M3_A2TipoEspectaculoId, P000M3_A14EspectaculoNombre, P000M3_A1EspectaculoId
               }
               , new Object[] {
               P000M4_A1EspectaculoId, P000M4_A17EventoHoraFecha, P000M4_A3EventoId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A2TipoEspectaculoId ;
      private short AV12TipoId ;
      private short A1EspectaculoId ;
      private short AV9EspId ;
      private short A3EventoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private DateTime AV10EventoHoraFecha ;
      private DateTime A17EventoHoraFecha ;
      private DateTime AV13Fecha ;
      private bool entryPointCalled ;
      private bool BRK0M4 ;
      private string AV11TipoEspectaculoNombre ;
      private string AV8EspectaculoNombre ;
      private string A12TipoEspectaculoNombre ;
      private string A14EspectaculoNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P000M2_A12TipoEspectaculoNombre ;
      private short[] P000M2_A2TipoEspectaculoId ;
      private short[] P000M3_A2TipoEspectaculoId ;
      private string[] P000M3_A14EspectaculoNombre ;
      private short[] P000M3_A1EspectaculoId ;
      private short[] P000M4_A1EspectaculoId ;
      private DateTime[] P000M4_A17EventoHoraFecha ;
      private short[] P000M4_A3EventoId ;
   }

   public class alistadoconciertosporfecha__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000M2;
          prmP000M2 = new Object[] {
          };
          Object[] prmP000M3;
          prmP000M3 = new Object[] {
          new ParDef("@AV12TipoId",GXType.Int16,4,0)
          };
          Object[] prmP000M4;
          prmP000M4 = new Object[] {
          new ParDef("@AV9EspId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000M2", "SELECT [TipoEspectaculoNombre], [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoNombre] = 'Concierto' ORDER BY [TipoEspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000M3", "SELECT [TipoEspectaculoId], [EspectaculoNombre], [EspectaculoId] FROM [Espectaculo] WHERE [TipoEspectaculoId] = @AV12TipoId ORDER BY [TipoEspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000M4", "SELECT [EspectaculoId], [EventoHoraFecha], [EventoId] FROM [Evento] WHERE [EspectaculoId] = @AV9EspId ORDER BY [EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
