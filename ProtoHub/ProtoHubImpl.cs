using System.Threading.Tasks;
using ProtoHub;

public class ProtoHubImpl : ProtoHubService.ProtoHubServiceBase
{
    public override Task<UploadSpecResponse> UploadSpec(UploadSpecRequest request, Grpc.Core.ServerCallContext context)
    {
        return Task.FromResult(new UploadSpecResponse {
            Status = new Status {
                Code = 1,
                Message = "Complete",
            },
        });
    }
}