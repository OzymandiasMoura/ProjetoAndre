using Serilog;
using Serilog.Sinks.PostgreSQL.ColumnWriters;

namespace ProjetoAndre.Domain.Erros.Logger;
public class LoggerConfig
{
    public static void Config()
    {
        var columnWriters = new Dictionary<string, ColumnWriterBase>
            {
                { "message", new RenderedMessageColumnWriter(NpgsqlTypes.NpgsqlDbType.Text) },
                { "message_template", new MessageTemplateColumnWriter(NpgsqlTypes.NpgsqlDbType.Text) },
                { "level", new LevelColumnWriter(true, NpgsqlTypes.NpgsqlDbType.Varchar) },
                { "time_stamp", new TimestampColumnWriter(NpgsqlTypes.NpgsqlDbType.Timestamp) },
                { "exception", new ExceptionColumnWriter(NpgsqlTypes.NpgsqlDbType.Text) },
                { "log_event", new LogEventSerializedColumnWriter(NpgsqlTypes.NpgsqlDbType.Jsonb) }
            };

        Log.Logger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(
                connectionString: "Host=localhost;Port=5432;Username=postgres;Password=Ozy@1195;Database=ProjetoAndreTeste",
                tableName: "logevents",
                columnOptions: columnWriters,
                needAutoCreateTable: true
            )
            .CreateLogger();
    }
}
