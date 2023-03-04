using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonTech
{
    internal class G : MainInterface
    {
        //До 12 идет быстро, дальше долго.
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();

            var users = new Dictionary<int, int[]>();
            var pairs = new HashSet<(int UserId, int FriendId)>();

            int[] startVal = input[0].Split(' ').Select(x => Int32.Parse(x)).ToArray();
            int n = startVal[0]; //n - кол-во пользователей
            int m = startVal[1]; //m - кол-во пар друзей

            for (int i = 1; i < m+1; i++)
            {
                int[] pair = input[i].Split(' ').Select(x => Int32.Parse(x)).ToArray();

                pairs.Add((pair[0], pair[1]));
                pairs.Add((pair[1], pair[0]));
            }

            for (var userId = 1; userId <= n; userId++)
            {
                var friendIds = pairs.Where(it => Equals(it.UserId, userId)).Select(it => it.FriendId).ToArray();
                users.Add(userId, friendIds);
            }

            for (var userId = 1; userId <= n; userId++)
            {
                string result = "0";

                var friendIds = users.GetValueOrDefault(userId);
                if (friendIds?.Length > 0)
                {
                    var possibleFriendInfos = pairs.Where(it => !Equals(it.UserId, userId) && friendIds.Contains(it.FriendId))
                        .GroupBy(it => it.UserId).Select(it => new { FriendId = it.Key, PossibleFriendsCount = it.Count() })
                        .Where(it => !users.Any(u => Equals(u.Key, it.FriendId) && u.Value.Contains(userId))).ToArray();

                    if (possibleFriendInfos?.Length > 0)
                    {
                        var maxPossibleFriendsCount = possibleFriendInfos.Max(it => it.PossibleFriendsCount);

                        var possibleFriendIds = possibleFriendInfos
                            .Where(it => Equals(it.PossibleFriendsCount, maxPossibleFriendsCount))
                            .Select(it => it.FriendId).ToArray();

                        result = string.Join(' ', possibleFriendIds.OrderBy(it => it));
                    }
                }
                list.Add(result);
            }
            return list.ToArray();

        }
    }
}
