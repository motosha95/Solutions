
using UnityEngine;
using UnityEngine.UI;
namespace TroopsGenerator
{
    public class UIManagement : MonoBehaviour
    {
        [Header("UI In Scene Elements")]
        [SerializeField]
        Button GenerateBtn;
        [SerializeField]
        Button RandomizeResourcesBtn;
        [SerializeField]
        InputField ArmyCountInptFld;
        [Space]
        [SerializeField]
        Transform ResourcesContaier;
        [SerializeField]
        Transform ResultContaier;
        [Header("UI Prefabs Elements")]
        [SerializeField]
        GameObject ResourceElementPrefab;
        private TroopsGeneration _troopsGenerator;
        private ResourcesManagement _resourcesManager;
        // Start is called before the first frame update
        void Awake()
        {
            _troopsGenerator = FindObjectOfType<TroopsGeneration>();
            _resourcesManager = FindObjectOfType<ResourcesManagement>();
            GenerateBtn.onClick.AddListener(() => GenrateBtnClk());
            RandomizeResourcesBtn.onClick.AddListener(() => RandomizeResourcesBtnClk());

        }



        #region Private Methods

        void GenrateBtnClk()
        {
            // **************Note***********Note***************Note******************

            // The best practice is to use pooling instead of instatiation and destruction
            // but I used this method as it costs less time

            ClearUIElements(ResultContaier);

            int armyCount = 0;
            int.TryParse(ArmyCountInptFld.text, out armyCount);
            _troopsGenerator.GenerateTroops( armyCount);
        }
        void RandomizeResourcesBtnClk()
        {
            // **************Note***********Note***************Note******************

            // The best practice is to use pooling instead of instatiation and destruction
            // but I used this method as it costs less time
            ClearUIElements(ResourcesContaier);
            ClearUIElements(ResultContaier);

            _resourcesManager.GenerateResources();
            
        }
        /// <summary>
        /// Call this to clear out the determined container
        /// </summary>
        /// <param name="container"></param>
        void ClearUIElements(Transform container)
        {
            for(int i=0;i< container.childCount;i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Call this to instantiate the GUI element on resources container
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        public void InstantiateResourceUIElement(SoldierTypes type,int count)
        {
            Instantiate(ResourceElementPrefab, ResourcesContaier).GetComponent<ResourceUIController>().Initialize(type.ToString(),count);
        }
        /// <summary>
        /// Call this to instantiate the GUI element on results container
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        public void InstantiateResultUIElement(SoldierTypes type, int count)
        {
            Instantiate(ResourceElementPrefab, ResultContaier).GetComponent<ResourceUIController>().Initialize(type.ToString(), count);
        }
        #endregion
    }
}