public class Solution {
    public int FindJudge(int n, int[][] trust) {
        int[][] ff = new int[n][];
        
        int output = -1;
        for (int i = 0; i < ff.Length; i++)
        {
           ff[i] = new int[3]; 
           ff[i][0] = i+1;
            
        }
        
        
        for (int j = 0; j < trust.Length; j++)
        {
            int truster = trust[j][0];
            int trustee = trust[j][1];
            
            
            ff[truster-1][1] +=1;
            ff[trustee-1][2] +=1;
        }
        
        
        
         for (int k = 0; k < ff.Length; k++)
        {
           if(ff[k][1] == 0 && ff[k][2] == n-1)
           {
               output = ff[k][0];
           }
            
        }
        
        return output;
    }
}