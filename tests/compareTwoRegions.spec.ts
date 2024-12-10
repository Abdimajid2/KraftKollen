import { test, expect } from '@playwright/test';
import { waitForDebugger } from 'inspector';
import { cwd } from 'process';


test('Ensure arrow is green when second year value is greater than first year', async ({ page }) => {
  

  // Navigate to the page and wait for it to load completely
  await page.goto('http://localhost:5000/CompareTwoRegionsOutputView', { waitUntil: 'load', timeout: 10000 });  // 60s timeout

  // Wait for the select element to be visible
  const yearOne = page.getByTestId('year-one')
  await yearOne.waitFor({ state: 'visible' });

  // Workaround bad practice
  // Added timeout because the yearone option was not selected properly. Probably something with the asynchronicity
  await page.waitForTimeout(500);

  // Simulate the year selection
  await yearOne.selectOption('2016')

  // // Wait for the select elements to be visible and interactable
  const yearTwo = page.getByTestId('year-two')
  await yearTwo.waitFor({ state: 'visible' });

  // Simulate the year selection
  await yearTwo.selectOption('2017')

  // Click the button to trigger the comparison logic
  const button = page.getByTestId('fetch-button');
  await button.click(); 

  // Workaround bad practice
  // More wait to let the page load the content before access the next element
  //await page.waitForTimeout(500);

  // Wait for the specific element to appear
  //const locator = page.getByTestId('comparison-symbol');
  //await expect(locator).toBeVisible();

  // Wait for the DOM to update and display the arrow
  // Get the computed color of the arrow element
  const arrowElement = page.getByTestId('right-arrow');
  await arrowElement.waitFor({ state: 'visible' });
  

  const color = await arrowElement?.evaluate((el) => window.getComputedStyle(el).color);

  // Verify that the color matches the expected Bootstrap green
  expect(color).toBe('rgb(15, 81, 50)'); // Expected green color
});

test('Ensure arrow is red when first year value is greater than second year', async ({ page }) => {
  

  // Navigate to the page and wait for it to load completely
  await page.goto('http://localhost:5000/CompareTwoRegionsOutputView', { waitUntil: 'load', timeout: 10000 });  // 60s timeout

  // Wait for the select element to be visible
  const yearOne = page.getByTestId('year-one')
  await yearOne.waitFor({ state: 'visible' });

  // Workaround bad practice
  // Added timeout because the yearone option was not selected properly. Probably something with the asynchronicity
  await page.waitForTimeout(500);

  // Simulate the year selection
  await yearOne.selectOption('2017')

  // // Wait for the select elements to be visible and interactable
  const yearTwo = page.getByTestId('year-two')
  await yearTwo.waitFor({ state: 'visible' });

  // Simulate the year selection
  await yearTwo.selectOption('2016')

  // Click the button to trigger the comparison logic
  const button = page.getByTestId('fetch-button');
  await button.click(); 

  // Workaround bad practice
  // More wait to let the page load the content before access the next element
  //await page.waitForTimeout(500);

  // Wait for the specific element to appear
  //const locator = page.getByTestId('comparison-symbol');
  //await expect(locator).toBeVisible();

  // Wait for the DOM to update and display the arrow
  // Get the computed color of the arrow element
  const arrowElement = page.getByTestId('left-arrow');
  await arrowElement.waitFor({ state: 'visible' });
  

  const color = await arrowElement?.evaluate((el) => window.getComputedStyle(el).color);

  // Verify that the color matches the expected Bootstrap green
  expect(color).toBe('rgb(132, 32, 41)'); // Expected green color
});


test('Ensure equalsign is blue when first year value is equal to second year', async ({ page }) => {
  

  // Navigate to the page and wait for it to load completely
  await page.goto('http://localhost:5000/CompareTwoRegionsOutputView', { waitUntil: 'load', timeout: 10000 });  // 60s timeout

  // Wait for the select element to be visible
  const yearOne = page.getByTestId('year-one')
  await yearOne.waitFor({ state: 'visible' });

  // Workaround bad practice
  // Added timeout because the yearone option was not selected properly. Probably something with the asynchronicity
  await page.waitForTimeout(500);

  // Simulate the year selection
  await yearOne.selectOption('2017')

  // // Wait for the select elements to be visible and interactable
  const yearTwo = page.getByTestId('year-two')
  await yearTwo.waitFor({ state: 'visible' });

  // Simulate the year selection
  await yearTwo.selectOption('2017')

  // Click the button to trigger the comparison logic
  const button = page.getByTestId('fetch-button');
  await button.click(); 

  // Workaround bad practice
  // More wait to let the page load the content before access the next element
  //await page.waitForTimeout(500);

  // Wait for the specific element to appear
  //const locator = page.getByTestId('comparison-symbol');
  //await expect(locator).toBeVisible();

  // Wait for the DOM to update and display the arrow
  // Get the computed color of the arrow element
  const arrowElement = page.getByTestId('equal');
  await arrowElement.waitFor({ state: 'visible' });
  

  const color = await arrowElement?.evaluate((el) => window.getComputedStyle(el).color);

  // Verify that the color matches the expected Bootstrap green
  expect(color).toBe('rgb(5, 81, 96)'); // Expected green color
});
