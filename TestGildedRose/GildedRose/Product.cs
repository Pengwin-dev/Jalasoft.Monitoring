namespace TestGildedRose
{
    public class Product
    {
        public Product(string Name, int QualityValue, int SellinValue)
        {
            this.Name = Name;
            this.QualityValue = QualityValue;
            this.SellinValue = SellinValue;
        }

      
        public string Name { get; set; }
        public int QualityValue { get; set; }
        public int SellinValue { get; set; }
        private int QualityDecrement { get; set; }
        private int QualityDecrementMultiplier { get; set; }
        public bool CanBeSold { get; set; }
        public bool IsConjured { get; set; }
        

        public void UpdateProduct()
        {
            this.CanBeSold = true;
            this.QualityDecrementMultiplier = 1;
            // Validator: Currently is NN Condition && non-gt 50
            if (!isValidProduct())
            {
                throw new Exception("Invalid Data");
            }
            // When isn't a Special Case (kinda weird logic, gotta check!)
            if (this.Name != "Aged Brie" && this.Name != "Sulfuras" && this.Name != "Backstage Pass")
            {
                if (this.IsConjured == true) { QualityDecrementMultiplier = 2; }
                if (SellinValue > 0)
                    this.SellinValue--;

                if (QualityValue > 0)
                    if (SellinValue <= 0)
                        this.QualityDecrement = 2 * QualityDecrementMultiplier;
                    else
                        this.QualityDecrement = 1 * QualityDecrementMultiplier;
                this.QualityValue -= this.QualityDecrement;
            }
            //Here are the Special Cases.
            else
            {
                //Aged Brie: increase QV when is getting older
                if (this.Name == "Aged Brie") {
                    if (SellinValue > 0) {
                        this.SellinValue--;
                    }
                    this.QualityValue++;
                }
                //Sulfuras: Cant Be Sold && wont decrease its QV
                if (this.Name == "Sulfuras") {
                    this.CanBeSold = false;
                    if (SellinValue > 0)
                        this.SellinValue--;
                }
                //BackstagePasses: When SellIn <= 10, QV increases by 2. When SellIN <= 5, QV += 3. When SellIn == 0 : QV ==0  
                if (this.Name == "Backstage Pass") { 
                    if (SellinValue > 0) { 
                        this.SellinValue--;
                        if(SellinValue <= 10) { 
                            QualityValue+=2;
                            if(SellinValue <= 5) { 
                                QualityValue++;
                            }
                        }
                        if (SellinValue == 0)
                        {
                            this.QualityValue = 0;
                        }
                    }
                }

     
                        }
       
        }

        private bool isValidProduct()
        {
            return (this.QualityValue <= 50 && this.QualityValue >= 0) || (this.QualityValue == 80 && this.QualityValue >= 0 && this.Name=="Sulfuras");
        }

    }
}