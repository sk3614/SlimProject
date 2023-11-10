using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject[] CustomerPrefabs;
    public List<GameObject> customers;
    public Sprite[] customerImages;

    // Start is called before the first frame update
    void Start()
    {
        customers = new List<GameObject>();
       
    }

    // Update is called once per frame

    public void NewCustomer()
    {
        int value = Random.Range(0, 4);
        GameObject customer = CustomerPrefabs[value];

        int customerNumber;
        customer=Instantiate(customer);
        customer.transform.SetParent(gameObject.transform);
        customers.Add(customer);
        customerNumber=customers.Count;

        customer.gameObject.transform.localPosition = new Vector3(0.4f + 0.3f * customerNumber, -0.3f - 0.2f * customerNumber, -1+0.1f*-customerNumber);
    }
    public IEnumerator MoveCustomer()
    {
        //0번 구매 애니메이션 실행후 파괴
        Destroy(customers[0]);
        customers.RemoveAt(0);
        for (int i = 0; i < customers.Count; i++)
        {
            //customers[i].gameObject.transform.localPosition = new Vector3(0.4f + 0.3f * i, -0.3f - 0.2f * i, -1 + 0.1f * -i);
            customers[i].GetComponent<CustomerSet>().MovePosition(new Vector3(0.4f + 0.3f * i, -0.3f - 0.2f * i, -1 + 0.1f * -i),0);
            yield return new WaitForSeconds(0.1f);

        }
        StopCoroutine("MoveCustomer");
    }
    public void RemoveCustomer()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            Destroy(customers[i]);
            
        }
        customers.Clear();
    }


}
