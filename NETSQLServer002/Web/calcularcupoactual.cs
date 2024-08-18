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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class calcularcupoactual : GXProcedure
   {
      public calcularcupoactual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public calcularcupoactual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SectorId ,
                           short aP1_EventoId ,
                           out short aP2_CupoActual )
      {
         this.AV9SectorId = aP0_SectorId;
         this.AV10EventoId = aP1_EventoId;
         this.AV11CupoActual = 0 ;
         initialize();
         ExecuteImpl();
         aP2_CupoActual=this.AV11CupoActual;
      }

      public short executeUdp( short aP0_SectorId ,
                               short aP1_EventoId )
      {
         execute(aP0_SectorId, aP1_EventoId, out aP2_CupoActual);
         return AV11CupoActual ;
      }

      public void executeSubmit( short aP0_SectorId ,
                                 short aP1_EventoId ,
                                 out short aP2_CupoActual )
      {
         this.AV9SectorId = aP0_SectorId;
         this.AV10EventoId = aP1_EventoId;
         this.AV11CupoActual = 0 ;
         SubmitImpl();
         aP2_CupoActual=this.AV11CupoActual;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Cantidadvendidas = 0;
         AV8SectorCapacidad = 0;
         /* Using cursor P000F2 */
         pr_default.execute(0, new Object[] {AV9SectorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5SectorId = P000F2_A5SectorId[0];
            A20SectorCapacidad = P000F2_A20SectorCapacidad[0];
            AV8SectorCapacidad = A20SectorCapacidad;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Optimized group. */
         /* Using cursor P000F3 */
         pr_default.execute(1, new Object[] {AV10EventoId, AV9SectorId});
         cV12Cantidadvendidas = P000F3_AV12Cantidadvendidas[0];
         pr_default.close(1);
         AV12Cantidadvendidas = (short)(AV12Cantidadvendidas+cV12Cantidadvendidas*1);
         /* End optimized group. */
         /* Optimized group. */
         /* Using cursor P000F4 */
         pr_default.execute(2, new Object[] {AV10EventoId, AV9SectorId});
         cV12Cantidadvendidas = P000F4_AV12Cantidadvendidas[0];
         pr_default.close(2);
         AV12Cantidadvendidas = (short)(AV12Cantidadvendidas+cV12Cantidadvendidas*1);
         /* End optimized group. */
         AV11CupoActual = (short)(AV8SectorCapacidad-AV12Cantidadvendidas);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P000F2_A5SectorId = new short[1] ;
         P000F2_A20SectorCapacidad = new short[1] ;
         P000F3_AV12Cantidadvendidas = new short[1] ;
         P000F4_AV12Cantidadvendidas = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.calcularcupoactual__default(),
            new Object[][] {
                new Object[] {
               P000F2_A5SectorId, P000F2_A20SectorCapacidad
               }
               , new Object[] {
               P000F3_AV12Cantidadvendidas
               }
               , new Object[] {
               P000F4_AV12Cantidadvendidas
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9SectorId ;
      private short AV10EventoId ;
      private short AV11CupoActual ;
      private short AV12Cantidadvendidas ;
      private short AV8SectorCapacidad ;
      private short A5SectorId ;
      private short A20SectorCapacidad ;
      private short cV12Cantidadvendidas ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000F2_A5SectorId ;
      private short[] P000F2_A20SectorCapacidad ;
      private short[] P000F3_AV12Cantidadvendidas ;
      private short[] P000F4_AV12Cantidadvendidas ;
      private short aP2_CupoActual ;
   }

   public class calcularcupoactual__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000F2;
          prmP000F2 = new Object[] {
          new ParDef("@AV9SectorId",GXType.Int16,4,0)
          };
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@AV10EventoId",GXType.Int16,4,0) ,
          new ParDef("@AV9SectorId",GXType.Int16,4,0)
          };
          Object[] prmP000F4;
          prmP000F4 = new Object[] {
          new ParDef("@AV10EventoId",GXType.Int16,4,0) ,
          new ParDef("@AV9SectorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F2", "SELECT [SectorId], [SectorCapacidad] FROM [Sector] WHERE [SectorId] = @AV9SectorId ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000F3", "SELECT COUNT(*) FROM [Venta] WHERE [EventoId] = @AV10EventoId and [SectorId] = @AV9SectorId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000F4", "SELECT COUNT(*) FROM [Invitacion] WHERE [EventoId] = @AV10EventoId and [SectorId] = @AV9SectorId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F4,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
