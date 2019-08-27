using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ProtoHub;

public class ProtoHubImpl : ProtoHubService.ProtoHubServiceBase
{
    public override async Task<UploadSpecResponse> UploadSpec(UploadSpecRequest request, Grpc.Core.ServerCallContext context)
    {
        Process cmd = new Process();
        cmd.StartInfo.FileName = "prototool";
        cmd.StartInfo.RedirectStandardOutput = true;
        cmd.StartInfo.Arguments = "files ../Protos";
        cmd.StartInfo.CreateNoWindow = true;
        cmd.StartInfo.UseShellExecute = false;

        cmd.Start();
        cmd.WaitForExit();
        Console.WriteLine(cmd.StandardOutput.ReadToEnd());

        return await Task.FromResult(new UploadSpecResponse {
            Status = new Status {
                Code = 1,
                Message = "Complete",
            },
        });
    }
}