public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        /* Anagram is nothing but using same letters getting different words made out of them 
        the solution i envision is first i will sort all the words -- done
        then i will check the hash of each of the string and save it in dictionay with position and hash value
        something like <position, hashvalue>
        then create one more dictionary with <hashvalue , list of lists>
        finally create a new list of list of strings and just loop and insert and return FKING HELL */

        // declaring return list
        IList<IList<string>> returnList = new List<IList<string>>();

        // creating a new dummy string array so as to not use the original array for return purpose
        string[] dummyArrayWithSameElements = new string[strs.Length];
        Array.Copy(strs, dummyArrayWithSameElements, strs.Length);
        // step 0 edge cases return
        if (strs.Length == 1) {
            return [[strs[0]]];
        }
        if (strs.Length == 0) {
            return [[""]];
        }
        // step 1 sort each string in the arrat of strings , so after this loop we have strs array of strings but each strin will be sorted
        for (int j = 0; j < dummyArrayWithSameElements.Length; j++) { 
            char[] charArray = dummyArrayWithSameElements[j].ToCharArray(); // Convert string to char array
            Array.Sort(charArray); // Sort the char array
            dummyArrayWithSameElements[j] = new string(charArray);
        }
        // step 2 create new dictionary with position as key and its hash value as value in that dictionary // i dont think this is required and is over much all i think i need is the hashvalue and not required to have the position with me lets see.
        Dictionary<int, int> positionHashDic = new  Dictionary<int, int>();
        int i = 0;
        foreach (var stringItem in dummyArrayWithSameElements) { 
            positionHashDic.Add(i,stringItem.GetHashCode()); 
            i++;
        }
        // step 3 create new dictionary with hasvalue as key and value of dict position as new list additionite
        Dictionary<int, List<string>> hashKeyListOfStringsDic = new  Dictionary<int, List<string>>();
        foreach (var positionHashValuePair in positionHashDic) { 
            if (!hashKeyListOfStringsDic.ContainsKey(positionHashValuePair.Value)) { 
                List<string> listOfStringsWithSameHashValue = [strs[positionHashValuePair.Key]]; // here basically we created new list with a string which is at key position in original array of strings
                hashKeyListOfStringsDic.Add(positionHashValuePair.Value,listOfStringsWithSameHashValue); 
                // this is fantastic logic if im right , the if else here 
                // what im doing is bacailly i know what is the hasvalue of sorted string and its position
                // so basically now i know which strings are anagram by hash value and what are their position int his dict positionHashDic
                // now using the same dict im creating a dictionary with hashvalue as key and strings with same hashvalue using the key which originally as the position
                // so the final dict will have something like <hashvalue, ["ana","naa"]> etc and just we hvae to copy these lists into return array after this step , maybe even can skip this step for optimization ? lets see.
            }
            // if will create new list in the value side 
            // else will add new element to the value side to the same key
            else {
                hashKeyListOfStringsDic[positionHashValuePair.Value].Add(strs[positionHashValuePair.Key]);
            }
        }
        // step 4 copy the lists to list of lists to return
        foreach (var hasListOfListKeyValuePair in hashKeyListOfStringsDic) { 
            returnList.Add(hasListOfListKeyValuePair.Value);
        }

        // thats fking it lets fkg g !
        return returnList;
    }
}
