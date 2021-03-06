USE [FamilyRecipeBook]
GO
SET IDENTITY_INSERT [dbo].[recipe] ON 

INSERT [dbo].[recipe] ([id], [name], [description], [prep_minutes], [cook_minutes], [source], [date_added], [user_id], [family_id]) VALUES (1, N'Lemon Cooler Cream Cake', N'
Incredibly easy and inexpensive to make. Great for the summer, perfect for all occasions. Can be made with low fat topping.        ', 30, 30, N'https://www.allrecipes.com/recipe/19836/lemon-cooler-cream-cake/?internalSource=popular&referringContentType=Homepage', CAST(N'2019-04-25' AS Date), 1, 1)
INSERT [dbo].[recipe] ([id], [name], [description], [prep_minutes], [cook_minutes], [source], [date_added], [user_id], [family_id]) VALUES (2, N'Meatballs Divine', N'
These are amazing and nothing amazing is ever easy; keep that in mind when you undertake this recipe. Try to avoid tasting them before you''re ready to serve because you may end up eating them all and your guests will be left with only marinara and pasta. I make this recipe as written, then I freeze half of it when combined as it makes about 40-50, 1 1/2-inch meatballs (enough to feed Sicily.)        ', 1, 2, N'https://www.allrecipes.com/recipe/234184/meatballs-divine/?internalSource=popular&referringContentType=Homepage', CAST(N'2019-04-25' AS Date), 1, 1)
INSERT [dbo].[recipe] ([id], [name], [description], [prep_minutes], [cook_minutes], [source], [date_added], [user_id], [family_id]) VALUES (3, N'Chef John''s Creamy Mushroom Pasta ', N'
A beautiful, aromatic, creamy mushroom sauce coats hot cooked fettuccine pasta in this quick dish. You can use any kind of pasta you like.        ', 15, 30, N'https://www.allrecipes.com/recipe/234667/chef-johns-creamy-mushroom-pasta/?internalSource=popular&referringContentType=Homepage', CAST(N'2019-04-25' AS Date), 1, 1)
INSERT [dbo].[recipe] ([id], [name], [description], [prep_minutes], [cook_minutes], [source], [date_added], [user_id], [family_id]) VALUES (4, N'Cake Mix Cinnamon Rolls', N'
This recipe is absolutely delicious.  I make them the night before, take them out in the morning and let them rise. I have also made sticky buns with this recipe using a coconut/pecan frosting for the bottom of my pan.        ', 30, 20, N'https://www.allrecipes.com/recipe/16822/cake-mix-cinnamon-rolls/?internalSource=popular&referringContentType=Homepage', CAST(N'2019-04-25' AS Date), 1, 1)
INSERT [dbo].[recipe] ([id], [name], [description], [prep_minutes], [cook_minutes], [source], [date_added], [user_id], [family_id]) VALUES (5, N'Amazing Crusted Chicken', N'
This is my husband''s favorite meal for me to cook. The chicken is so moist and flavorful. The more seasonings you use the better it tastes. Mayo may cause some areas to be a little mushy but it still tastes amazing!        ', 25, 35, N'https://www.allrecipes.com/recipe/213656/amazing-crusted-chicken/?internalSource=popular&referringContentType=Homepage', CAST(N'2019-04-25' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[recipe] OFF
SET IDENTITY_INSERT [dbo].[ingredient] ON 

INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (1, N'1 (18.25 ounce) package lemon cake mix', 1)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (2, N'1 cup hot water', 1)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (3, N'1 cup cold water', 1)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (4, N'2 (3 ounce) packages lemon flavored Jell-O&#174; mix', 1)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (5, N'1 cup milk', 1)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (6, N'1 (3.4 ounce) package instant vanilla pudding mix', 1)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (7, N'1 (8 ounce) container frozen whipped topping, thawed', 1)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (8, N'1/2 cup chopped fresh flat-leaf parsley', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (9, N'2 large eggs', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (10, N'3 tablespoons Worcestershire sauce', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (11, N'6 leaves fresh basil, or to taste', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (12, N'3 cloves garlic, minced', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (13, N'1 1/2 teaspoons kosher salt', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (14, N'1 teaspoon ground black pepper', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (15, N'1 teaspoon Italian seasoning', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (16, N'1 teaspoon olive oil', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (17, N'1 large yellow onion, finely chopped', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (18, N'1 cup shredded mozzarella cheese', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (19, N'2/3 cup freshly grated Parmesan cheese', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (20, N'3 tablespoons ricotta cheese', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (21, N'2 pounds ground beef chuck', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (22, N'1 pound Italian pork sausage', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (23, N'2 cups fresh bread crumbs', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (24, N'1 cup olive oil for frying', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (25, N'6 cups bottled marinara sauce, or more to taste', 2)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (26, N'2 tablespoons olive oil', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (27, N'3/4 pound fresh white mushrooms, sliced', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (28, N'1/4 pound fresh shiitake mushrooms, stemmed and sliced', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (29, N'salt and ground black pepper to taste', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (30, N'2 cloves garlic, minced', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (31, N'2 fluid ounces sherry', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (32, N'1 cup chicken stock', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (33, N'1 cup heavy whipping cream', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (34, N'8 ounces fettuccine pasta', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (35, N'1 1/2 teaspoons chopped fresh thyme', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (36, N'1 1/2 teaspoons chopped fresh chives', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (37, N'1 1/2 teaspoons chopped fresh tarragon', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (38, N'9 tablespoons freshly shredded Parmigiano-Reggiano cheese, divided', 3)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (39, N'3 (.25 ounce) packages active dry yeast', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (40, N'2 1/2 cups warm water', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (41, N'1 (18.25 ounce) package white cake mix', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (42, N'4 1/2 cups all-purpose flour', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (43, N'1/2 cup butter, softened', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (44, N'1/2 cup brown sugar', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (45, N'2 teaspoons ground cinnamon', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (46, N'1/4 cup butter, melted', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (47, N'1/3 cup white sugar', 4)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (48, N'2 cups cheese flavored crackers (such as Cheez-It&#174;), crushed', 5)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (49, N'1 cup French-fried onions, crushed', 5)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (50, N'1/2 cup Italian bread crumbs', 5)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (51, N'2 teaspoons sesame seed, toasted', 5)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (52, N'salt and ground black pepper to taste', 5)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (53, N'4 skinless, boneless chicken breast halves - cut in half', 5)
INSERT [dbo].[ingredient] ([id], [ingredient], [recipe_id]) VALUES (54, N'3 tablespoons mayonnaise', 5)
SET IDENTITY_INSERT [dbo].[ingredient] OFF
SET IDENTITY_INSERT [dbo].[images] ON 

INSERT [dbo].[images] ([id], [recipe_id], [filename]) VALUES (1, 1, N'https://images.media-allrecipes.com/userphotos/560x315/3814068.jpg')
INSERT [dbo].[images] ([id], [recipe_id], [filename]) VALUES (2, 2, N'https://images.media-allrecipes.com/userphotos/560x315/1124412.jpg')
INSERT [dbo].[images] ([id], [recipe_id], [filename]) VALUES (3, 3, N'https://images.media-allrecipes.com/userphotos/560x315/4073969.jpg')
INSERT [dbo].[images] ([id], [recipe_id], [filename]) VALUES (4, 4, N'https://images.media-allrecipes.com/userphotos/560x315/799169.jpg')
INSERT [dbo].[images] ([id], [recipe_id], [filename]) VALUES (5, 5, N'https://images.media-allrecipes.com/userphotos/560x315/1366176.jpg')
SET IDENTITY_INSERT [dbo].[images] OFF
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (1, 1, N'
                            Prepare cake and bake according to package directions in a 9x13 inch baking dish. With a fork, poke holes all over top of cake.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (1, 2, N'
                            Combine 1 cup hot water and 1 cup cold water with one package of lemon gelatin. Stir until gelatin is dissolved, and pour mixture over cake. Chill in refrigerator until cool.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (1, 3, N'
                            In large bowl stir together milk, vanilla pudding mix and remaining package of lemon gelatin until powders are dissolved. Fold in whipped topping and spread mixture over cake. Refrigerate until serving.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (2, 1, N'
                            Blend parsley, eggs, Worcestershire sauce, basil leaves, garlic, kosher salt, black pepper, and Italian seasoning in a food processor until herbs are finely chopped.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (2, 2, N'
                            Heat 1 teaspoon olive oil in a skillet over medium-high heat. Cook and stir onion in hot oil until translucent and nearly caramelized, about 10 minutes. Remove from heat.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (2, 3, N'
                            Stir egg mixture, onion, mozzarella cheese, Parmesan cheese, and ricotta cheese together in a large bowl. Add ground beef, Italian sausage, and fresh bread crumbs to egg mixture; mix. Shape into 1 1/2-inch meatballs.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (2, 4, N'
                            Preheat oven to 400 degrees F (200 degrees C).
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (2, 5, N'
                            Heat 1 cup olive oil in a large nonstick pan over medium-high heat. Cook meatballs in oil until seared evenly all around, 4 to 5 minutes per meatball; transfer to a nonstick baking sheet.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (2, 6, N'
                            Bake meatballs in preheated oven until cooked through, 15 minutes.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (2, 7, N'
                            Heat marinara sauce in a large pot over medium heat. Transfer meatballs to marinara sauce using a slotted spoon. Bring mixture to a boil, reduce heat to low, and simmer for a least 1 hour.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (3, 1, N'
                            Heat olive oil in a large skillet over medium heat. Cook and stir white and shiitake mushrooms in the hot oil with a pinch of salt until until the juice from the mushrooms evaporates and the mushrooms are browned, about 10 minutes.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (3, 2, N'
                            Stir garlic into mushrooms and cook for 1 minute; pour in sherry and cook until wine is nearly evaporated. Mix chicken stock into mushroom mixture; season with salt and black pepper. Bring to a simmer, reduce heat, and cook until slightly thickened, about 5 minutes.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (3, 3, N'
                            Pour cream into mushroom mixture, stir to combine, and simmer for 5 minutes. Mixture will foam and thicken slightly.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (3, 4, N'
                            Fill a large pot with lightly salted water and bring to a rolling boil. Stir in the fettuccine, bring back to a boil, and cook pasta over medium heat until cooked through but still firm to the bite, about 8 minutes. Drain but do not rinse pasta; transfer to a large serving bowl and keep warm.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (3, 5, N'
                            Stir thyme, chives, and tarragon into mushroom sauce and turn off heat; mix 1/2 cup Parmigiano-Reggiano cheese into sauce until cheese has melted.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (3, 6, N'
                            Pour all the mushroom sauce and half the mushrooms over pasta, reserving about half the mushrooms in the skillet. Toss pasta in sauce until coated; top with remaining mushrooms and remaining 1 tablespoon Parmigiano-Reggiano cheese for garnish.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (4, 1, N'
                            In a small bowl, dissolve yeast in warm water. Let stand until creamy, about 10 minutes.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (4, 2, N'
                            In a large bowl, combine the yeast mixture with the cake mix and 3 cups of the flour; stir to combine. Add the remaining flour, 1/2 cup at a time, stirring well after each addition. When the dough has pulled together, turn it out onto a lightly floured surface and knead until smooth and elastic, about 8 minutes.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (4, 3, N'
                            Lightly oil a large bowl, place the dough in the bowl and turn to coat with oil. Cover with a damp cloth and let rise in a warm place until doubled in volume, about 30 minutes.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (4, 4, N'
                            Deflate the dough and turn it out onto a lightly floured surface. Roll the dough into a 10x16 inch rectangle. spread the softened butter over the rectangle; sprinkle on brown sugar and cinnamon. Starting from one of the long sides, roll up the rectangle and cut into 1 inch wide rolls.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (4, 5, N'
                            Preheat oven to 375 degrees F (190 degrees C). Grease a 9x13 inch baking pan. Pour the melted butter into a small bowl and mix the white sugar and pecans in another small bowl. Dip the top of each roll in the melted butter, then in the sugar and pecan mixture, then place the topped rolls snugly into the prepared pan. Cover the rolls with a damp cloth and let rise until doubled in volume, about 30 minutes.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (4, 6, N'
                            Bake at 375 degrees F (190 degrees C) for 20 minutes, or until rolls are golden.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (5, 1, N'
                            Preheat oven to 450 degrees F (230 degrees C). Spray a baking dish with cooking spray.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (5, 2, N'
                            Mix cheese-flavored crackers, French-fried onions, Italian bread crumbs, sesame seeds, salt, and pepper in a bowl. Set aside.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (5, 3, N'
                            Wash and pat chicken breasts dry. Spread a thin layer of mayonnaise on one side of each piece and place mayonnaise-side down in the cracker mixture. Spread a thin layer of mayonnaise on the other side of the chicken and cover with the cracker mixture, patting firmly into the chicken. Place chicken breasts on the prepared baking dish. Sprinkle remaining cracker mixture on top; lightly spray the chicken with cooking spray.
                            
                        ')
INSERT [dbo].[steps] ([recipe_id], [step_number], [step_text]) VALUES (5, 4, N'
                            Bake in the preheated oven until the chicken breasts are no longer pink in the center and the juices run clear, 35 to 40 minutes. An instant-read thermometer inserted into the center should read at least 165 degrees F (74 degrees C).
                            
                        ')
