// This class was generated on Tue, 04 Sep 2018 13:47:44 PDT by version 0.1.0-dev+904328-dirty of Braintree SDK Generator
// RefundsGetRequest.cs
// @version 0.1.0-dev+904328-dirty
// @type request
// @data H4sIAAAAAAAC/+xcb3PbNtJ//3yKHfaZaTwjS64Tu61fnRM7je7q2Gc7N3Pj80gQuRJRgwALLCXrOvnuNwBIiX/E2k1k55rjC4+HuwCxu1j8sAuu8FvwniUYHAUap5mMTH+GFPSCEzSh5ilxJYOj4CpWCwMREuPCwFRpYODb92CyhOFJP+gFf89QLy+YZgkSahMc3dz2gnfIItR16lulkzrtglFcof0WXC9TK5khzeUs6AX/YJqzicCKxCMeBb3gb7jMqQ3hr2OEC7a8YGJ3hhI1I4xgeOLUoBhzRdzjIuZhDKTAxGpR6Gt1O9aaLb04e73gEll0LsUyOJoyYdASfs24xig4Ip1hL7jQKkVNHE1wJDMhPt76NmjIv8QSLcmkShr0tJW+l06gpr4Pq5mrwuVU6YRZxh8SPieUpV/PwpmSuGwKxRKVSaqItiI1BQwzrVGGS2AyAt8ud6cpl0yGnAkgzaRhoe3VA5OFMTADDCZMMBkiKA0pWyYoCaIMt6dfm5cVIo9CFWFFzzqnqe4NxRpxN4yZZiGhhuHV+e6r/e++XxvC9r19MYhUaAZcEs60m7dBxDWGNNBoaFA03rWNzWAHKGYEPEJJfMrRODcuGm3DXXsPWmXORFa1RkFpWsFxevniSvgsJpjg0b+yvb2XYSbcf/RPgvunYwnOFqidd+SqWU0Fv0MY//Xin2NvBKYRpCKgZcpDJsQSptr7DhN9/9JB8dbaGBBhyBMmVj02j3X9/qQ0lskmEZ/zCO0qIwUUq8wwGVFsNg83KDR8u4Ibb3yQWTJBDWq6EiQVLMQCXyse0gODCDdvCtob6wh/1G22AmSP8I1QIyMcEU9q66VCb/pJxAgdMNgWPeASboaSUEukKg88vN2+iIlSczQYkFLC9DnStK/0bBBTIgZ6Gr58+fLHbwy6yd096B/u9OEKQyUj4+ZyNROLmAssOQ6YUiuVVrxpIlR492umCMuzbEgrOfOU94oK7x6U6eARepYJpgHvU43GWK9LtbIOZWCW8chB3CQjiBQa59kaf8GQgAkBXM6Z4JEzxsrd6gJ9JiA+cv3XNl33+Cnbbv+ZxJVzxUOsxwoVclP844shWFBBvZtPUgR4bz2SucmwfYtl7NXiBpSOUPfhOE2RaWO9eKIodiqnbIn6W1Pe4SDmhpT2G6Jtg4mLsRzgrPqAxhD5HM2WzfUzl3dQ1rthOMHlnanYrKBUzXUsgVm5LJxpFG6yb94dX5+eH1+B61KgFUv5QM1RzzkuBt/EjFAxs+ua1BHqcPu7OcrQtShrtKY1XSDBiDO7u6CdyXV8mE0STis8R+MQij2TN8capxUNcsKGeEslqUBCIKZnSPDh8uc+XCtI2B3m0vu5sm7es80nXHpOghSrCBbcOS83cPPhcgjXmKS2x66HYMLoQRQ+PPh+b8f5QB/sJphqtMsptPAnZxbnQ5FFftDx/497MH4x7rn1MN4Zwyp2Mn0HoGOr6xi4D3rucAmFl1ldlbRxoVs8zqPsPpqbwOvo9WF2Ao2dOEmO/EwT57yp4X9l6u95YM8GwhFOucTIpl03l2/fwP7eq8P1FCwWi/UE6Glo/2yLPt3TTj9f6pM8YrQWyh3j2fS3PlVTPic1NX93fX1RuOFqr6YW530mDTSKivj+eUPk74zrBLQob6fvwYVy8OMPP6zClVc7RcRsUM/RuCRIFhsoyyfPOnomWTLhs0xlRiwhqkyxwYRJ4qGxuFzMuY2CEG4c+F/mEpqaDzHJnGzMGD6TNtsyA9t3t1Cp/ti/t2rsPMUGdRXGmLDmXJiCvp6OFWlTbrzGaZtEbtH719uOmthgbUOWHEXch5FDwqS6oTZ5VeG3a9FjIeB8CnaoDWIKcV7dWQpK+25vssmuN3uO0M7ASWYIXLTqAvcZ49L4ILbc/jO3+7pqcvk7qsllXbWcsh3VlHRHE4nySeITqdjmX25XcF5U9a0q/Sn9ql2yFGXkM+qaaBXGU8rWBuZTzWYW2i7RKJHlAfBawo3sL2FD3sAMvhEpjiVYxhNg8HYSA9diyyvizIZHLZFWM8p6KMa3UWeoJOE97aIMVcTlDNxSfoaTxgmXTC9P82ErwjdYm0J9SSibYvvN/iwTxNNMp8ogrE5VzhgXcHpPKI2FCHhxNjw73YELpgnOJR7ZeD1hZOdu3QeNYTOE1yriaB4Mavb3Xh3sPFNwRvXImh4Oqj/ZPtcLdQTO+8CK9ShLHG7HErePwAypqofy/vkp0etcYvv2qyTWtt+Csr3td91+yxjT5m8po/iKmK5aukyteZ4ClqZi6fNpLyq4Q2QEqwWTIZpv4cPl0PTA2Fc4ln0u5eHuOL3/PDtPalN8LUs9a5o2uF9if0xbxHtauW4fm6f4JOOqma3UGF3O0uUsXc7S5SxdztLlLF3O0uUsXc7S5SxdztLlLE+Us7QiEidRg6Sc0sQkn5BYdv+5xJOKcERq5Aoj6nBR4WzKp5jJ67xKJSh/jlqNM9RhzCTBBVtac8BrjewuUosNVRsGhUBtDWGJo0mpZelbWXujpuVW3OJD4nbKdx4sL51pZcxoQ5FpjdGVmnalpl2p6VdbatqCDhJpEzZUyB0ydMjQIcNXiwzvkeDYr+FVQNSSz61hoSUiamnQnu2toyLnXmYVWdpE3L+pD5dImZauzBxlZZVUYyngBiI+naK2sDLVKtnY2NdUAwtDp/QiRl0UbOYBYqxE5JYj1+B/07W1stoWHA6VnKMmjDah8QZmh8kdJneY/NVi8um9BaIZwiUj3FCDn7NH2rNLlfg1TtNlihZgW3jrR0ioEy5zd8/BgxTkwOOhVMkSyJACJhXFqD9tdXwSXhiV6RBHxYDVXLzB+xNixmccgrtP2ptN0+T9T5nmj+Bp/iOP9V6aRyCnv2Z8zgT6ZWFXQiY5FQGF9721XvkHFMLI7q8F3Cq9QiMngD/cte8iBd8dQMRnnExxMqwdmOcDrFBMcUlbPydsCUmKY60NAUmD1YUjXTjShSNfWTjyOIxImRhNEev4sCZ32NBhQ4cNX22qciEYTZVO4C1uyFTSnGuxoPadtsZpPyMqWvpFr0lah0A07te2CXd3AJie5U60ukPNZuj4v/9D+cPuIpcOBDsQ7EBwK1/XipPj18zgxjCpGSG1BEflO8Iqh9KLWK0qIxzHnUw7+JhmYsqF8OT8+ozrcl9ugAmj4E6qhbQgUhRbPAdqCI6S6heHlKlNI6TZRPBwva6987M0BX8Fjvv1ftk6A68MDCVpFWWh/527ydJUaYLMIITMoIEX9j3Yn/XhtWZcXmtEKDmNz8n9B4Kd/MuAe7OvVBmxKNJojKv5zkcecffdwa48NmdcWM2f6WSjIlP1GLDGaVqYu2pH5uGB/xsjryHkfT7/rp4PqZ2Bw1el+yccbDAh1MJOIE6V9rW3+wcHba3Y1O4Vdqb9GHb9+gH+kg+6poDhM9mHd2qBc9Q918tfnGPBkIUhptZzEnbPkywBgXJGsXcsWdXeTuj+wavG1Rl56RvMURe7jQVDCZl0RooeKyXgPTf0hW8gKnlwrWa6TG+7kyiv1RqeFNuZxRhImLnDyBrI3cy0+YtbDvfWBaXdPuwU2CVaVDvqyMV5HHOz1/sZ0OhGmIgloAz10k2sC6Qg1SrVHInpJcytwtIdo1lgfrlv+2bGg4MrmS6uwTCZ2NbB2iPSZlLExMiHpZs/+bW16OLILo7s4siv+KCt9dsXMcqqm/yK1PQPzyrgN2QpZXrbUcmVH+PEx6ttEo+iFb8ueYnVHgZXCzx8x6dHKF/mXLunKCe1FkUv4mVZ1jgPs8cXp+9Phu9/GlucHb89Hv58ejLekiaPrvnO0mjjjZJVenej5H/vjZK3H3vBG/9rr3yuWZoKHnqQ+sX75jui9MzfB3YU/HR6HfhboYOjYDDfH+SbvBnkN1UPfltdAP0x6AVXdzxdjX96n2JIGPlVbsExONrf2/v4f/8BAAD//w==
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Payments
{
    /// <summary>
    /// Shows details for a refund, by ID.
    /// </summary>
    public class RefundsGetRequest : HttpRequest
    {
        public RefundsGetRequest(string RefundId) : base("/v2/payments/refunds/{refund_id}?", HttpMethod.Get, typeof(Refund))
        {
            try {
                Path = Path.Replace("{refund_id}", Uri.EscapeDataString(Convert.ToString(RefundId) ));
            } catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
