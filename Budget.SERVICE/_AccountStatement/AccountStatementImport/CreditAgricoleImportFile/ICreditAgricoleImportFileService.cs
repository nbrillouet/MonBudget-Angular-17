using Budget.MODEL;
using Budget.MODEL.Database;
using Budget.MODEL.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget.SERVICE
{
    public interface ICreditAgricoleImportFileService
    {
        Boolean isCreditAgricoleFile(string[] header);
        StreamReader FormatFile(StreamReader reader, User user);
        StreamReader GetFormatFile(StreamReader reader, User user);
        bool IsFormatFile(StreamReader reader);
        List<AccountStatementImportFile> ImportFile(StreamReader reader, AsiForDetail asiForDetail);
    }

}
