using System;

namespace Video_Stitching
{
  class Program
  {
    static void Main(string[] args)
    {
      //var clips = new int[6][] { new int[] { 0, 2 }, new int[] { 4, 6 }, new int[] { 8, 10 }, new int[] { 1, 9 }, new int[] { 1, 5 }, new int[] { 5, 9 } };
      var clips = new int[2][] { new int[] { 0, 1 }, new int[] { 1, 2 } };
      int time = 5;
      Solution s = new Solution();
      var answer = s.VideoStitching(clips, time);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    // Time - O(NLOGN)
    // Space - O(1)
    public int VideoStitching(int[][] clips, int time)
    {
      // Step 1 - sort the clips with starting time
      // NlogN
      Array.Sort(clips, (a, b) => { return a[0] - b[0]; });

      // Step 2 - find the overlapped intervals and get the max it can reach after merging the overlapped intervals.

      // initialize the first max reach as 0, coz question had asked us to see we can have a clip of (0, time)
      int maxReach = 0;
      int clipsIndex = 0;
      int count = 0;
      while (maxReach < time)
      {
        // as we have sorted the clips based on start time
        // so for valid input we must always get new and greater currentMaxReach than maxReach at each loop
        // coz, in the while loop we are comparing for any interval its start should be less or equal to the previous max reach
        // in that case for that interval its end will be always greater than its start and also maxInterval
        // coz we take Max()
        // if at any interval our new currentMaxReach is still less than last maxReach, i.e we can not reach to the last time
        int currentMaxReach = 0;
        // if overlap is found
        // At worst case will loop through all n nos in clips array
        // O(N)
        while (clipsIndex < clips.Length && clips[clipsIndex][0] <= maxReach)
        {
          currentMaxReach = Math.Max(currentMaxReach, clips[clipsIndex][1]);
          clipsIndex++;
        }

        if (currentMaxReach <= maxReach) return -1;
        maxReach = currentMaxReach;
        count++;
      }

      return count;
    }
  }
}
