using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scenario : MonoBehaviour
{
    public static Scenario S;
    public GameObject UiBase;
    public int scenarioCurNum;//현재 시나리오 번호
    public int scenarioMaxNum;//진행중인 시나리오 번호
    public GameObject nextButton;
    public GameObject preButton;
    public GameObject CompleteButton;
    public GameObject CompleteImage;
    public bool scenarioComplete;
    public GameObject scenarioCompleteImage;
    public bool ispause;
    public GameObject B_scenario;
    [SerializeField]
    private Scene_Changer scene_Changer;

    public Text T_scenarioName;
    public Text T_scenarioText;
    public Text T_scenarioHint;
    public Text T_scenarioGoal;
    public Text T_scenarioReward;



    //이지 시나리오 조건
    public int E_scenario8_createNum;
    public int E_scenario18_SellNum;
    public int scenario2_coal;
    public int scenario2_scrab;
    public int scenario2_compost;
    public bool scenario3_Check;
    public int scenario4_createNum;
    public int scenario6_sellNum;

    //노말 시나리오 조건
    public int N_scenario2_CreateNum;
    public int N_scenario3_SellNum;
    public int N_scenario6_CreateNum;
    public int N_scenario7_SellNum;

    //하드 시나리오 조건
    public int H_scenario1_SellNum;
    public int H_scenario3_month;
    public int H_scenario9_Sellnum;
    public int H_scenario12_month;
    public int H_scenario15_month;
    public int H_scenario17_FireNum;
    public int H_scenario18_month;


    // Start is called before the first frame update
    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        

        if(SaveNLoad.IsLoad==false)
        {
            scenarioCurNum = 1;
            scenarioMaxNum = 1;
            switch (DifficultManager.S.gameDifficult)
            {
                case DifficultManager.GameDifficult.none:
                    break;
                case DifficultManager.GameDifficult.easy:
                    E_MoveSenario(scenarioMaxNum);
                    UiOn();
                    break;
                case DifficultManager.GameDifficult.normal:
                    N_MoveSenario(scenarioMaxNum);
                    UiOn();
                    break;
                case DifficultManager.GameDifficult.hard:
                    H_MoveSenario(scenarioMaxNum);
                    UiOn();
                    break;
                case DifficultManager.GameDifficult.endless:
                    B_scenario.SetActive(false);
                    break;
                default:
                    break;
            }

        }
        if (DifficultManager.S.gameDifficult == DifficultManager.GameDifficult.endless)
        {
            B_scenario.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                ButtonOnHide();
                E_ScenarioCheak();
                break;
            case DifficultManager.GameDifficult.normal:
                ButtonOnHide();
                N_ScenarioCheak();
                break;
            case DifficultManager.GameDifficult.hard:
                ButtonOnHide();
                H_ScenarioCheak();
                break;
            case DifficultManager.GameDifficult.endless:
                break;
            default:
                break;
        }



    }
    public void E_MoveSenario(int _num)
    {
        scenarioCurNum = _num;
        switch (_num)
        {
            case 1:
                T_scenarioName.text = "1단계-기반 설비를 갖춰라";
                T_scenarioText.text = "슬라임 프로젝트에 오신것을 환영합니다!\n회사 운영의 기본인 슬라임 생산을 위한 기반 설비를 갖추십시오\n원자재저장고, 슬라임 농장을 각각 3개까지 건설하십시오\n모든 행동은 일시 정지 후 하는 것을 권장합니다";
                T_scenarioHint.text = "힌트:농장에서 톱니바퀴 버튼으로 업그레이드가 가능합니다";
                T_scenarioGoal.text = "목표:원자재 저장고(" + (FarmUpgrade.S.OpenSlimeFarmTier + 1).ToString() + "/3)슬라임 농장(" + (FarmUpgrade.S.OpenTrashStorageTier + 1).ToString() + "/3)";
                T_scenarioReward.text = "보상:10,000원";
                break;
            case 2:
                T_scenarioName.text = "2단계 - 슬라임을 양식하라.";
                T_scenarioText.text = "슬라임 농장에서 원자재를 소모하여\n 슬라임을 생산해 보십시오\n1티어 원자재를 각각 1개이상 사용하십시오";
                T_scenarioHint.text = "힌트:농장의 슬라임 농장을 선택하여 생산하세요";
                T_scenarioGoal.text = "목표:퇴비자루(" + scenario2_compost.ToString() + "/1) 고철자루(" + scenario2_scrab.ToString() + "/1)석탄자루(" + scenario2_coal.ToString() + "/1)";
                T_scenarioReward.text = "보상:★원자재 10개씩";
                break;
            case 3:
                T_scenarioName.text = "3단계 - 공장 노동자를 고용하라.";
                T_scenarioText.text = "생산공장을 가동하기 위해선 노동자가 필요합니다\n한 라인안의 생산, 포장 직원을 한명씩 고용하세요";
                T_scenarioHint.text = "힌트:공장에서 표지판을 선택하여 고용 가능합니다";
                T_scenarioGoal.text = "목표:공장 한 라인에 생산,포장 직원 1명씩 고용";
                T_scenarioReward.text = "보상:10,000원";
                break;
            case 4:
                T_scenarioName.text = "4단계 - 공장을 가동하라.";
                T_scenarioText.text = "공장 직원을 고용했으니 상품을 생산해야 합니다\n아무 상품이나 10개 생산하십시오";
                T_scenarioHint.text = "힌트:생산할 물품을 정하고 슬라임을 넣으면 자동으로 생산합니다";
                T_scenarioGoal.text = "목표:상품(" + scenario4_createNum.ToString() + "/10)";
                T_scenarioReward.text = "보상:★슬라임 10개씩";
                break;
            case 5:
                T_scenarioName.text = "5단계 - 가게 종업원을 고용하라.";
                T_scenarioText.text = "물건을 팔려면 상점 종업원이 필요합니다\n상점으로 이동하여 가판대 직원을 한명 고용하십시오";
                T_scenarioHint.text = "힌트:공장 직원과 동일합니다";
                T_scenarioGoal.text = "목표:가게 종업원 1명이상 고용";
                T_scenarioReward.text = "";
                break;
            case 6:
                T_scenarioName.text = "6단계 - 상품을 판매하라.";
                T_scenarioText.text = "종업원을 고용했으니 공장에서 생산한 물품을 판매해야 합니다\n아무 상품이나 10개 판매 하십시오";
                T_scenarioHint.text = "힌트:상품을 선택하고부터 손님이 오기 시작합니다";
                T_scenarioGoal.text = "목표:상품판매(" + scenario6_sellNum.ToString() + "/10)";
                T_scenarioReward.text = "보상:킹 슬라임 1개";
                break;
            case 7:
                T_scenarioName.text = "7단계 - 1분기를 생존하라.";
                T_scenarioText.text = "기본적인 부분을 모두 알아보았으니\n 스스로 1분기동안 운영해 보십시오";
                T_scenarioHint.text = "힌트:20일이 지나면 1분기가 지나갑니다";
                T_scenarioGoal.text = "목표:1분기 생존";
                T_scenarioReward.text = "보상:슬러시 슬라임 4개,얼음 상품 40개";
                break;
            case 8:
                T_scenarioName.text = "8단계 - 여름 상품을 만들어라.";
                T_scenarioText.text = "여름에는 푸른계통 관련 제품의 가격이 높습니다\n푸른 계통 상품을 25개 생산하십시오";
                T_scenarioHint.text = "힌트:상품과 슬라임의 계통이 같을시 원료를 더 얻을 수 있습니다";
                T_scenarioGoal.text = "목표:푸른계통 상품(" + E_scenario8_createNum.ToString() + "/25)";
                T_scenarioReward.text = "보상:★★★원자재 5개씩";
                break;
            case 9:
                T_scenarioName.text = "9단계 : 돈을 모아라.";
                T_scenarioText.text = "회사에는 여유 자금이 필요합니다\n자금을 10만원 이상 모으십시오";
                T_scenarioHint.text = "주의:돈이 없으면 파산 할 수 있습니다";
                T_scenarioGoal.text = "목표:자금(" + MoneyManager.S.CurrentMoney().ToString() + "원/100,000원)";
                T_scenarioReward.text = "보상:30,000원";
                break;
            case 10:
                T_scenarioName.text = "10단계 - 회사 기술에 혁신을 가져와라.";
                T_scenarioText.text = "많은 생산을 위해 더 좋은 원자재를 얻을 필요성이 있습니다\n 농장의 원자재 품질 강화를 업그레이드 하십시오";
                T_scenarioHint.text = "힌트:티어가 높은 원자재에서 더 좋은 슬라임이 등장합니다";
                T_scenarioGoal.text = "목표:농장 원자재 품질강화 1레벨";
                T_scenarioReward.text = "보상:30,000원";
                break;
            case 11:
                T_scenarioName.text = "11단계 : 1년을 생존하라.";
                T_scenarioText.text = "이제 회사를 안정적으로 운영하여 생존하여 보십시오\n게임 시작 기준 1년을 생존하여야합니다";
                T_scenarioHint.text = "힌트:생산과 판매의 균형을 잘 맞춰봅시다";
                T_scenarioGoal.text = "목표:게임시작 1년경과";
                T_scenarioReward.text = "보상:50,000원";
                break;
            case 12:
                T_scenarioName.text = "12단계 : 상품을 업그레이드하라.";
                T_scenarioText.text = "상품을 업그레이드 하면 생산에 드는 원료가 증가하지만\n판매가격이 많이 증가합니다\n공장의 고가치 상품 생산을 업그레이드 하십시오";
                T_scenarioHint.text = "힌트:남은 상품은 다음티어 상품으로 변환됩니다";
                T_scenarioGoal.text = "목표:공장 고가치 상품 생산 업그레이드 1레벨 도달";
                T_scenarioReward.text = "모든 상품 20개씩";
                break;
            case 13:
                T_scenarioName.text = "13단계 : 기초 생산을 다져라.";
                T_scenarioText.text = "더 많은 원자재와 슬라임을 생산해야합니다\n원자재 저장고와 슬라임 농장을 6개까지 건설하십시오";
                T_scenarioHint.text = "힌트:원자재 저장고가 많을수록 생산되는 원자재 양이 늘어납니다";
                T_scenarioGoal.text = "목표:원자재 저장고(" + (FarmUpgrade.S.OpenSlimeFarmTier + 1).ToString() + "/6)슬라임 농장(" + (FarmUpgrade.S.OpenTrashStorageTier + 1).ToString() + "/6)";
                T_scenarioReward.text = "보상:★★★원자재 5개씩";
                break;
            case 14:
                T_scenarioName.text = "14단계 - 각 부서별 기능을 활성화하라.";
                T_scenarioText.text = "회사의 각부서는 운영에 도움이 되는 기능을 활성화 가능합니다\n마케팅, 경영, 인사 3곳의 기능을 각각 1개 이상 활성화 하십시오";
                T_scenarioHint.text = "힌트:회사를 선택하고 각 기능을 살펴보세요";
                T_scenarioGoal.text = "목표:마케팅(" + Marketing.S.activeNum.ToString() + "/1)경영(" + Management.S.activeNum.ToString() + "/1)인사" + HRDepartment.S.activeNum.ToString() + "/1)";
                T_scenarioReward.text = "보상:35,000원";
                break;
            case 15:
                T_scenarioName.text = "15단계 : 모든 유통 라인을 가동하라.";
                T_scenarioText.text = "모든 유통 라인을 가동하여 이익을 창출해야 합니다\n공장, 상점의 가능한 모든 직원을 고용하십시오";
                T_scenarioHint.text = "힌트:상점의 손님의 총 방문 수는 직원이 늘어나도 동일합니다";
                T_scenarioGoal.text = "목표:고용가능한 모든 공장, 상점 직원 고용 ";
                T_scenarioReward.text = "보상:★★★슬라임 5개씩";
                break;
            case 16:
                T_scenarioName.text = "16단계 - 유지비를 덜어라.";
                T_scenarioText.text = "유지비는 적지만 꾸준한 지출입니다\n회사 운영이 길어짐에따라 유지비를 줄일 필요가 있습니다\n농장,공장,가게의 유지비절감을 모두 1레벨이상 도달하십시오";
                T_scenarioHint.text = "힌트:티끌모아 태산입니다";
                T_scenarioGoal.text = "목표:원자재(" + FarmUpgrade.S.TrashStorageCostCuttingTier + "/1)농장(" + FarmUpgrade.S.SlimeFarmCostCuttingTier + "/1)생산라인(" + FactoryUpgrade.S.LineCostCuttingTier.ToString() + "/1)포장(" + FactoryUpgrade.S.PackageCostCuttingTier.ToString() + "/1)가게(" + ShopUpgrade.S.SellLineCostCuttingTier + "/1)";
                T_scenarioReward.text = "보상:★★★★슬라임 각각 5개";
                break;
            case 17:
                T_scenarioName.text = "17단계 - 회사 부서전략을 강화하라";
                T_scenarioText.text = "회사의 각 부서를 업그레이드하여 \n더 좋은 기능을 사용할 수 있습니다\n마케팅, 경영, 인사 중 하나의 부서를 1회이상 업그레이드 하십시오";
                T_scenarioHint.text = "힌트:부서 기능은 회사 운영에 큰 영향을 미칩니다.";
                T_scenarioGoal.text = "목표:회사의 아무 부서 업그레이드 1회이상";
                T_scenarioReward.text = "보상:10,000원";
                break;
            case 18:
                T_scenarioName.text = "18단계 - 본격적인 판매를 개시하라.";
                T_scenarioText.text = "상품의 판매를 멈추지 마십시오\n종류에 상관없이 상품을 1000개 이상 판매하십시오";
                T_scenarioHint.text = "힌트:분기마다 비싼상품을 확인하여 판매합시다";
                T_scenarioGoal.text = "목표:상품판매("+E_scenario18_SellNum+"/1000)";
                T_scenarioReward.text = "보상:★★★★★슬라임 5개씩";
                break;
            case 19:
                T_scenarioName.text = "19단계 - 회사의 품격을 향상시켜라.";
                T_scenarioText.text = "원자재와 상품을 고급화 할 필요가 있습니다\n원자재, 상품의 고급화를 2회이상 업그레이드 하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:원자재 업그레이드 2레벨 이상,상품 업그레이드 2레벨 이상";
                T_scenarioReward.text = "보상:50,000원";
                break;
            case 20:
                T_scenarioName.text = "20단계 - 회사를 오랜 기간 유지하라.";
                T_scenarioText.text = "생산과 판매의 균형 적절한 부서활용이\n회사 장기운영의 지름길입니다\n회사를 5년동안 유지하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:게임 시작 기준 5년 경과";
                T_scenarioReward.text = "보상:게임 클리어";
                break;
            default:
                break;
        }
    }
    public void N_MoveSenario(int _num)
    {
        scenarioCurNum = _num;
        switch (_num)
        {
            case 1:
                T_scenarioName.text = "1단계-기반 설비를 갖춰라";
                T_scenarioText.text = "슬라임 프로젝트에 오신것을 환영합니다!\n회사 운영의 기본인 슬라임 생산을 위한 기반 설비를 갖추십시오\n원자재저장고, 슬라임 농장을 각각 4개까지 건설하십시오\n모든 행동은 일시 정지 후 하는 것을 권장합니다";
                T_scenarioHint.text = "힌트:농장에서 톱니바퀴 버튼으로 업그레이드가 가능합니다.";
                T_scenarioGoal.text = "목표:원자재 저장고(" + (FarmUpgrade.S.OpenSlimeFarmTier + 1).ToString() + "/4), 슬라임 농장(" + (FarmUpgrade.S.OpenTrashStorageTier + 1).ToString() + "/4)";
                T_scenarioReward.text = "보상:7,500원";
                break;
            case 2:
                T_scenarioName.text = "2단계 - 상품을 생산 포장하라.";
                T_scenarioText.text = "상품을 팔기위해서는 슬라임으로 상품을 생산해야합니다\n공장 직원을 고용하고 상품을 생산하십시오\n아무상품이나 100개 이상 생산 하십시오";
                T_scenarioHint.text = "힌트:포장까지 완료되어야 생산이 완료됩니다.";
                T_scenarioGoal.text = "목표: 상품 생산(" +N_scenario2_CreateNum.ToString()+ "/100)";
                T_scenarioReward.text = "보상:12,500원";
                break;
            case 3:
                T_scenarioName.text = "3단계 - 상품을 판매하라.";
                T_scenarioText.text = "공장에서 생산한 물품을 판매해야 합니다\n아무 상품이나 100개 이상 판매 하십시오";
                T_scenarioHint.text = "힌트: 판매 라인의 수와 상관없이 시간당 오는 총 손님의 수는 같습니다.";
                T_scenarioGoal.text = "목표: 상품 판매(" +N_scenario3_SellNum+"/100)";
                T_scenarioReward.text = "보상:12,500원";
                break;
            case 4:
                T_scenarioName.text = "4단계 - 회사 가치를 높혀라Ⅰ.";
                T_scenarioText.text = "회사 가치는 회사의 모든 것을 가치로 환산한 수치입니다\n회사 가치를 일정 수준이상 높이십시오\n회사 가치를 10000이상 달성하십시오";
                T_scenarioHint.text = "힌트:지난 회사가치는 기록소에서 확인 가능합니다.";
                T_scenarioGoal.text = "목표:회사 가치(" + CompanyValue.S.allValue.ToString("n0") +"/10000)";
                T_scenarioReward.text = "보상:★★★슬라임 10개씩";
                break;
            case 5:
                T_scenarioName.text = "5단계 - 공장을 완전히 가동하라.";
                T_scenarioText.text = "여러 계절 상품을 미리 생산하기 위해서는\n공장의 직원이 많이 필요합니다\n공장 시설의 모든 직원을 고용하십시오";
                T_scenarioHint.text = "힌트:직원의 유지비는 고용일을 기준으로 1년후 증가합니다";
                T_scenarioGoal.text = "목표:모든 공장 직원 고용";
                T_scenarioReward.text = "보상:회사 평판 +150";
                break;
            case 6:
                T_scenarioName.text = "6단계 - 상품을 생산 포장하라.";
                T_scenarioText.text = "더 많은 상품을 팔기 위해서는 더 많이 생산해야합니다 \n더 많은 상품을 생산하십시오\n아무상품이나 300개 이상 생산 하십시오";
                T_scenarioHint.text = "힌트:포장까지 완료되어야 생산이 완료됩니다.";
                T_scenarioGoal.text = "목표: 상품 생산(" +N_scenario6_CreateNum.ToString()+ "/300)";
                T_scenarioReward.text = "보상:15,000원";
                break;
            case 7:
                T_scenarioName.text = "7단계 - 상품을 300개 판매하라.";
                T_scenarioText.text = "돈을 벌기 위해서는 결국 상품을 판매해야 합니다.\n아무상품이나 300개 이상 판매하십시오";
                T_scenarioHint.text = "힌트:손님을 더 많이 오게 하려면 회사 평판을 높여야합니다";
                T_scenarioGoal.text = "목표:상품 판매(" + N_scenario7_SellNum.ToString()+"/300)";
                T_scenarioReward.text = "보상:15,000원";
                break;
            case 8:
                T_scenarioName.text = "8단계 - 회사 기술력을 높혀라Ⅰ.";
                T_scenarioText.text = "상품을 팔기 위해서는 끝없는 연구와 개발이 필요합니다.\n 농장의 원자재 품질,쌍둥이 슬라임\n공장의 상품 품질을 업그레이드 하십시오";
                T_scenarioHint.text = "힌트:과도한 업그레이드는 환경 단체의 반발을 일으킵니다.";
                T_scenarioGoal.text = "목표:원자재 품질 업그레이드 1레벨, 쌍둥이 슬라임 1레벨";
                T_scenarioReward.text = "보상:킹 슬라임 10개";
                break;
            case 9:
                T_scenarioName.text = "9단계 - 회사 가치를 높혀라Ⅱ.";
                T_scenarioText.text = "회사를 더욱 발전시켜야 합니다.\n회사 가치를 20000이상 달성하십시오";
                T_scenarioHint.text = "힌트:생산에 사용중인 슬라임, 원자재는 회사가치에 포함되지 않습니다.";
                T_scenarioGoal.text = "목표:회사 가치(" + CompanyValue.S.allValue.ToString("n0") +" / 10,000)";
                T_scenarioReward.text = "보상:★★★★슬라임 10개씩";
                break;
            case 10:
                T_scenarioName.text = "10단계 - 부서 기능을 개선하라.";
                T_scenarioText.text = "각 부서의 정책들은 작아보이지만\n장기적으로는 엄청난효과를줍니다\n각 부서의 레벨을 2이상 달성하십시오.";
                T_scenarioHint.text = "힌트:부서 레벨을 올릴수록 더 좋은 정책이 해금됩니다.";
                T_scenarioGoal.text = "목표:경영,마케팅,인사 부서 레벨 2달성";
                T_scenarioReward.text = "보상:20,000원";
                break;
            case 11:
                T_scenarioName.text = "11단계 - 각 기관들의 불만도를 관리하라.";
                T_scenarioText.text = "살아남기 위해서는 기관들의 불만도를 낮춰야합니다.\n불만도가 높은 기관은 우리를 방해하려 할 것입니다.\n적어도 4개 이상 기관의 불만도를 90이하로 낮추십시오. ";
                T_scenarioHint.text = "힌트:회사 각 부서의 기능을 적절히 사용하십시오.";
                T_scenarioGoal.text = "목표:감사원("+GeneralMeeting.S.governmentDI+"/90"+ "소비자("+GeneralMeeting.S.consumerGroupDI+" / 90"+"환경(" + GeneralMeeting.S.environmentalGroupDI + "/90"+ "노동자("+GeneralMeeting.S.laborUnionDI+" / 90"+"식약청(" + GeneralMeeting.S.FDADI + "/90"+ "동물("+GeneralMeeting.S.AnimalProtectionGroupDI+" / 90";
                T_scenarioReward.text = "보상:30,000원";
                break;
            case 12:
                T_scenarioName.text = "12단계 : 회사 기술력을 높혀라Ⅱ";
                T_scenarioText.text = "상품의 생산량과 품질을 늘리기위해서 \n더 높은 수준의 개발이 필요합니다\n농장의 원자재 품질,쌍둥이 슬라임\n공장의 상품 품질을 업그레이드 하십시오.";
                T_scenarioHint.text = "힌트:생산과 판매의 균형을 잘 맞춰봅시다";
                T_scenarioGoal.text = "목표:원자재 품질 업그레이드 2레벨, 쌍둥이 슬라임 2레벨";
                T_scenarioReward.text = "보상:상품 가격 10% 영구 증가";
                break;
            case 13:
                T_scenarioName.text = "13단계 : 5년을 운영하라.";
                T_scenarioText.text = "생산과 판매의 균형 적절한 부서활용이\n회사 장기운영의 지름길입니다\n회사를 5년동안 유지하십시오";
                T_scenarioHint.text = "남은 상품은 다음티어 상품으로 환산됩니다";
                T_scenarioGoal.text = "목표:고가치 상품 생산 업그레이드 1레벨 도달";
                T_scenarioReward.text = "보상:15,000원";
                break;
            case 14:
                T_scenarioName.text = "14단계 : 상품의 모든 공정 과정을 열어라.";
                T_scenarioText.text = "상품 생산을 위해 모든 전력을 다해야합니다.\n농장의 모든 건물을 건설하고\n 공장과 가게의 모든 직원을 고용하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:원자재 저장고,슬라임 농장 모두 건설, 모든 직원 고용";
                T_scenarioReward.text = "보상:20,000원";
                break;
            case 15:
                T_scenarioName.text = "15단계 : 회사 가치를 높혀라Ⅲ.";
                T_scenarioText.text = "회사는 끝없이 성장해야합니다.\n회사 가치를 30000이상 달성하십시오.";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:원자재 품질, 상품 품질, 쌍둥이슬라임 3레벨 이상";
                T_scenarioReward.text = "보상:★★★★★슬라임 10개씩";
                break;
            case 16:
                T_scenarioName.text = "16단계 : 회사 기술력을 높혀라Ⅲ.";
                T_scenarioText.text = "연구가 거듭 될 수록 얻는 이익은 늘어납니다.\n농장의 원자재 품질,쌍둥이 슬라임 업그레이드와\n공장의 상품 품질을 업그레이드 하십시오.";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:원자재 품질,상품 품질,쌍둥이슬라임 3레벨 이상";
                T_scenarioReward.text = "보상:모든기관 불만 -25";
                break;
            case 17:
                T_scenarioName.text = "17단계 : 가게 선전을 실시하라.";
                T_scenarioText.text = "상품을 생산해도 손님이 오지 않으면\n쓰레기와 다름이없습니다 \n회사 평판을 높여 더 많은 손님을 끌어모으십시오\n평판을 850이상 달성하십시오";
                T_scenarioHint.text = "힌트:평판은 최대치가 존재합니다.";
                T_scenarioGoal.text = "목표:회사 평판("+Shop.S.fame.ToString()+"/850)";
                T_scenarioReward.text = "보상:25,000원";
                break;
            case 18:
                T_scenarioName.text = "18단계 - 정책의 달인이 되어라.";
                T_scenarioText.text = "각 부서의 정책들은 분기마다 많은 효과를줍니다\n이 기능을 잘 활용해야합니다.\n부서와 상관없이 정책을 15개이상 유지하십시오.";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:활성화된 부서 정책 15개 이상";
                T_scenarioReward.text = "보상:50,000원";
                break;
            case 19:
                T_scenarioName.text = "19단계 - 회사 기술력을 높혀라Ⅳ.";
                T_scenarioText.text = "그동안의 연구로 기술의 끝을 바라보고있습니다.\n농장의 원자재 품질, 쌍둥이슬라임\n공장의 상품 품질 업그레이드를 마치십시오.";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:원자재 품질, 쌍둥이슬라임, 상품 품질 업그레이드 최대레벨";
                T_scenarioReward.text = "보상:상품 가격 20% 영구증가";
                break;
            case 20:
                T_scenarioName.text = "20단계 - 백만장자가 되어라.";
                T_scenarioText.text = "회사 운영의 끝을 바라보고 있습니다.\n백만장자를 향해 나아가야합니다.\n돈을 1,000,000원이상 모으십시오.";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:보유금액("+MoneyManager.S.CurrentMoney().ToString("n0")+"/1,000,000)";
                T_scenarioReward.text = "보상:게임 클리어";
                break;
            
            default:
                break;
        }
    }
    public void H_MoveSenario(int _num)
    {
        scenarioCurNum = _num;
        switch (_num)
        {
            case 1:
                T_scenarioName.text = "1단계 - 상품을 200개 판매하라.";
                T_scenarioText.text = "상품을 200개 판매하세요";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표: 상품 판매(" + N_scenario2_CreateNum.ToString() + "/200)";
                T_scenarioReward.text = "보상:10,000원";
                break;
            case 2:
                T_scenarioName.text = "2단계 - 원자재 및 상품 티어를 Ⅱ까지 높혀라.";
                T_scenarioText.text = "원자재 품질과 상품 티어 업그레이드 하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표: 원자재 품질과 상품 티어 1 이상";
                T_scenarioReward.text = "보상:25,000원";
                break;
            case 3:
                T_scenarioName.text = "3단계 - 1년을 운영하라.";
                T_scenarioText.text = "1년동안 살아남으십시오";
                T_scenarioHint.text = "힌트: 퀘스트 시작 후 1년이 경과해야 합니다";
                T_scenarioGoal.text = "목표: 운영 1년 경과";
                T_scenarioReward.text = "보상:모든 상품 단가 +10%";
                break;
            case 4:
                T_scenarioName.text = "4단계 - 농장을 효율적으로 운영하라";
                T_scenarioText.text = "농장의 유지비를 줄이십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:농장의 모든 유지비 업그레이드 3레벨 이상";
                T_scenarioReward.text = "보상:★★★★★ 원자재 각각 5개";
                break;
            case 5:
                T_scenarioName.text = "5단계 - 공장을 효율적으로 운영하라.";
                T_scenarioText.text = "공장의 효율을 높여 유지비를 줄이십시오";
                T_scenarioHint.text = "힌트:";
                T_scenarioGoal.text = "목표:공장의 모든 유지비 업그레이드 3레벨 이상";
                T_scenarioReward.text = "보상:킹 슬라임 8개";
                break;
            case 6:
                T_scenarioName.text = "6단계 - 모든 기관에게 비난을 받지 마라.";
                T_scenarioText.text = "살아남기 위해서는 모든 기관의 불만을 관리해야합니다\n분기가 시작될 시점에 모든 기관의 불만도를 100이하로 낮추십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:감사원(" + GeneralMeeting.S.governmentDI + "/ 100" + "소비자(" + GeneralMeeting.S.consumerGroupDI + " / 100" + "환경(" + GeneralMeeting.S.environmentalGroupDI + "/ 100" + "노동자(" + GeneralMeeting.S.laborUnionDI + " / 100" + "식약청(" + GeneralMeeting.S.FDADI + "/ 100" + "동물(" + GeneralMeeting.S.AnimalProtectionGroupDI + " / 100";
                T_scenarioReward.text = "보상:30,000원";
                break;
            case 7:
                T_scenarioName.text = "7단계 - 농장 확장을 완료하라.";
                T_scenarioText.text = "농장의 모든 원자재 저장고와 슬라임농장을 구입하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:원자재 저장고, 슬라임 농장 10개";
                T_scenarioReward.text = "보상:모든 상품 단가 +10%";
                break;
            case 8:
                T_scenarioName.text = "8단계 - 회사 가치를 높혀라.";
                T_scenarioText.text = "회사가치를 25,000 이상으로 높이십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:회사의 가치가 25,000 이상.";
                T_scenarioReward.text = "보상:회사 평판 + 500, 모든 종업원 호감도 +50";
                break;
            case 9:
                T_scenarioName.text = "9단계 - 상품을 더욱 많이 판매하라.";
                T_scenarioText.text = "상품을 600개 이상 판매하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:상품 판매 ("+"/600)";
                T_scenarioReward.text = "보상:★★★★★슬라임 10개씩";
                break;
            case 10:
                T_scenarioName.text = "10단계 - 쌍둥이의 힘을 보여줘라.";
                T_scenarioText.text = "쌍둥이슬라임을 업그레이드하면 슬라임 생산량이 대폭 증가합니다";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:쌍둥이 슬라임 업그레이드 끝내기";
                T_scenarioReward.text = "보상:50,000원";
                break;
            case 11:
                T_scenarioName.text = "11단계 - 모든 기관에게서 호평을 얻어라.";
                T_scenarioText.text = "살아남기 위해서는 기관들의 불만도를 낮춰야합니다.\n불만도가 높은 기관은 우리를 방해하려 할 것입니다.\n적어도 4개 이상 기관의 불만도를 90이하로 낮추십시오. ";
                T_scenarioHint.text = "힌트:회사 각 부서의 기능을 적절히 사용하십시오.";
                T_scenarioGoal.text = "목표:감사원(" + GeneralMeeting.S.governmentDI + "/ 80" + "소비자(" + GeneralMeeting.S.consumerGroupDI + " / 80" + "환경(" + GeneralMeeting.S.environmentalGroupDI + "/ 80" + "노동자(" + GeneralMeeting.S.laborUnionDI + " / 80" + "식약청(" + GeneralMeeting.S.FDADI + "/ 80" + "동물(" + GeneralMeeting.S.AnimalProtectionGroupDI + " / 80)";
                T_scenarioReward.text = "보상:위법스택 초기화";
                break;
            case 12:
                T_scenarioName.text = "12단계 - 또 다시 1년을 운영하라.";
                T_scenarioText.text = "1년을 생존하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:퀘스트 시작 후 1년경과";
                T_scenarioReward.text = "보상:모든 상품 단가 +10%";
                break;
            case 13:
                T_scenarioName.text = "13단계 - 가게 평판을 최고로 만들어라.";
                T_scenarioText.text = "가게 평판을 최대치로 끌어올리십시오";
                T_scenarioHint.text = "남은 상품은 다음티어 상품으로 환산됩니다";
                T_scenarioGoal.text = "목표:가게 평판 ("+Shop.S.fame+"/1000)";
                T_scenarioReward.text = "보상:25,000원";
                break;
            case 14:
                T_scenarioName.text = "14단계 - 모든 시설의 효율을 최고로 만들어라.";
                T_scenarioText.text = "모든 유지비 관련 업그레이드를 끝내십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:모든 유지비 관련 업그레이드 완료";
                T_scenarioReward.text = "보상:40,000원";
                break;
            case 15:
                T_scenarioName.text = "15단계 - 회사를 대기업으로 만들어라.";
                T_scenarioText.text = "회사 부서 기능중 마지막 활성효과를 1년동안 유지하십시오";
                T_scenarioHint.text = "힌트: 중간에 해제시 처음부터 시작합니다 ";
                T_scenarioGoal.text = "목표:유지분기("+"/4)";
                T_scenarioReward.text = "보상:모든 상품 단가 +10%";
                break;
            case 16:
                T_scenarioName.text = "16단계 - 품질의 선구자가 되어라.";
                T_scenarioText.text = "원자재 품질, 상품티어 업그레이드를 끝내십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:원자재 품질,상품 품질 업그레이드 완료";
                T_scenarioReward.text = "보상:40,000원.";
                break;
            case 17:
                T_scenarioName.text = "17단계 - 파업이 뭔지 알아라.";
                T_scenarioText.text = "직원을 9명이상 해고하십시오";
                T_scenarioHint.text = "힌트:평판은 최대치가 존재합니다.";
                T_scenarioGoal.text = "목표:직원해고("+"/9)";
                T_scenarioReward.text = "보상:25,000원";
                break;
            case 18:
                T_scenarioName.text = "18단계 - 위기 속에서 다시 한 번 일어나라.";
                T_scenarioText.text = "17단계 이후 흑자를 1년동안 유지하십시오";
                T_scenarioHint.text = "힌트: 적자 발생시 다시 시작합니다";
                T_scenarioGoal.text = "목표:활성화된 부서 정책 15개 이상";
                T_scenarioReward.text = "보상:100,000원";
                break;
            case 19:
                T_scenarioName.text = "19단계 - 모든 기관에서 인정을 받아라.";
                T_scenarioText.text = "모든 기관의 불만도를 60이하로 낮추십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:감사원(" + GeneralMeeting.S.governmentDI + "/ 60" + "소비자(" + GeneralMeeting.S.consumerGroupDI + " / 60" + "환경(" + GeneralMeeting.S.environmentalGroupDI + "/ 60" + "노동자(" + GeneralMeeting.S.laborUnionDI + " / 60" + "식약청(" + GeneralMeeting.S.FDADI + "/ 60" + "동물(" + GeneralMeeting.S.AnimalProtectionGroupDI + " / 60)";
                T_scenarioReward.text = "보상:모든 상품 단가 +10%";
                break;
            case 20:
                T_scenarioName.text = "20단계 - 세계 제일가는 회사가 되어라.";
                T_scenarioText.text = "회사 운영의 끝을 바라보고 있습니다.\n회사가치를 250,000이상 달성하십시오";
                T_scenarioHint.text = "";
                T_scenarioGoal.text = "목표:회사 가치(" + CompanyValue.S.allValue.ToString("n0") + "/250,000)";
                T_scenarioReward.text = "보상:게임 클리어";
                break;

            default:
                break;
        }
    }

    public void NextSenario()//다음 시나리오
    {
        scenarioCurNum += 1;
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                E_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.normal:
                N_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.hard:
                H_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.endless:
                break;
            default:
                break;
        }

    }
    public void TestNextSenario()//다음 시나리오
    {
        scenarioCurNum += 1;
        scenarioMaxNum += 1;
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                E_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.normal:
                N_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.hard:
                H_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.endless:
                break;
            default:
                break;
        }
    }
    public void PreSenario()// 이전 시나리오
    {
        scenarioCurNum -= 1;
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                E_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.normal:
                N_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.hard:
                H_MoveSenario(scenarioCurNum);
                break;
            case DifficultManager.GameDifficult.endless:
                break;
            default:
                break;
        }
    }
    public void ButtonOnHide()
    {
        if (scenarioCurNum == scenarioMaxNum)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }

        if (scenarioCurNum == 1)
        {
            preButton.SetActive(false);
        }
        else
        {
            preButton.SetActive(true);
        }
        if (scenarioComplete && scenarioCurNum == scenarioMaxNum)
        {
            CompleteButton.SetActive(true);
        }
        else
        {
            CompleteButton.SetActive(false);
        }
        if(scenarioComplete)
        {
            scenarioCompleteImage.SetActive(true);
        }
        else
        {
            scenarioCompleteImage.SetActive(false);
        }
        if(scenarioMaxNum!=scenarioCurNum)
        {
            CompleteImage.SetActive(true);
            
        }
        else
        {
            CompleteImage.SetActive(false);
            
        }
    }
    public void ScenarioComPlete()
    {
        SoundManager.S.PlaySE("시나리오 클리어");
        if (DifficultManager.S.gameDifficult!=DifficultManager.GameDifficult.easy)
        {
            switch (scenarioMaxNum)
            {
                case 1:
                    MoneyManager.S.GetMoney(7500);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 2:
                    MoneyManager.S.GetMoney(12500);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 3:
                    MoneyManager.S.GetMoney(12500);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 4:
                    AddItem.S.SearchItem("부쉬 슬라임", 10);
                    AddItem.S.SearchItem("슬러시 슬라임", 10);
                    AddItem.S.SearchItem("젬 슬라임", 10);
                    AddItem.S.SearchItem("라바 슬라임", 10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 5:
                    Shop.S.VariationFame(150);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 6:
                    MoneyManager.S.GetMoney(15000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 7:
                    MoneyManager.S.GetMoney(15000);
                    ProductManager.S.GetIce(40);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 8:
                    AddItem.S.SearchItem("킹 슬라임", 10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 9:
                    AddItem.S.SearchItem("베놈 슬라임", 10);
                    AddItem.S.SearchItem("윈터 슬라임", 10);
                    AddItem.S.SearchItem("스타 슬라임", 10);
                    AddItem.S.SearchItem("마그네틱 슬라임", 10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 10:
                    MoneyManager.S.GetMoney(20000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 11:
                    MoneyManager.S.GetMoney(30000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 12:
                    ProductManager.S.ChangeAllPrice(10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 13:
                    MoneyManager.S.GetMoney(15000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 14:
                    MoneyManager.S.GetMoney(20000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 15:
                    AddItem.S.SearchItem("썬 슬라임", 5);
                    AddItem.S.SearchItem("어스 슬라임", 5);
                    AddItem.S.SearchItem("정글 슬라임", 5);
                    AddItem.S.SearchItem("툰트라 슬라임", 5);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 16:
                    GeneralMeeting.S.GovernmentDIVariation(-25);
                    GeneralMeeting.S.ConsumerGroupDIVariation(-25);
                    GeneralMeeting.S.EnvironmentalGroupDIVariation(-25);
                    GeneralMeeting.S.LaborUnionDIVariation(-25);
                    GeneralMeeting.S.FDADIVariation(-25);
                    GeneralMeeting.S.AnimalProtectionGroupDIVariation(-25);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 17:
                    MoneyManager.S.GetMoney(25000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 18:
                    MoneyManager.S.GetMoney(50000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 19:
                    ProductManager.S.ChangeAllPrice(20);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 20:
                    scene_Changer.GoEnding();
                    break;
                default:
                    break;
            }
        }
        else if(DifficultManager.S.gameDifficult != DifficultManager.GameDifficult.normal)
        {
            switch (scenarioMaxNum)
            {
                case 1:
                    MoneyManager.S.GetMoney(10000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 2:
                    AddItem.S.SearchItem("고철 자루", 10);
                    AddItem.S.SearchItem("퇴비 자루", 10);
                    AddItem.S.SearchItem("석탄 자루", 10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 3:
                    MoneyManager.S.GetMoney(10000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 4:
                    AddItem.S.SearchItem("그린 슬라임", 10);
                    AddItem.S.SearchItem("레드 슬라임", 10);
                    AddItem.S.SearchItem("옐로우 슬라임", 10);
                    AddItem.S.SearchItem("블루 슬라임", 10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 5:
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 6:
                    AddItem.S.SearchItem("킹 슬라임");
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 7:
                    AddItem.S.SearchItem("슬러시 슬라임", 4);
                    ProductManager.S.GetIce(40);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 8:
                    AddItem.S.SearchItem("비료 상자", 5);
                    AddItem.S.SearchItem("부품 상자", 5);
                    AddItem.S.SearchItem("화합물 상자", 5);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 9:
                    MoneyManager.S.GetMoney(30000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 10:
                    MoneyManager.S.GetMoney(30000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 11:
                    MoneyManager.S.GetMoney(50000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 12:
                    ProductManager.S.GetDrugs(20);
                    ProductManager.S.GetIce(20);
                    ProductManager.S.GetGlass(20);
                    ProductManager.S.GetFuel(20);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 13:
                    AddItem.S.SearchItem("톱밥 상자", 20);
                    AddItem.S.SearchItem("재활용품 상자", 20);
                    AddItem.S.SearchItem("연료 상자", 20);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 14:
                    MoneyManager.S.GetMoney(35000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 15:
                    AddItem.S.SearchItem("라바 슬라임", 5);
                    AddItem.S.SearchItem("부쉬 슬라임", 5);
                    AddItem.S.SearchItem("슬러시 슬라임", 5);
                    AddItem.S.SearchItem("젬 슬라임", 5);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 16:
                    AddItem.S.SearchItem("마그네틱 슬라임", 5);
                    AddItem.S.SearchItem("베놈 슬라임", 5);
                    AddItem.S.SearchItem("스타 슬라임", 5);
                    AddItem.S.SearchItem("윈터 슬라임", 5);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 17:
                    MoneyManager.S.GetMoney(10000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 18:
                    AddItem.S.SearchItem("썬 슬라임", 5);
                    AddItem.S.SearchItem("어스 슬라임", 5);
                    AddItem.S.SearchItem("정글 슬라임", 5);
                    AddItem.S.SearchItem("툰트라 슬라임", 5);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 19:
                    MoneyManager.S.GetMoney(50000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 20:
                    scene_Changer.GoEnding();
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (scenarioMaxNum)
            {
                case 1:
                    MoneyManager.S.GetMoney(10000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 2:
                    MoneyManager.S.GetMoney(25000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 3:
                    ProductManager.S.ChangeAllPrice(10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 4:
                    AddItem.S.SearchItem("상아",5);
                    AddItem.S.SearchItem("첨단 기계",5);
                    AddItem.S.SearchItem("핵연료",5);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 5:
                    AddItem.S.SearchItem("킹 슬라임",8);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 6:
                    MoneyManager.S.GetMoney(30000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 7:
                    ProductManager.S.ChangeAllPrice(10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 8:
                    Shop.S.VariationFame(500);
                    for (int i = 0; i < DayManager.S.allStaff.Length; i++)
                    {
                        DayManager.S.allStaff[i].ChangeLoyalty(50);
                    }
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 9:
                    AddItem.S.SearchItem("썬 슬라임", 10);
                    AddItem.S.SearchItem("어스 슬라임", 10);
                    AddItem.S.SearchItem("정글 슬라임", 10);
                    AddItem.S.SearchItem("툰트라 슬라임", 10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 10:
                    MoneyManager.S.GetMoney(50000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 11:
                    GeneralMeeting.S.illegality_Stack = 0;
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 12:
                    ProductManager.S.ChangeAllPrice(10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 13:
                    MoneyManager.S.GetMoney(25000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 14:
                    MoneyManager.S.GetMoney(40000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 15:
                    ProductManager.S.ChangeAllPrice(10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 16:
                    MoneyManager.S.GetMoney(40000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 17:
                    ProductManager.S.ChangeAllPrice(10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 18:
                    MoneyManager.S.GetMoney(100000);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 19:
                    ProductManager.S.ChangeAllPrice(10);
                    scenarioMaxNum += 1;
                    NextSenario();
                    scenarioComplete = false;
                    break;
                case 20:
                    scene_Changer.GoEnding();
                    break;
                default:
                    break;
            }
            }
        
    }
    public void N_ScenarioCheak()
    {
        switch (scenarioMaxNum)
        {
            case 1:
                if (FarmUpgrade.S.OpenTrashStorageTier >= 3 &&
                    FarmUpgrade.S.OpenSlimeFarmTier >= 3)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 2:
                if(N_scenario2_CreateNum>=100)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 3:
                if (N_scenario3_SellNum>=100)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 4:
                if (CompanyValue.S.allValue>=10000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 5:
                if (DayManager.S.createLines[0].CheckScenario3() &&
                    DayManager.S.createLines[1].CheckScenario3() &&
                    DayManager.S.createLines[2].CheckScenario3())
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 6:
                if (N_scenario6_CreateNum>=300)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 7:
                if (N_scenario7_SellNum>=300)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 8:
                if (FarmUpgrade.S.TrashQualityUpTier>=1&&
                    FarmUpgrade.S.TwinSlimeTier>=1&&
                    FactoryUpgrade.S.ProductQualityUpTier>=1)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 9:
                if (CompanyValue.S.allValue>=20000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 10:
                if (Marketing.S.markettingTier>=2&&
                    HRDepartment.S.HRDepartmentTier>=2&&
                    Management.S.ManagementTier>=2)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 11:
                int value=0;//불만도 90이하인 기관수
                if (GeneralMeeting.S.governmentDI <= 90) value += 1;
                if (GeneralMeeting.S.consumerGroupDI <= 90) value += 1;
                if (GeneralMeeting.S.environmentalGroupDI <= 90) value += 1;
                if (GeneralMeeting.S.laborUnionDI <= 90) value += 1;
                if (GeneralMeeting.S.FDADI <= 90) value += 1;
                if (GeneralMeeting.S.AnimalProtectionGroupDI <= 90) value += 1;
                if (value>=4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 12:
                if (FarmUpgrade.S.TrashQualityUpTier >= 2 &&
                    FarmUpgrade.S.TwinSlimeTier >= 2 &&
                    FactoryUpgrade.S.ProductQualityUpTier >= 2)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 13:
                if (DayManager.S.year>=5)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 14:
                if (FarmUpgrade.S.OpenSlimeFarmTier >= 9 &&
                    FarmUpgrade.S.OpenTrashStorageTier >= 9 &&
                    Shop.S.shopStaffNum >= 3 &&
                    DayManager.S.createLines[0].CheckScenario3() &&
                    DayManager.S.createLines[1].CheckScenario3() &&
                    DayManager.S.createLines[2].CheckScenario3())
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 15:
                if (CompanyValue.S.allValue>=30000)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 16:
                if (FarmUpgrade.S.TrashQualityUpTier >= 3 &&
                    FarmUpgrade.S.TwinSlimeTier >= 3 &&
                    FactoryUpgrade.S.ProductQualityUpTier >= 3)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 17:
                if (Shop.S.fame>=850)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 18:
                if (Management.S.activeNum+
                    Marketing.S.activeNum +
                    HRDepartment.S.activeNum>=15)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 19:
                if (FarmUpgrade.S.TrashQualityUpTier >= 4 &&
                    FarmUpgrade.S.TwinSlimeTier >= 4 &&
                    FactoryUpgrade.S.ProductQualityUpTier >= 4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 20:
                if (MoneyManager.S.CurrentMoney()>=1000000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            default:
                break;
        }
    }
    public void E_ScenarioCheak()
    {
        switch (scenarioMaxNum)
        {
            case 1:
                if (FarmUpgrade.S.OpenTrashStorageTier >= 2 &&
                    FarmUpgrade.S.OpenSlimeFarmTier >= 2)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 2:
                if (scenario2_coal >= 1 &&
                    scenario2_compost >= 1 &&
                    scenario2_scrab >= 1)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 3:
                if (scenario3_Check)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 4:
                if (scenario4_createNum >= 10)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 5:
                if (Shop.S.shopStaffNum > 0)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 6:
                if (scenario6_sellNum >= 10)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 7:
                if (DayManager.S.month > 1)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 8:
                if (E_scenario8_createNum>=25)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 9:
                if (MoneyManager.S.CurrentMoney()>=100000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 10:
                if (FarmUpgrade.S.TrashQualityUpTier > 0)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 11:
                if (DayManager.S.year>0)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 12:
                if (FactoryUpgrade.S.ProductQualityUpTier > 0)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 13:
                if (FarmUpgrade.S.OpenTrashStorageTier >= 5 &&
                    FarmUpgrade.S.OpenSlimeFarmTier >= 5)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 14:
                if (Management.S.activeNum > 0 &&
                    Marketing.S.activeNum > 0 &&
                    HRDepartment.S.activeNum > 0)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 15:
                bool allStaffHire=true;
                for (int i = 0; i < DayManager.S.allStaff.Length; i++)
                {
                    Staff staff = DayManager.S.allStaff[i];
                    
                    if (!staff.GetStaffOn())
                    {
                        allStaffHire = false;
                    }
                }
                if (allStaffHire)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 16:
                if (FarmUpgrade.S.SlimeFarmCostCuttingTier >= 1 &&
                    FarmUpgrade.S.TrashStorageCostCuttingTier >= 1 &&
                    FactoryUpgrade.S.LineCostCuttingTier >= 1 &&
                    FactoryUpgrade.S.PackageCostCuttingTier >= 1 &&
                    ShopUpgrade.S.SellLineCostCuttingTier >= 1)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 17:
                if (Marketing.S.markettingTier >= 1 ||
                    HRDepartment.S.HRDepartmentTier >= 1 ||
                    Management.S.ManagementTier >= 1)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 18:
                if (E_scenario18_SellNum>=1000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 19:
                if (FarmUpgrade.S.TrashQualityUpTier > 1
                    &&FactoryUpgrade.S.ProductQualityUpTier>1)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 20:
                if (DayManager.S.year>=5)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            default:
                break;
        }
    }
    public void H_ScenarioCheak()
    {
        int value=0;
        switch (scenarioMaxNum)
        {
            case 1:
                if (H_scenario1_SellNum>=200)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 2:
                if (FarmUpgrade.S.TrashQualityUpTier>0&&FactoryUpgrade.S.ProductQualityUpTier>0)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 3:
                if (H_scenario3_month>=4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 4:
                if (FarmUpgrade.S.TrashStorageCostCuttingTier>2&&FarmUpgrade.S.SlimeFarmCostCuttingTier>2)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 5:
                if (FactoryUpgrade.S.LineCostCuttingTier>2&&FactoryUpgrade.S.PackageCostCuttingTier>2)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 6:
                value = 0;//불만도 90이하인 기관수
                if (GeneralMeeting.S.governmentDI <= 100) value += 1;
                if (GeneralMeeting.S.consumerGroupDI <= 100) value += 1;
                if (GeneralMeeting.S.environmentalGroupDI <= 100) value += 1;
                if (GeneralMeeting.S.laborUnionDI <= 100) value += 1;
                if (GeneralMeeting.S.FDADI <= 100) value += 1;
                if (GeneralMeeting.S.AnimalProtectionGroupDI <= 100) value += 1;
                if (value >= 6)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 7:
                if (FarmUpgrade.S.OpenSlimeFarmTier>9&&FarmUpgrade.S.OpenTrashStorageTier>8)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 8:
                if (CompanyValue.S.allValue>=25000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 9:
                if (H_scenario9_Sellnum>=600)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 10:
                if (FarmUpgrade.S.TwinSlimeTier>5)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 11:
                value = 0;//불만도 90이하인 기관수
                if (GeneralMeeting.S.governmentDI <= 80) value += 1;
                if (GeneralMeeting.S.consumerGroupDI <= 80) value += 1;
                if (GeneralMeeting.S.environmentalGroupDI <= 80) value += 1;
                if (GeneralMeeting.S.laborUnionDI <= 80) value += 1;
                if (GeneralMeeting.S.FDADI <= 80) value += 1;
                if (GeneralMeeting.S.AnimalProtectionGroupDI <= 80) value += 1;
                if (value >= 4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 12:
                if (H_scenario12_month>=4)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 13:
                if (Shop.S.fame>=1000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 14:
                if (FarmUpgrade.S.SlimeFarmCostCuttingTier>4&&
                    FarmUpgrade.S.TrashStorageCostCuttingTier>4&&
                    FactoryUpgrade.S.LineCostCuttingTier>4&&
                    FactoryUpgrade.S.PackageCostCuttingTier>4&&
                    ShopUpgrade.S.SellLineCostCuttingTier>4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 15:
                if (H_scenario15_month>=4)
                {
                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 16:
                if (FarmUpgrade.S.TrashQualityUpTier>4&&
                    FactoryUpgrade.S.ProductQualityUpTier>4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 17:
                if (H_scenario17_FireNum>=9)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 18:
                if (H_scenario18_month>=4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 19:
                value = 0;//불만도 90이하인 기관수
                if (GeneralMeeting.S.governmentDI <= 60) value += 1;
                if (GeneralMeeting.S.consumerGroupDI <= 60) value += 1;
                if (GeneralMeeting.S.environmentalGroupDI <= 60) value += 1;
                if (GeneralMeeting.S.laborUnionDI <= 60) value += 1;
                if (GeneralMeeting.S.FDADI <= 60) value += 1;
                if (GeneralMeeting.S.AnimalProtectionGroupDI <= 60) value += 1;
                if (value >= 4)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            case 20:
                if (CompanyValue.S.allValue >= 250000)
                {

                    scenarioComplete = true;
                }
                else
                {
                    scenarioComplete = false;
                }
                break;
            default:
                break;
        }
    }
    public void UiOn()
    {
        LocationManager.openUI = true;
        
        
        SoundManager.S.PlaySE("시나리오");
        UiBase.SetActive(true);
        switch (DifficultManager.S.gameDifficult)
        {
            case DifficultManager.GameDifficult.none:
                break;
            case DifficultManager.GameDifficult.easy:
                E_MoveSenario(scenarioMaxNum);
                break;
            case DifficultManager.GameDifficult.normal:
                N_MoveSenario(scenarioMaxNum);
                break;
            case DifficultManager.GameDifficult.hard:
                H_MoveSenario(scenarioMaxNum);
                break;
            case DifficultManager.GameDifficult.endless:
                break;
            default:
                break;
        }
        if (Time.timeScale==0)
        {
            ispause = true;
        }
        if (Time.timeScale > 0)
        {
            Pause.S.PauseGame();
        }

    }
    public void UiExit()
    {
        SoundManager.S.PlaySE("닫기2");
        LocationManager.openUI = false;
        if (!ispause)
        {
            Pause.S.PauseGame();
        }
        ispause = false;
        UiBase.SetActive(false);
    }
}
