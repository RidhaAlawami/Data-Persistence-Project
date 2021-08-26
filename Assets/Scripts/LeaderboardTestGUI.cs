using UnityEngine;

public class LeaderboardTestGUI : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        // Display high scores!
        for (int i = 0; i < GameManager.EntryCount; ++i)
        {
            var entry = GameManager.Instance.GetEntry(i);
            GUILayout.Label("Name: " + entry.name + ", Score: " + entry.score);
        }

        // Interface for reporting test scores.
        //GUILayout.Space(10);

        //_nameInput = GUILayout.TextField(_nameInput);
        //_scoreInput = GUILayout.TextField(_scoreInput);

        //if (GUILayout.Button("Record"))
        //{
        //    int score;
        //    int.TryParse(_scoreInput, out score);

        //    GameManager.Instance.Record(_nameInput, score);

        //    // Reset for next input.
        //    _nameInput = "";
        //    _scoreInput = "0";
        //}

        GUILayout.EndArea();
    }
}