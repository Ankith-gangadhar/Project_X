import pandas as pd

# Load the CSV sheet (use read_csv instead of read_excel)
file_path = 'C:/Users/ankit/Downloads/Item.csv'  # Replace with the path to your CSV file
df = pd.read_csv(file_path)

# Preview the first few rows to understand the structure
print(df.head())

# Extract relevant columns: Product ID, Product Name, Category Name, Selling Price
df_filtered = df[['Product ID', 'Product Name', 'Category Name', 'Selling Price']]


# Remove 'INR ' from the 'Selling Price' column and convert it to float
df_filtered.loc[:, 'Selling Price'] = df_filtered['Selling Price'].replace('INR ', '', regex=True).astype(float)

# Display the filtered data
print(df_filtered.head())

# Optionally, you can save the filtered data to a new Excel file or CSV for further processing
df_filtered.to_excel('filtered_products.xlsx', index=False)
# Or, for CSV
# df_filtered.to_csv('filtered_products.csv', index=False)
