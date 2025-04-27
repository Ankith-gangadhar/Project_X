import requests
from bs4 import BeautifulSoup
import pandas as pd


def scrape_products(url):
    # Send a GET request to the webpage
    response = requests.get(url)

    # Check if the request was successful
    if response.status_code != 200:
        print(f"Failed to fetch page: {url}")
        return []

    # Parse the HTML content using BeautifulSoup
    soup = BeautifulSoup(response.text, 'html.parser')

    # Find all product containers on the page (adjust according to the site's HTML structure)
    products = soup.find_all('div', class_='product-item')  # Adjust this class based on the page's HTML

    # Create a list to hold all extracted product data
    product_data = []

    # Loop through all products and extract required details
    for product in products:
        # Extract product name, category, and MRP (Adjust these based on actual HTML structure)
        name = product.find('h2', class_='product-title').text.strip() if product.find('h2',
                                                                                       class_='product-title') else "Unknown"
        category = product.find('span', class_='category').text.strip() if product.find('span',
                                                                                        class_='category') else "Unknown"
        mrp = product.find('span', class_='mrp').text.strip() if product.find('span', class_='mrp') else "Unknown"

        # Add the extracted data to the product_data list
        product_data.append({'Name': name, 'Category': category, 'MRP': mrp})

    # Return the extracted data
    return product_data
