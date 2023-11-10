namespace PetProjectMarket.Shared.Model;

public class EmailMetadata
{
    public string AddressTo { get; set; }
    public string Subject { get; set; }
    public string? Body { get; set; }
    public string? AttachmentPath { get; set; }

    public EmailMetadata(string _address, string _subj, string? body = "", string? _attach = "") =>
        (AddressTo, Subject, Body, AttachmentPath) = (_address, _subj, body, _attach);
}